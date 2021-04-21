using System.ComponentModel.DataAnnotations;

namespace database_monitoring.Models {
    public class DatabaseServer {

        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(253)]
        public string ServerName { get; set; }

        [Required]
        public string DatabaseVersion { get; set; }
    }
}