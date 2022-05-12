using System;
using System.Collections.Generic;

#nullable disable

namespace Entrance_Control_App.Models
{
    public partial class Department
    {
        public Department()
        {
            PersDaparts = new HashSet<PersDapart>();
        }

        public int IdОтдела { get; set; }
        public string НаименованиеОтдела { get; set; }

        public virtual ICollection<PersDapart> PersDaparts { get; set; }
    }
}
