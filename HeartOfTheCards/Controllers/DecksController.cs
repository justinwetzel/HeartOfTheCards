using System.Data;
using System.Linq;
using System.Web.Http;
using HeartOfTheCards.Models;
using HeartOfTheCards.DTO;

namespace HeartOfTheCards.Controllers
{
    [RoutePrefix("api/Decks")]
    public class DecksController : ApiController
    {
        private HeartOfTheCardsContext database = new HeartOfTheCardsContext();

        [Route("AllDecks")]
        public IHttpActionResult GetAllDecks()
        {
            var result = database.Decks.Where(x => x.IsActive == true).ToList();
            return Ok(result);
        }

        [Route("Deck")]
        public IHttpActionResult GetDeckById(int deckId)
        {
            var result = database.Decks.SingleOrDefault(x => x.Id == deckId);
            return Ok(result);
        }

        [Route("DeleteDeck")]
        public IHttpActionResult PostDeleteDeckById(int deckId)
        {
            var deck = database.Decks.SingleOrDefault(x => x.Id == deckId);
            deck.IsActive = false;
            
            database.SaveChanges();
            return Ok();
        }

        [Route("SaveDeck")]
        public IHttpActionResult PostSaveDeck([FromBody]DeckDTO deck)
        {
            if(deck.Id == 0)
            {
                //new deck
                var newDeck = new Deck();
                newDeck.Id = deck.Id;
                newDeck.Name = deck.Name;
                newDeck.IsActive = deck.IsActive;
                newDeck.UserId = deck.UserId;
                database.Decks.Add(newDeck);
            }
            else
            {
                //updating existing deck
                var existingDeck = database.Decks.SingleOrDefault(x => x.Id == deck.Id);
                existingDeck.Name = deck.Name;
                existingDeck.UserId = deck.UserId;
                existingDeck.IsActive = deck.IsActive;
            }

            database.SaveChanges();
            return Ok();
        }

        [Route("SearchDecks")]
        public IHttpActionResult GetDeckBySearchTerm(string searchTerm)
        {
            var result = database.Decks.Where(x => x.Name.Contains(searchTerm)).ToList();
            return Ok(result);
        }
    }
}