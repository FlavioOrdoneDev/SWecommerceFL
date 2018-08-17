using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWecommerce.Dominio.Enums;

namespace SWecommerce.Dominio
{
    public class PromocaoFactory : IPromocaoFactory
    {
        public IPromocaoStrategy BuscarTipoPromocao(ETipoPromocao tipoPromocao)
        {
            try
            {
                IPromocaoStrategy promocao;

                switch (tipoPromocao)
                {
                    case ETipoPromocao.Promocao_x_Produtos_por_y_Reais:
                        promocao = new PromocaoLeve3ProdutosPague10ReaisStrategy();
                        break;  
                    case ETipoPromocao.Promocao_Compre_x_Produtos_Leve_y:
                        promocao = new PromocaoCompre1Leve2Strategy();
                        break; 
                    case ETipoPromocao.SemPromocao:
                        promocao = new ProdutoSemPromocaoStrategy();
                        break;
                    default:
                        throw new NotImplementedException();
                }

                return promocao;

            }
            catch (Exception ex)
            {
                throw ex;
            }
                        
        }
    }
}
