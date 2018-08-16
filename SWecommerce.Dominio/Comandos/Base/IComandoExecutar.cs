using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio
{
    public interface IComandoExecutar<T> where T : IComando
    {
        IConsulta Executar(T command);
    }
}

