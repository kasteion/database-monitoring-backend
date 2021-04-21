using AutoMapper;
using database_monitoring.Dtos;
using database_monitoring.Models;

namespace database_monitoring.Profiles {
    public class DatabaseServerProfile : Profile {
        public DatabaseServerProfile()
        {
            CreateMap<DatabaseServer, DatabaseServerReadDto>();
            CreateMap<DatabaseServerCreateDto, DatabaseServer>();
            CreateMap<DatabaseServerUpdateDto, DatabaseServer>();
            CreateMap<DatabaseServer, DatabaseServerUpdateDto>();
        }
    }
}