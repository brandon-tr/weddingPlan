using System;
using System.ComponentModel.DataAnnotations;

namespace weddingPlan.Models
{
    public class WeddingReg
    {
        [Key]
        public int weddingId { get; set; }

        [Required]
        public DateTime date { get; set; }

        public DateTime createdAt { get; set; }

        [Required]
        public string wedderOne { get; set; }

        [Required]
        public string wedderTwo { get; set; }

        [Required]
        public string address { get; set; }
    }
}