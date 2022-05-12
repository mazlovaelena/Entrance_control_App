using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Entrance_Control_App.Models
{
    public class LoginViewModel
    {
        public List<User> User { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
