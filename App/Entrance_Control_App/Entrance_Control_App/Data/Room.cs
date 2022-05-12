using System;
using System.Collections.Generic;

#nullable disable

namespace Entrance_Control_App.Models
{
    public partial class Room
    {
        public Room()
        {
            Entrances = new HashSet<Entrance>();
        }

        public int IdПомещения { get; set; }
        public string НаименованиеПомещения { get; set; }

        public virtual ICollection<Entrance> Entrances { get; set; }
    }
}
