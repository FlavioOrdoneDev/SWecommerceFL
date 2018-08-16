using SWecommerce.Dominio.Entidades;
using SWecommerce.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio
{
    public class ProdutoDominio : IComando
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public ETipoPromocao TipoPromocao { get; set; }
    }
}
