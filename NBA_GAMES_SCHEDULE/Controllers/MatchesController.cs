using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBA_GAMES_SCHEDULE.Models;


namespace NBA_GAMES_SCHEDULE.Controllers
{
    public class MatchesController : Controller
    {
        private readonly MVCDBcontext _context;

        public MatchesController(MVCDBcontext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UpcomingMatches()
        {
            var today = DateTime.Today;
            var nextWeek = today.AddDays(7);

            var upcomingMatches = await _context.Matches
                .Where(m => m.Date >= today && m.Date <= nextWeek)
                .OrderBy(m => m.Date)
                .ThenBy(m => m.Time)
                .ToListAsync();
            Match previousMatch = null;
            var filteredMatches = new List<Match>();

            foreach (var match in upcomingMatches)
            {
                if (previousMatch == null || (match.HomeTeamId != previousMatch.AwayTeamId || match.HomeTeamId != previousMatch.AwayTeamId))
                {
                    filteredMatches.Add(match);
                }
                previousMatch = match;
            }


            return View(filteredMatches);
        }

        public IActionResult ContactMe()
        {
            return View();
        }

    }
}
