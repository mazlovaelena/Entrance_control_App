using System;
using System.Collections.Generic;

#nullable disable

namespace Entrance_Control_App.Models
{
    public partial class PersDapart
    {
        public int IdСотрудника { get; set; }
        public int IdОтдела { get; set; }
        public int IdДолжности { get; set; }
        public TimeSpan ВремяНачалаРаботы { get; set; }
        public TimeSpan ВремяЗавершенияРаботы { get; set; }
        public int ТелефонРабочий { get; set; }

        public virtual Position Position { get; set; }
        public virtual Department Depart { get; set; }
        public virtual Personal IPers { get; set; }
    }
}
