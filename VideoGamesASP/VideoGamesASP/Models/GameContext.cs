namespace VideoGamesASP.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GameContext : DbContext
    {
        public GameContext()
            : base("name=GamesContext")
        {
        }

        public virtual DbSet<Videogames> Videogames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Videogames>()
                .Property(e => e.publisher)
                .IsFixedLength();
        }
    }
}
