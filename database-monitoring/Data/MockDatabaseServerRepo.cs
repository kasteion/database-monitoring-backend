using System;
using System.Collections.Generic;
using database_monitoring.Models;

namespace database_monitoring.Data {
    public class MockDatabaseServerRepo : IDatabaseServerRepo
    {
        private List<DatabaseServer> servers = new List<DatabaseServer> {
            new DatabaseServer { Id = 0, ServerName="SuperServer", DatabaseVersion="Best Database In The World Ultimate Edition"},
            new DatabaseServer { Id = 1, ServerName="NotSoSuperServer", DatabaseVersion="Not Best Database In The World Developer Edition"},
            new DatabaseServer { Id = 2, ServerName="MehServer", DatabaseVersion="Meh Database Standard Edition"}
        };
        public void CreateDatabaseServer(DatabaseServer dbServer)
        {
            if (dbServer == null){
                throw new ArgumentNullException(nameof(dbServer));
            }
            dbServer.Id = servers.Count;
            servers.Add(dbServer);
        }

        public void DeleteDatabaseServer(DatabaseServer dbServer)
        {
            if (dbServer == null) {
                throw new ArgumentNullException(nameof(dbServer));
            }
            servers.Remove(dbServer);
        }

        public IEnumerable<DatabaseServer> GetAllDatabaseServers()
        {
            return servers;
        }

        public DatabaseServer GetDatabaseServerById(int id)
        {
            var DatabaseServer = servers.Find(s => s.Id == id);
            return DatabaseServer;
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void UpdateDatabaseServer(DatabaseServer dbServer)
        {
            servers.ForEach(s => {
                if (s.Id == dbServer.Id)
                {
                    s.ServerName = dbServer.ServerName;
                    s.DatabaseVersion = dbServer.DatabaseVersion;
                }
            });

        }
    }
}