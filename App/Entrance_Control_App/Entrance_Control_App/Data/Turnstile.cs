using System;
using System.Collections.Generic;

#nullable disable

namespace Entrance_Control_App.Models
{
    public partial class Turnstile
    {
        public Turnstile()
        {
            Entrances = new HashSet<Entrance>();
        }

        public int IdТипТурникета { get; set; }
        public string НаименованиеТипаТурникета { get; set; }

        public virtual ICollection<Entrance> Entrances { get; set; }
    }
}
