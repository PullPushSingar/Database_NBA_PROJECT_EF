using Microsoft.AspNetCore.Mvc;

namespace NBA_GAMES_SCHEDULE.Models
{
    public class UserMessage
    {
        public int UserMessageId { get; set; } 
        public string Email { get; set; }
        public string Nick { get; set; }
        public string Message { get; set; }

        
    }
}

