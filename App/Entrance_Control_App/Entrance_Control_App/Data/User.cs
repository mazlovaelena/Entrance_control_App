using System;
using System.Collections.Generic;

#nullable disable

namespace Entrance_Control_App.Models
{
    public partial class User
    {
        public int IdUser { get; set; }
        public UserRole UserRole { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
