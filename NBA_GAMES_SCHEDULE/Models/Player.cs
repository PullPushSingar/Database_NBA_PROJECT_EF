using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBA_GAMES_SCHEDULE.Models
{
    [Table("Players")]
    public partial class Player
    {
        public int PlayerId { get; set; }
        public int? TeamId { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Nationality { get; set; }

        public  Team Team { get; set; }
    }
}
