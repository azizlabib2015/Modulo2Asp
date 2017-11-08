using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGamesASP.Models;

namespace VideoGamesASP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Videogames> games = Videogames.GetGames();

            return View(games);
        }

        //GET : Home/VER

        public ActionResult Ver(int id = 0)
        {
            if (id == 0)
            {
                return Redirect("~/home/");
            }
            else
            {
                Videogames game = Videogames.GetGame(id);
                return View(game);
            }
        }
        public ActionResult Crear()
        {
            Videogames game = new Videogames();
            return View("~/Views/Home/GameForm.cshtml", game);
        }
        public ActionResult Editar(int id = 0)
        {
            Videogames game = Videogames.GetGame(id);
            if (game == null)
            {
                return Redirect("~/Home/");
            }
            else
            {
                return View("~/Views/Home/GameForm.cshtml", game);
            }
        }
        public ActionResult ranking()
        {
            List<Videogames> games = Videogames.GetRankings();

            return View(games);
        }

        public ActionResult Buscar(Videogames data)
        {
            if (data.name != "")
            {
                Videogames game = Videogames.GetGameByString(data.name);
                return View("Ver", game);
            }
            else
            {
                return View("SearchGame");
            }


        }
        public ActionResult SearchGame()
        {
            Videogames game =new Videogames();
            return View(game);
        }
        public ActionResult guardar(Videogames game)
        {
            //guardar datos en db
            game.Update();
            //Rediccionar a una vista de ver
            return Redirect("~/");
        }
    }
}