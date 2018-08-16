using SWecommerce.Dominio.Entidades;
using SWecommerce.Dominio.Enums;
using System;
using System.Collections.Generic;

namespace SWecommerce.Dominio
{
    public class PromocaoDominio : IComando
    {
        public PromocaoDominio()
        {
            Produtos = new List<Produto>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public EPromocaoStatus Status { get; set; }
        public ETipoPromocao TipoPromocao { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
