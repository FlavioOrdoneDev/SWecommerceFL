using SWecommerce.Dominio.Resultados;
using SWecommerce.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio
{
    public class ComandoInserirProduto : IComandoExecutar<ProdutoDominio>
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ComandoInserirProduto(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IConsulta Executar(ProdutoDominio entidade)
        {
            try
            {
                var produto = new Produto(entidade.Nome, entidade.Preco, entidade.TipoPromocao);
                _produtoRepositorio.Inserir(produto);

                return new ProdutoConsultaResultado(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
