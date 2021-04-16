using System.Collections.Generic;
using database_monitoring.Data;
using database_monitoring.Models;
using Microsoft.AspNetCore.Mvc;

namespace database_monitoring.Controllers {

    [Route("api/databaseservers")]
    [ApiController]
    public class DatabaseServersController : ControllerBase {
        
        private readonly IDatabaseServerRepo _repository;
        public DatabaseServersController(IDatabaseServerRepo repository)
        {
            _repository = repository;   
        }

        [HttpGet]
        public ActionResult <IEnumerable<DatabaseServer>> GetAllDatabaseServer(){
            var DatabaseServerItems = _repository.GetAllDatabaseServers();
            return Ok(DatabaseServerItems);
        }

        [HttpGet("{id}")]
        public ActionResult <DatabaseServer> GetDatabaseServerById(int id){
            var DatabaseServerItem = _repository.GetDatabaseServerById(id);
            return Ok(DatabaseServerItem);
        }
    }
}