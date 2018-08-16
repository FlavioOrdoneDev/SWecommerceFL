using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio
{
    public class ComandoCalcularPromocao : IComandoExecutar<CalcularPromocaoEntrada>
    {
        public IPromocaoFactory _promocaoFactory;

        public ComandoCalcularPromocao(IPromocaoFactory promocaoFactory)
        {
            _promocaoFactory = promocaoFactory;
        }

        public IConsulta Executar(CalcularPromocaoEntrada entidade)
        {
            try
            {
                var resultados = new ItemPedidoResultado();

                var resultado = _promocaoFactory.BuscarTipoPromocao(entidade.TipoPromocao);
                return resultado.CalcularPromocao(entidade.Produto, entidade.Quantidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }
    }
}
