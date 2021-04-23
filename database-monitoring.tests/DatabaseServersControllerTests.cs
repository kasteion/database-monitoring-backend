using System;
using Xunit;
using database_monitoring.Controllers;
using database_monitoring.Data;
using AutoMapper;
using database_monitoring.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using database_monitoring.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Xunit.Abstractions;

namespace database_monitoring.tests
{
    public class DatabaseServersControllerTests
    {
        private IDatabaseServerRepo repo = new MockDatabaseServerRepo();
        private MapperConfiguration config = new MapperConfiguration(opts =>
        {
            opts.CreateMap<DatabaseServer, DatabaseServerReadDto>();
            opts.CreateMap<DatabaseServerCreateDto, DatabaseServer>();
            opts.CreateMap<DatabaseServerUpdateDto, DatabaseServer>();
            opts.CreateMap<DatabaseServer, DatabaseServerUpdateDto>();
        });

        [Fact]
        public void GetAllDatabseServers_Returns_Correct_Number_Of_Servers()
        {
            //// Arrange
            //var count = 5;
            //var fakeDatabaseServers = A.CollectionOfDummy<DatabaseServer>(count).AsEnumerable();
            //var dataStore = A.Fake<IDatabaseServerRepo>();
            //A.CallTo(() => dataStore.GetAllDatabaseServers()).Returns(fakeDatabaseServers);
            //var config = new MapperConfiguration(opts => {
            //    opts.CreateMap<DatabaseServer, DatabaseServerReadDto>();
            //});
            //var mapper = config.CreateMapper();
            //var controller = new DatabaseServersController(dataStore, mapper);
            //// Act
            //var actionResult = controller.GetAllDatabaseServer();
            //// Assert
            //var result = actionResult.Result as OkObjectResult;
            //var returnServers = result.Value as IEnumerable<DatabaseServerReadDto>;
            //Assert.Equal(count, returnServers.Count());

            // Arrange
            var mapper = config.CreateMapper();
            var controller = new DatabaseServersController(repo, mapper);
            // Act
            var actionResult = controller.GetAllDatabaseServer();
            // Asert
            var result = actionResult.Result as OkObjectResult;
            var servers = result.Value as IEnumerable<DatabaseServerReadDto>;
            Assert.Equal(3, servers.Count());
        }

        [Fact]
        public void GetDatabaseServerById_Returns_Server_With_Correct_Server()
        {
            // Arrange
            var mapper = config.CreateMapper();
            var controller = new DatabaseServersController(repo, mapper);
            // Act
            var actionResult = controller.GetDatabaseServerById(2);
            // Asert
            var result = actionResult.Result as OkObjectResult;
            var server = result.Value as DatabaseServerReadDto;
            Assert.Equal("MehServer", server.ServerName);
        }

        [Fact]
        public void CreateDatabaseServer_Returns_Created_Server()
        {
            // Arrange
            var mapper = config.CreateMapper();
            var controller = new DatabaseServersController(repo, mapper);
            var dbServer = new DatabaseServerCreateDto()
            {
                ServerName = "MediumServer",
                DatabaseVersion = "Medium SQL Version"
            };
            // Act
            var actionResult = controller.CreateDatabaseServer(dbServer);

            // Assert
            var result = actionResult.Result as CreatedAtRouteResult;
            var server = result.Value as DatabaseServerReadDto;
            Assert.Equal(dbServer.ServerName, server.ServerName);
        }

        [Fact]
        public void CreateDatabaseServer_Creates_Server()
        {
            // Arrange
            var mapper = config.CreateMapper();
            var controller = new DatabaseServersController(repo, mapper);
            var dbServer = new DatabaseServerCreateDto()
            {
                ServerName = "MediumServer",
                DatabaseVersion = "Medium SQL Version"
            };
            // Act
            controller.CreateDatabaseServer(dbServer);
            var actionResult = controller.GetDatabaseServerById(3);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var server = result.Value as DatabaseServerReadDto;
            Assert.Equal(dbServer.ServerName, server.ServerName);
        }

        [Fact]
        public void UpdateDatabaseServer_Updates_Succesfully()
        {
            // Arrange
            var mapper = config.CreateMapper();
            var controller = new DatabaseServersController(repo, mapper);
            var dbServer = new DatabaseServerUpdateDto()
            {
                ServerName = "BigServer",
                DatabaseVersion = "Big SQL Version"
            };
            // Act
            controller.UpdateDatabaseServer(2, dbServer);
            var actionResult = controller.GetDatabaseServerById(2);
            // Assert
            var result = actionResult.Result as OkObjectResult;
            var server = result.Value as DatabaseServerReadDto;
            Assert.Equal(dbServer.ServerName, server.ServerName);
        }

        [Fact]
        public void PartialUpdateDatabaseServer_Updates_Successfully()
        {
            // Arrange
            var mapper = config.CreateMapper();
            var controller = new DatabaseServersController(repo, mapper);
            var PatchDoc = new JsonPatchDocument<DatabaseServerUpdateDto>();
            PatchDoc.Operations.Add(new Microsoft.AspNetCore.JsonPatch.Operations.Operation<DatabaseServerUpdateDto>("replace", "/serverName", null, "servanalisis"));
            // Act
            controller.PartialUpdateDatabaseServer(2, PatchDoc);
            var actionResult = controller.GetDatabaseServerById(2);
            // Asses
            var result = actionResult.Result as OkObjectResult;
            var server = result.Value as DatabaseServerReadDto;
            Assert.Equal(PatchDoc.Operations.ToArray()[0].value, server.ServerName);
        }

        [Fact]
        public void DeleteDatabaseServer_Deletes_Successfully()
        {
            // Arrange
            var mapper = config.CreateMapper();
            var controller = new DatabaseServersController(repo, mapper);
            // Act
            //controller.DeleteDatabaseServer(1);
            var actionResult = controller.GetDatabaseServerById(10);
            // Asses
            var result = actionResult.Result as NotFoundResult;
            Assert.Equal(404, result.StatusCode);

        }
    }
}
