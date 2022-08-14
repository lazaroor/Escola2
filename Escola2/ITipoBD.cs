using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola2
{
    public interface ITipoBD
    {
        IDb TipoDb(string nomeDb);
    }
}
