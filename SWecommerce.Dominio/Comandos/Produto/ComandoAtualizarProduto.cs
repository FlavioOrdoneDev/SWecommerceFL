using SWecommerce.Dominio.Entidades;
using SWecommerce.Dominio.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio
{
    public class ComandoAtualizarProduto : IComandoExecutar<ProdutoDominio>
    {
        
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ComandoAtualizarProduto(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IConsulta Executar(ProdutoDominio entidade)
        {
            try
            {
                var produto = _produtoRepositorio.BuscarPorId(entidade.Id);
                produto.Atualizar(entidade.Id, entidade.Nome, entidade.Preco, entidade.TipoPromocao);

                _produtoRepositorio.Atualizar(produto);

                return new ProdutoConsultaResultado(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
         }
    }
}

