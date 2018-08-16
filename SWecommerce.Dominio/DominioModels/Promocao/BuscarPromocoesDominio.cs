using SWecommerce.Dominio.Entidades;
using SWecommerce.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio
{
    public class BuscarPromocoesDominio : IConsulta
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public EPromocaoStatus Status { get; set; }
        public ETipoPromocao TipoPromocao { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}

