using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entrance_Control_App.Models
{
    public class TurnstilesViewModel
    {
        public List<Turnstile> Turnstiles { get; set; }
        public int ID_Type { get; set; }
        [Required(ErrorMessage = "Заполните это поле")]
        public string TypeName { get; set; }
    }
}
