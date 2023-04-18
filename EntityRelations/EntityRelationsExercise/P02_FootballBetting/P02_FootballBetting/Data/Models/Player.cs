using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        [Key]
        [Column("PlayerId")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int SquadNumber { get; set; }
        [Required]
        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }
        public Position Position { get; set; } = null!;
        [Required]
        public bool IsInjured { get; set; }
    }
    //•	Player – PlayerId, Name, SquadNumber, TeamId, PositionId, IsInjured
}
