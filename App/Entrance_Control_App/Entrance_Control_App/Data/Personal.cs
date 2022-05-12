using System;
using System.Collections.Generic;

#nullable disable

namespace Entrance_Control_App.Models
{
    public partial class Personal
    {
        public Personal()
        {
            Entrances = new HashSet<Entrance>();
            PersDaparts = new HashSet<PersDapart>();
        }

        public int IdСотрудника { get; set; }
        public string ФамилияСотрудника { get; set; }
        public string ИмяСотрудника { get; set; }
        public string ОтчествоСотрудника { get; set; }
        public DateTime ДатаРождения { get; set; }
        public string КорпоративнаяПочта { get; set; }
        public string ТелефонМобильный { get; set; }

        public virtual ICollection<Entrance> Entrances { get; set; }
        public virtual ICollection<PersDapart> PersDaparts { get; set; }
    }
}
