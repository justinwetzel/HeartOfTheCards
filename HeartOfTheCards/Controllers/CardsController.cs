using HeartOfTheCards.DTO;
using HeartOfTheCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HeartOfTheCards.Controllers
{
    [RoutePrefix("api/Cards")]
    public class CardsController : ApiController
    {
        private HeartOfTheCardsContext database = new HeartOfTheCardsContext();

        [Route("AllCards")]
        public IHttpActionResult GetAllCards()
        {
            var result = database.Cards.Where(x => x.IsActive == true).ToList();
            return Ok(result);
        }

        [Route("Card")]
        public IHttpActionResult GetCardById(int cardId)
        {
            var result = database.Cards.SingleOrDefault(x => x.Id == cardId);
            return Ok(result);
        }

        [Route("DeleteCard")]
        public IHttpActionResult PostDeleteCardById(int cardId)
        {
            var card = database.Cards.SingleOrDefault(x => x.Id == cardId);
            card.IsActive = false;

            database.SaveChanges();
            return Ok();
        }

        [Route("SaveCard")]
        public IHttpActionResult PostSaveCard([FromBody]CardDTO card)
        {
            if (card.Id == 0)
            {
                //new card
                var newCard = new Card();
                newCard.Name = card.Name;
                newCard.Attack1 = card.Attack1;
                newCard.Attack2 = card.Attack2;
                newCard.Hp = card.Hp;
                newCard.ElementId = card.ElementId;
                newCard.IsActive = card.IsActive;
                database.Cards.Add(newCard);
            }
            else
            {
                //updating existing card
                var existingCard = database.Cards.SingleOrDefault(x => x.Id == card.Id);
                existingCard.Name = card.Name;
                existingCard.Attack1 = card.Attack1;
                existingCard.Attack2 = card.Attack2;
                existingCard.Hp = card.Hp;
                existingCard.ElementId = card.ElementId;
                existingCard.IsActive = card.IsActive;
            }

            database.SaveChanges();
            return Ok();
        }

        [Route("SearchCards")]
        public IHttpActionResult GetCardsBySearchTerm(string searchTerm)
        {
            var result = database.Cards
                .Where(x => x.Name.Contains(searchTerm)
                        || x.Attack1.Contains(searchTerm) 
                        || x.Attack2.Contains(searchTerm)
                        || x.Element.Value.Contains(searchTerm))
                .ToList();
            return Ok(result);
        }
    }
}
