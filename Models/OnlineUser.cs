namespace Models
{
    public class OnlineUser
    {
        public int Usr_Id { get; set; }
        public string ConnectionId { get; set; }
        public User User { get; set; }
    }
}
