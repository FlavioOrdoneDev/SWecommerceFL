using SWecommerce.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio
{
    public class PromocaoCompre1Leve2Strategy : IPromocaoStrategy
    {
        public ItemPedidoResultado CalcularPromocao(Produto produto, int quantidade)
        {
            try
            {
                var resultadoFinal = new ItemPedidoResultado();

                resultadoFinal.Quantidade = quantidade * 2;
                resultadoFinal.Total = quantidade * produto.Preco;
                resultadoFinal.Mensagem = "Adicionada(s) " + quantidade + " promoção(ões).";

                resultadoFinal.Preco = produto.Preco;
                return resultadoFinal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
