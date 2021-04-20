using System.Collections.Generic;
using database_monitoring.Models;

namespace database_monitoring.Data {
    public interface IDatabaseServerRepo
    {
        bool SaveChanges();
        
        IEnumerable<DatabaseServer> GetAllDatabaseServers();

        DatabaseServer GetDatabaseServerById(int id);

        void CreateDatabaseServer(DatabaseServer dbserver);

        void UpdateDatabaseServer(DatabaseServer dbServer);

        void DeleteDatabaseServer(DatabaseServer dbServer);
    }   
}