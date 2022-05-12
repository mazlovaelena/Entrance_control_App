using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entrance_Control_App.Models
{
    public class UserViewModel
    {
        public List<User> Users { get; set; }
        public int IdUser { get; set; }
        public string UserRole { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
