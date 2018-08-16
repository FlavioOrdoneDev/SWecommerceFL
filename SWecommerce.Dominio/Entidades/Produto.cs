using SWecommerce.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio.Entidades
{
    public class Produto
    {
        protected Produto(){}

        public Produto(string nome, decimal preco, ETipoPromocao tipoPromocao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Preco = preco;
            TipoPromocao = tipoPromocao;
        }

        public Guid Id { get;set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public ETipoPromocao TipoPromocao { get; set; }


        public void Atualizar(Guid id,string nome, decimal preco, ETipoPromocao tipoPromocao)
        {
            Id           = id;
            Nome         = nome;
            Preco        = preco;
            TipoPromocao = tipoPromocao;
        }
    }
}
