using Microsoft.AspNetCore.Mvc;
using System.Linq;
using NBA_GAMES_SCHEDULE.Models; // Użyj właściwej przestrzeni nazw
using Microsoft.EntityFrameworkCore;

public class TeamsController : Controller
{
    private readonly MVCDBcontext _context;

    public TeamsController(MVCDBcontext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var teams = _context.Teams.ToList();
        return View(teams);
    }



    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var team = await _context.Teams
            .Include(t => t.Players) 
            .FirstOrDefaultAsync(m => m.TeamId == id);

    

        if (team == null)
        {
            return NotFound();
        }

        return View(team);


    }

    public async Task<IActionResult> TeamMatches(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var team = await _context.Teams
            .Include(t => t.HomeMatches) 
            .FirstOrDefaultAsync(m => m.TeamId == id);



        if (team == null)
        {
            return NotFound();
        }

        return View(team);


    }





    }









