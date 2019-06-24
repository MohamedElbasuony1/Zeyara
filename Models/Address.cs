namespace Models
{
    public class Address:Entity
    {
        public string AddressType { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string street { get; set; }
        public int Usr_Id { get; set; }
        public User User { get; set; }
    }
}
