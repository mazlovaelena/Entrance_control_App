using System;
using System.Collections.Generic;

#nullable disable

namespace Entrance_Control_App.Models
{
    public partial class Status
    {
        public Status()
        {
            Entrances = new HashSet<Entrance>();
        }

        public int IdСтатус { get; set; }
        public string НаименованиеСтатус { get; set; }

        public virtual ICollection<Entrance> Entrances { get; set; }
    }
}
