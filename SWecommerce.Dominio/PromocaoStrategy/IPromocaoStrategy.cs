using SWecommerce.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio
{
    public interface IPromocaoStrategy
    {
        ItemPedidoResultado CalcularPromocao(Produto produto, int quantidade);
    }
}
