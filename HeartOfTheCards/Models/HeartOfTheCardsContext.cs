using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HeartOfTheCards.Models
{
    public class HeartOfTheCardsContext : DbContext
    {
    
        public HeartOfTheCardsContext() : base("name=HeartOfTheCardsConnectionString")
        {
            Database.SetInitializer<HeartOfTheCardsContext>(null);
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Deck> Decks { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<DeckCard> DeckCards { get; set; }
        public DbSet<Element> Elements { get; set; }
    }
}
