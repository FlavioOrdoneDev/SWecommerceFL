using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio
{
    public interface IComandoExecutarPorId<T> where T : IComando
    {
        IComando Executar(Guid id);
    }
}
