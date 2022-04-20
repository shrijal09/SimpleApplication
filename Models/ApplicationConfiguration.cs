using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ApplicationConfiguration
    {
        [Key]
        public int ID { get; set; }
        [StringLength(12)]
        public string ApplicationCode { get; set; }
        public int OrganizationID { get; set; }
        public int ConfigurationDefinitionID { get; set; }
        [StringLength(256)]
        public string ConfigurationValue { get; set; }
        public DateTime? DisabledDateTime { get; set; }
    }
}
