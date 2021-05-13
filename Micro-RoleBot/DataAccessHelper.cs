using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Micro_RoleBot
{
    public class DataAccessHelper
    {
        private SQLiteConnection _db;

        public DataAccessHelper(string path)
        {
            _db = new SQLiteConnection(path);
            _db.CreateTable<RoleWatch>();
        }

        public int AddRoleWatchList(List<RoleWatch> rolesBeingWatched)
        {
            var valuesInserted = _db.InsertAll(rolesBeingWatched);

            return valuesInserted;
        }
    }
}