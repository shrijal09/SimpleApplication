using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SSIS_Config
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ConfigurationFilter { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string ConfiguredValue { get; set; }
        
        [Column(TypeName = "nvarchar(255)")]
        public string PackagePath { get; set; }
        
        [Column(TypeName = "nvarchar(20)")]
        public string ConfiguredValueType { get; set; }
    }
}
