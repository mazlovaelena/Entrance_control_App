using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entrance_Control_App.Models
{
    public class DepartmentViewModel
    {
        public List<Department> Departments { get; set; }
        public int ID_Dep { get; set; }
        public string Name_Dep { get; set; }
    }
}
