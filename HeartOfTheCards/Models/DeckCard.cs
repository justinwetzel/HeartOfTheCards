﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeartOfTheCards.Models
{
    public class DeckCard
    {
        [Key]
        public int Id { get; set; }
        public int DeckId { get; set; }
        public int CardId { get; set; }

        [ForeignKey("DeckId")]
        public virtual Deck Deck { get; set; }
        [ForeignKey("CardId")]
        public virtual Card Card { get; set; }
    }
}