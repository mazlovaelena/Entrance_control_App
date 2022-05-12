using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entrance_Control_App.Models
{
    public class PersonalViewModel
    {
        public List<Personal> Personal { get; set; }
        public int ID_Person { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDay { get; set; }
        public string WorkEmail { get; set; }
        public string MobilePhone { get; set; }
    }
}
