using System;
using System.Collections.Generic;
using System.Linq;
using database_monitoring.Models;

namespace database_monitoring.Data {
    public class SqlDatabaseServerRepo : IDatabaseServerRepo
    {
        private readonly DatabaseServerContext _context;

        public SqlDatabaseServerRepo(DatabaseServerContext context)
        {
            _context = context;
        }

        public void CreateDatabaseServer(DatabaseServer dbserver)
        {
            if (dbserver == null){
                throw new ArgumentNullException(nameof(dbserver));
            }
            _context.DatabaseServers.Add(dbserver);
        }

        public IEnumerable<DatabaseServer> GetAllDatabaseServers()
        {
            return _context.DatabaseServers.ToList();
        }

        public DatabaseServer GetDatabaseServerById(int id)
        {
            return _context.DatabaseServers.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}