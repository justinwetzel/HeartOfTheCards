using HeartOfTheCards.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HeartOfTheCards.Controllers
{
    [RoutePrefix("api/DeckCards")]
    public class DeckCardsController : ApiController
    {
        private HeartOfTheCardsContext database = new HeartOfTheCardsContext();

        [Route("AddCard")]
        public IHttpActionResult PostAddCardToDeck(int cardId, int deckId)
        {
            var deckCard = new DeckCard();
            deckCard.CardId = cardId;
            deckCard.DeckId = deckId;
            database.DeckCards.Add(deckCard);
            database.SaveChanges();
            return Ok();
        }

        [Route("DeleteCard")]
        public IHttpActionResult DeleteCardFromDeck(int cardId, int deckId)
        {
            var deletedCard = database.DeckCards.SingleOrDefault(x => x.CardId == cardId && x.DeckId == deckId);
            database.DeckCards.Remove(deletedCard);
            database.SaveChanges();
            return Ok();
        }

        [Route("ListCards")]
        public IHttpActionResult GetCardsByDeckId(int deckId)
        { 
            var result = database.DeckCards
                .Include(z => z.Card)
                .Where(x => x.DeckId == deckId)
                .Select(w => w.Card)
                .ToList();

            return Ok(result);
        }
    }
}
