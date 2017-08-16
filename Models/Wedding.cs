using System;
using System.Collections.Generic;

namespace weddingPlan.Models
{
    public class Wedding
    {
        public int weddingId { get; set; }
        public int creatorId { get; set; }
        public User creator {get; set;}

        public DateTime date { get; set; }

        public DateTime createdAt { get; set; }

        public string wedderOne { get; set; }
        public string wedderTwo { get; set; }
        public string address { get; set; }

        public List<Guest> guests { get; set; }

        public Wedding()
        {
            guests = new List<Guest>();
        }
    }
}