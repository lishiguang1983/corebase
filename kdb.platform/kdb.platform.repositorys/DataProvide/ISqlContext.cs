using PetaPoco.NetCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace kdb.platform.repositorys.DataProvide
{
    public interface ISqlContext
    {
        Database DataBase { get; }

        void Dispose();
    }
}
