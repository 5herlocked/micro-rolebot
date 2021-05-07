using System;
using System.Linq;
using System.Collections.Generic;
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

        public static async void AddRoleWatchList(List<RoleWatch> rolesBeingWatched)
        {
            throw new NotImplementedException();
        }
    }
}