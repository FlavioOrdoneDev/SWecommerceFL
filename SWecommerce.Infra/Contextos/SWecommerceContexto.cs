using SWecommerce.Dominio.Entidades;
using SWecommerce.Infra.Mapeamentos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Infra.Contextos
{
    public class SWecommerceContexto : DbContext
    {
        public SWecommerceContexto():base("CnnStr")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new ProdutoMap());
        }
    }
}
