using SWecommerce.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio
{
    public class ConsultaBuscarTodosProdutos : IConsulta
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ConsultaBuscarTodosProdutos(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public List<BuscarProdutosDominio> Executar()
        {
            try
            {
                return _produtoRepositorio.BuscarProdutos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
