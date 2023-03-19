using eCInema.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public UserRole UserRole { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}
