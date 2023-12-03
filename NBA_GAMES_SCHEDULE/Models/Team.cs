using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBA_GAMES_SCHEDULE.Models
{
    [Table("Teams")]
    public partial class Team
    {

 

        public int TeamId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Coach { get; set; }

        public ICollection<Player> Players { get; set; }

        public ICollection<Match> HomeMatches { get; set; }
        public ICollection<Match> AwayMatches { get; set; }


        [NotMapped]
        public string ImagePath => $"/images/teams/{TeamId}.png";

    }

 
}
