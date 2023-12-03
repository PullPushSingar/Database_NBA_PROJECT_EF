using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBA_GAMES_SCHEDULE.Models
{
    [Table("Matches") ]
    public partial class Match
    {
        public int MatchId { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public string? Location { get; set; }
        public int? HomeTeamId { get; set; }
        [ForeignKey("HomeTeamId")]
        public virtual Team HomeTeam { get; set; }

        public int? AwayTeamId { get; set; }
        [ForeignKey("AwayTeamId")]
        public virtual Team AwayTeam { get; set; }





    }
}
