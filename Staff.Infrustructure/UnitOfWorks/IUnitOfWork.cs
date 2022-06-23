using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Infrustructure.UnitOfWorks
{
    public interface IUnitOfWork: IDisposable
    {
        void Save();
    }
}
