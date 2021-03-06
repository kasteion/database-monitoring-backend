using System.Collections.Generic;
using AutoMapper;
using database_monitoring.Data;
using database_monitoring.Dtos;
using database_monitoring.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace database_monitoring.Controllers {

    [Route("api/databaseservers")]
    [ApiController]
    public class DatabaseServersController : ControllerBase {
        
        private readonly IDatabaseServerRepo _repository;
        private readonly IMapper _mapper;

        public DatabaseServersController(IDatabaseServerRepo repository, IMapper mapper)
        {
            _repository = repository;   
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<DatabaseServerReadDto>> GetAllDatabaseServer(){
            var DatabaseServerItems = _repository.GetAllDatabaseServers();
            return Ok(_mapper.Map<IEnumerable<DatabaseServerReadDto>>(DatabaseServerItems));
        }

        [HttpGet("{id}", Name="GetDatabaseServerById")]
        public ActionResult <DatabaseServerReadDto> GetDatabaseServerById(int id){
            var DatabaseServerItem = _repository.GetDatabaseServerById(id);
            if (DatabaseServerItem != null){
                return Ok(_mapper.Map<DatabaseServerReadDto>(DatabaseServerItem));
            } else {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult <DatabaseServerReadDto> CreateDatabaseServer(DatabaseServerCreateDto dbServer){
            var dbServerModel = _mapper.Map<DatabaseServer>(dbServer);
            _repository.CreateDatabaseServer(dbServerModel);
            _repository.SaveChanges();
            var dbServerReadDto = _mapper.Map<DatabaseServerReadDto>(dbServerModel);
            return CreatedAtRoute(nameof(GetDatabaseServerById), new { Id = dbServerReadDto.Id}, dbServerReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateDatabaseServer(int id, DatabaseServerUpdateDto dbServer){
            var dbServerFromRepo = _repository.GetDatabaseServerById(id);
            if (dbServerFromRepo == null){
                return NotFound();
            }
            _mapper.Map(dbServer, dbServerFromRepo);
            _repository.UpdateDatabaseServer(dbServerFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateDatabaseServer(int id, JsonPatchDocument<DatabaseServerUpdateDto> patchDoc){
            var dbServerFromRepo = _repository.GetDatabaseServerById(id);
            if (dbServerFromRepo == null){
                return NotFound();
            }

            var dbServerToPatch = _mapper.Map<DatabaseServerUpdateDto>(dbServerFromRepo);
            patchDoc.ApplyTo(dbServerToPatch, ModelState);
            if(!TryValidateModel(dbServerToPatch)){
                return ValidationProblem(ModelState);
            }

            _mapper.Map(dbServerToPatch, dbServerFromRepo);
            _repository.UpdateDatabaseServer(dbServerFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDatabaseServer(int id){
            var dbServerFromRepo = _repository.GetDatabaseServerById(id);
            if (dbServerFromRepo == null){
                return NotFound();
            }
            _repository.DeleteDatabaseServer(dbServerFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}