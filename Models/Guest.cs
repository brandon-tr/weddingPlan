namespace weddingPlan.Models
{
    public class Guest
    {
        public int guestId {get; set;}

        public int userId {get; set;}
        public User user {get; set;}
        public int weddingId {get; set;}
        public Wedding wedding {get; set;}
    }
}