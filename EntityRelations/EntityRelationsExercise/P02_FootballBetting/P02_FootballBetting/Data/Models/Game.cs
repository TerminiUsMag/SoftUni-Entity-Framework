using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Game
    {
        [Key]
        [Column("GameId")]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; } = null!;
        [Required]
        public int HomeTeamGoals { get; set; }
        [Required]
        public int AwayTeamGoals { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public decimal HomeTeamBetRate { get; set; }
        [Required]
        public decimal AwayTeamBetRate { get; set; }
        [Required]
        public decimal DrawBetRate { get; set; }
        [Required]
        public int Result { get; set; }
    }
    //•	Game – GameId, HomeTeamId, AwayTeamId, HomeTeamGoals, AwayTeamGoals, DateTime, HomeTeamBetRate, AwayTeamBetRate, DrawBetRate, Result
}
