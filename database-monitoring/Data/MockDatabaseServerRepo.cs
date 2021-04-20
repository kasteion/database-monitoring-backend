using System.Collections.Generic;
using database_monitoring.Models;

namespace database_monitoring.Data {
    public class MockDatabaseServerRepo : IDatabaseServerRepo
    {
        public void CreateDatabaseServer(DatabaseServer dbserver)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteDatabaseServer(DatabaseServer dbServer)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DatabaseServer> GetAllDatabaseServers()
        {
            var DatabaseServers = new List<DatabaseServer> {
                new DatabaseServer { Id = 0, ServerName="SuperServer", DatabaseVersion="Best Database In The World Ultimate Edition"},
                new DatabaseServer { Id = 1, ServerName="NotSoSuperServer", DatabaseVersion="Not Best Database In The World Developer Edition"},
                new DatabaseServer { Id = 0, ServerName="MehServer", DatabaseVersion="Meh Database Standard Edition"}
            };
            return DatabaseServers;
        }

        public DatabaseServer GetDatabaseServerById(int id)
        {
            var DatabaseServer = new DatabaseServer { Id = id, ServerName="SuperServer", DatabaseVersion="Best Database In The World Ultimate Edition"};
            return DatabaseServer;
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateDatabaseServer(DatabaseServer dvServer)
        {
            throw new System.NotImplementedException();
        }
    }
}