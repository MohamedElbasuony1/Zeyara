namespace Models
{
    public class UserToken
    {
        public string TokenNumber { get; set; }
        public int Usr_Id { get; set; }
        public User User { get; set; }
    }
}
