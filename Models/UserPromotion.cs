namespace Models
{
    public class UserPromotion
    {
        public int User_Id { get; set; }
        public int Prom_Id { get; set; }
        public User User { get; set; }
        public Promotion Promotion { get; set; }
    }
}
