using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Bet
    {
        [Key]
        [Column("BetId")]
        public int Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int Prediction { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;


    }
    //•	Bet – BetId, Amount, Prediction, DateTime, UserId, GameId
}
