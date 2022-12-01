using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Exercise_3_Games.Models;

namespace Exercise_3_Games.Controllers;

public class GameController : Controller
{
    private readonly ILogger<GameController> _logger;

    public GameController(ILogger<GameController> logger)
    {
        _logger = logger;
    }

    //default view
    public IActionResult all()
    {
        var gamesRepo = new VideoGameRepository();
        return View(gamesRepo);
    }

    /* select through the video game repo.Games
        * get the one with the id]
        * return it to the view
     */

    public IActionResult game(string id)
    {
        HashSet<VideoGame> VideGameList = new VideoGameRepository().VideoGames;
        IEnumerable<VideoGame> targetGame = VideGameList.Where(game => game.Title == id);
        VideoGame result = targetGame.First();
        return View(result);
    }
}

