namespace VideoGamesASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Videogames
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string publisher { get; set; }


        public int year { get; set; }

        public int genre { get; set; }
        public Genre Genre
        {
            get { return (Genre)genre; }
            set { genre = (int)value; }
        }

        public int platform { get; set; }
        public Platform Platform
        {
            get { return (Platform)platform; }
            set { platform = (int)value; }
        }
        public int score { get; set; }

        public bool online { get; set; }

        public int pegi { get; set; }
        public PEGI Pegi
        {
            get { return (PEGI)pegi; }
            set { pegi = (int)value; }
        }

       

        public static List<Videogames> GetRankings()
        {
            List<Videogames> games = new List<Videogames>();
            GameContext context = new GameContext();
            try
            {
                games = context.Videogames.OrderByDescending(x=>x.score).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return games;
        }

        public static Videogames GetGameByString(string dataSeach)
        {
            Videogames game = null;
            try
            {
                GameContext context = new GameContext();
                game = context.Videogames.Where(x => x.name.Contains(dataSeach)).SingleOrDefault();

            }
            catch (Exception)
            {

                throw;
            }
            return game;
        }

        public static List<Videogames> GetGames()
        {
            List<Videogames> games = new List<Videogames>();
            GameContext context = new GameContext();
            try
            {
                games = context.Videogames.OrderBy(x => x.name).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return games;
        }

        public static Videogames GetGame(int id)
        {
            Videogames game = null;
            try
            {
                GameContext context = new GameContext();
                game = context.Videogames.Where(x => x.id == id).SingleOrDefault();

            }
            catch (Exception)
            {

                throw;
            }
            return game;
        }

        public void Update()
        {
            try
            {
                GameContext context = new GameContext();
                context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void Save()
        {
            bool create = this.id == 0;
            try
            {
                GameContext context = new GameContext();

                context.Entry(this).State = System.Data.Entity.EntityState.Added;


                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
