using System;
using System.Collections.Generic;

namespace CannabisWeb.Models
{
    public partial class User
    {
        public User()
        {
            Types = new HashSet<Types>();
        }

        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Types> Types { get; set; }
    }
}
