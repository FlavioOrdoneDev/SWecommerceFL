[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SWecommerce.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SWecommerce.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace SWecommerce.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Infra.Contextos;
    using Dominio;
    using Infra;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<SWecommerceContexto>().ToSelf().InRequestScope();
            kernel.Bind<IPromocaoFactory>().To<PromocaoFactory>().InRequestScope();
            kernel.Bind<IPromocaoStrategy>().To<PromocaoLeve3ProdutosPague10ReaisStrategy>().InRequestScope();
            kernel.Bind<IPromocaoStrategy>().To<PromocaoCompre1Leve2Strategy>().InRequestScope();
            kernel.Bind<IPromocaoStrategy>().To<ProdutoSemPromocaoStrategy>().InRequestScope();
            kernel.Bind<IProdutoRepositorio>().To<ProdutoRepositorio>().InRequestScope();
                       
        }        
    }
}
