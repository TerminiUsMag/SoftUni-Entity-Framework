using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Town
    {
        [Key]
        [Column("TownId")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
    }
    //•	Town – TownId, Name, CountryId
}
