using SWecommerce.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio
{
    public class PromocaoLeve3ProdutosPague10ReaisStrategy : IPromocaoStrategy
    {
        public ItemPedidoResultado CalcularPromocao(Produto produto, int quantidade)
        {
            try
            {
                var resultadoFinal = new ItemPedidoResultado();
                decimal valor = 10.00M;

                if (quantidade < 3)
                {
                    var produtos = 3 - quantidade;
                    resultadoFinal.Total = quantidade * produto.Preco;
                    resultadoFinal.Mensagem = "Adicione mais " + produtos + " produto(s) e aproveite a promoção: 3 por 10 Reais.";
                }
                else
                {
                    var media = (double)quantidade / (double)3;
                    int inteiro = (int)media;
                    int produtosPromocao = inteiro * 3;
                    int produtosRestantes = quantidade - produtosPromocao;
                    resultadoFinal.Total = inteiro * valor;
                    resultadoFinal.Total = resultadoFinal.Total + (produtosRestantes * produto.Preco);
                    resultadoFinal.Mensagem = "Adicionada(s) " + inteiro + " promoção(ões) e " + produtosRestantes + " produto(s) avulso(s).";
                }
                resultadoFinal.Preco = produto.Preco;
                resultadoFinal.Quantidade = quantidade;
                return resultadoFinal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
