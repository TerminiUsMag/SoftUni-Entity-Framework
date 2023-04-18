using P02_FootballBetting.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Team
    {
        [Key]
        [Column("TeamId")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string LogoUrl { get; set; } = null!;
        [Required]
        [MaxLength(3)]
        public string Initials { get; set; } = null!;
        [Required]
        public decimal Budget { get; set; }
        
        [ForeignKey(nameof(PrimaryKitColor))]
        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; } = null!;
        
        [ForeignKey(nameof(SecondaryKitColor))]
        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; } = null!;
        
        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public Town Town { get; set; } = null!;
    }
    //Team – TeamId, Name, LogoUrl, Initials(JUV, LIV, ARS…), Budget, PrimaryKitColorId, SecondaryKitColorId, TownId
}
