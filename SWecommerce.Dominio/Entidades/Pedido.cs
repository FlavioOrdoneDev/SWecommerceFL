using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio.Entidades
{
    public class Pedido
    {
        private readonly IList<ItemPedido> _itens;

        public Pedido()
        {
            _itens = new List<ItemPedido>();
        }

        public IReadOnlyCollection<ItemPedido> Itens => _itens.ToArray();

    }
}
