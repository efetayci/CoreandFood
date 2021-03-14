
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreandFood.Data.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [StringLength(20)]
        public string Pasword { get; set; }
        [StringLength(1)]
        
        public string AdminRole { get; set; }
    }
}
