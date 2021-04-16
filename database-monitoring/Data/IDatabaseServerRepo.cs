using System.Collections.Generic;
using database_monitoring.Models;

namespace database_monitoring.Data {
    public interface IDatabaseServerRepo
    {
        IEnumerable<DatabaseServer> GetAllDatabaseServers();

        DatabaseServer GetDatabaseServerById(int id);
    }   
}