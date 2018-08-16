using SWecommerce.Dominio.Entidades;
using SWecommerce.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio
{
    public class CalcularPromocaoEntrada : IComando
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public ETipoPromocao TipoPromocao { get; set; }
    }
}
