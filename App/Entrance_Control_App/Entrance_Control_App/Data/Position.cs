using System;
using System.Collections.Generic;

#nullable disable

namespace Entrance_Control_App.Models
{
    public partial class Position
    {
        public Position()
        {
            PersDaparts = new HashSet<PersDapart>();
        }

        public int IdДолжности { get; set; }
        public string НаименованиеДолжности { get; set; }

        public virtual ICollection<PersDapart> PersDaparts { get; set; }
    }
}
