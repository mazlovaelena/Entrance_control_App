using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entrance_Control_App.Models
{
    public class PersDepartViewModel
    {
        public List<PersDapart> PersDeparts { get; set; }
        public List<Personal> Personal { get; set; }
        public int ID_Pers { get; set; }
        public List<Department> Department { get; set; }
        public int ID_Dep { get; set; }
        public List<Position> Position { get; set; }
        public int ID_Position { get; set; }
        public TimeSpan TimeBegin { get; set; }
        public TimeSpan TimeEnd { get; set; }
        public int Phone { get; set; }
    }
}
