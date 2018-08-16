using SWecommerce.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWecommerce.Dominio
{
    public interface IPromocaoFactory
    {
        IPromocaoStrategy BuscarTipoPromocao(ETipoPromocao tipoPromocao);
    }
}
