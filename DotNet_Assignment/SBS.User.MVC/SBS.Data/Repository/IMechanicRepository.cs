using SBS.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Data.Repository
{
    public interface IMechanicRepository
    {
        bool AddMechanic(tbl_Mechanics model);
        IQueryable<tbl_Mechanics> getMechanics();
    }
}
