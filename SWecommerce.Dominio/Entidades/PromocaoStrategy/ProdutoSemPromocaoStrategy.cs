using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWecommerce.Dominio.Entidades;

namespace SWecommerce.Dominio
{
    public class ProdutoSemPromocaoStrategy : IPromocaoStrategy
    {      
        public ItemPedidoResultado CalcularPromocao(Produto produto, int quantidade)
        {
            try
            {
                var resultadoFinal = new ItemPedidoResultado();
                resultadoFinal.Total = quantidade * produto.Preco;
                resultadoFinal.Preco = produto.Preco;
                resultadoFinal.Mensagem = "Produto adicionado.";

                return resultadoFinal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}