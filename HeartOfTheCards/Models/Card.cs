﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeartOfTheCards.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Hp { get; set; }
        public string Attack1 { get; set; }
        public string Attack2 { get; set; }
        public int? ElementId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("ElementId")]
        public virtual Element Element { get; set; }
    }
}