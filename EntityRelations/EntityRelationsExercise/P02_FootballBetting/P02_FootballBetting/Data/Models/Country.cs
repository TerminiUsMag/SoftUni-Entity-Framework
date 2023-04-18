using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Country
    {
        [Key]
        [Column("CountryId")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
    //•	Country – CountryId, Name
}
