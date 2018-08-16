using System;


namespace SWecommerce.Dominio
{
    public class ComandoExcluirProduto : IComandoExecutarSemRetorno<ProdutoDominio>
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ComandoExcluirProduto(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public void Executar(Guid id)
        {
            try
            {
                _produtoRepositorio.Excluir(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
