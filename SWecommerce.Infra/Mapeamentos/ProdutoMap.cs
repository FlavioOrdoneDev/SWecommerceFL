using SWecommerce.Dominio;
using SWecommerce.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Infra.Mapeamentos
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");
            HasKey(x => x.Id);
            Property(x => x.Nome).IsRequired().HasMaxLength(100);
            Property(x => x.Preco).IsRequired().HasColumnType("money");
            Property(x => x.TipoPromocao).IsOptional();

        }
    }
}
