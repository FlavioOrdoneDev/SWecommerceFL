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
                IPromocaoStrategy calcular;

                if (tipoPromocao == ETipoPromocao.Promocao_Compre_x_Produtos_Leve_y)
                {
                    return calcular = new PromocaoCompre1Leve2Strategy();
                }
                else if (tipoPromocao == ETipoPromocao.Promocao_x_Produtos_por_y_Reais)
                {
                    return calcular = new PromocaoLeve3ProdutosPague10ReaisStrategy();
                }
                else
                {
                    return calcular = new ProdutoSemPromocaoStrategy();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
                        
        }
    }
}
