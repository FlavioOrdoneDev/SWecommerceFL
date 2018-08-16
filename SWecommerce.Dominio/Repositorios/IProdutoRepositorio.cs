using SWecommerce.Dominio;
using SWecommerce.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio
{
    public interface IProdutoRepositorio
    {
        Produto BuscarPorId(Guid id);

        void Inserir(Produto produto);

        void Atualizar(Produto produto);

        void Excluir(Guid id);

        List<BuscarProdutosDominio> BuscarProdutos();
    }
}
