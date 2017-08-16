using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace weddingPlan.Models
{
    public class User
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        // [InverseProperty("")]
        public List<Guest> Weddings { get; set; }

        public User()
        {
            Weddings = new List<Guest>();
        }
    }
}