using System;
using System.Collections.Generic;

#nullable disable

namespace Entrance_Control_App.Models
{
    public partial class Entrance
    {
        public int IdЗапись { get; set; }
        public DateTime ДатаВхода { get; set; }
        public DateTime ДатаВыхода { get; set; }
        public int IdПомещения { get; set; }
        public int IdСотрудника { get; set; }
        public int IdТипТурникета { get; set; }
        public int IdСтатус { get; set; }

        public  Room IdRoom { get; set; }
        public  Personal IdPers { get; set; }
        public  Status IdStat { get; set; }
        public  Turnstile IdType { get; set; }
    }
}
