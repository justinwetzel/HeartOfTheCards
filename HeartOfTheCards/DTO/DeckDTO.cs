﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeartOfTheCards.DTO
{
    public class DeckDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }
        public bool IsActive { get; set; }
    }
}