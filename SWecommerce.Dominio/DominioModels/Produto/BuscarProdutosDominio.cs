using SWecommerce.Dominio.Entidades;
using SWecommerce.Dominio.Enums;
using System;
using System.Collections.Generic;

namespace SWecommerce.Dominio
{
    public class BuscarProdutosDominio : IConsulta
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string NomePromocao { get; set; }
        public decimal Preco { get; set; }
        public ETipoPromocao TipoPromocao { get; set;}
    }
}
