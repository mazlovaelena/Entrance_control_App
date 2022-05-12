using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Entrance_Control_App.Models
{
    public class RoomsViewModel
    {
        public List<Room> Rooms { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        [RegularExpression(@"\-?\d+(\.\d{0,})?", ErrorMessage = "Введите числовое значение")]
        public int ID_Room { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        public string RoomName { get; set; }
    }
}
