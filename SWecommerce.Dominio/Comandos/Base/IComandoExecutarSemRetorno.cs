using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio
{
    public interface IComandoExecutarSemRetorno<T> where T : IComando
    {
        void Executar(Guid id);
    }
}
