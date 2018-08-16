using SWecommerce.Dominio;
using SWecommerce.Dominio.Entidades;
using System;

namespace SWecommerce.Dominio.Resultados
{
    public class ProdutoConsultaResultado : IConsulta
    {
        public ProdutoConsultaResultado(Produto produto)
        {
            Nome     = produto.Nome;
            Preco    = produto.Preco;
        }

        public Guid Id { get; private set; }

        public string Nome { get; private set; }

        public decimal Preco { get; private set; }
    }
}
