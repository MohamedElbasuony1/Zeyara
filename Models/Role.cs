using System.Collections.Generic;

namespace Models
{
    public class Role : Entity
    {
        public string Role_Name { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
