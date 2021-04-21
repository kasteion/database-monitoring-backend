using System.ComponentModel.DataAnnotations;

namespace database_monitoring.Dtos {
    public class DatabaseServerUpdateDto {

        [Required]
        [MaxLength(253)]
        public string ServerName { get; set; }

        [Required]
        public string DatabaseVersion { get; set; }
    }
}