using SWecommerce.Dominio;
using SWecommerce.Dominio.Entidades;
using SWecommerce.Infra;
using System;
using System.Web.Mvc;

namespace SWecommerce.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ComandoCalcularPromocao     _comandoCalcularPromocao;
        private readonly ConsultaBuscarTodosProdutos _consultaBuscarTodosProdutos;
        private readonly ProdutoRepositorio          _repositorioProduto;      

        public HomeController(ComandoCalcularPromocao     comandoCalcularPromocao,
                              ConsultaBuscarTodosProdutos consultaBuscarTodosProdutos,
                              ProdutoRepositorio          repositorioProduto)
        {
            _comandoCalcularPromocao     = comandoCalcularPromocao;
            _consultaBuscarTodosProdutos = consultaBuscarTodosProdutos;
            _repositorioProduto          = repositorioProduto;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var produtos = _consultaBuscarTodosProdutos.Executar();
                return View(produtos);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpGet]
        public ActionResult Pedido()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CalcularItem(Guid produtoId, int quantidade)
        {
            try
            {                
                var produto = _repositorioProduto.BuscarPorId(produtoId);
                var entidade = new CalcularPromocaoEntrada
                {
                    Produto = produto,
                    Quantidade = quantidade,
                    TipoPromocao = produto.TipoPromocao
                };

                var resultado = _comandoCalcularPromocao.Executar(entidade);                

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}