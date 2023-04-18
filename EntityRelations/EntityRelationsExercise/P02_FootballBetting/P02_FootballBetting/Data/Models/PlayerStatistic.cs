using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        [Required]
        public int ScoredGoals { get; set; }
        [Required]
        public int Assists { get; set; }
        [Required]
        public int MinutesPlayed { get; set; }
    }
    //•	PlayerStatistic – GameId, PlayerId, ScoredGoals, Assists, MinutesPlayed
}
