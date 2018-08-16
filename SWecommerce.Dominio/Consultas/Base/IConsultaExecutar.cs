using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio
{
    public interface IConsultaExecutar<T> where T : IConsulta
    {
        IConsulta Executar(T command);
    }
}
