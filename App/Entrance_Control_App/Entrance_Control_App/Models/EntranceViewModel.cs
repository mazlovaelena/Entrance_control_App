using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entrance_Control_App.Models
{
    public class EntranceViewModel
    {
        public List<Entrance> Entrance { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        [RegularExpression(@"\-?\d+(\.\d{0,})?", ErrorMessage = "Введите число")]
        public int ID_Item { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        public DateTime Date_Entance { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        public DateTime Date_Exit { get; set; }

        public List<Room> Rooms { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        [RegularExpression(@"\-?\d+(\.\d{0,})?", ErrorMessage = "Введите число")]
        public int ID_Room { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        public string RoomName { get; set; }

        public List<Personal> Personal { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        [RegularExpression(@"\-?\d+(\.\d{0,})?", ErrorMessage = "Введите число")]
        public int ID_Person { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        [RegularExpression(@"(@)(.+)$", ErrorMessage = "Введите Email")]
        public string WorkEmail { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        [RegularExpression(@"\-?\d+(\.\d{0,})?", ErrorMessage = "Введите номер телефона")]
        public string MobilePhone { get; set; }

        public List<Turnstile> Turnstile { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        [RegularExpression(@"\-?\d+(\.\d{0,})?", ErrorMessage = "Введите число")]
        public int ID_Type { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        public string TypeName { get; set; }

        public List<Status> Status { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        [RegularExpression(@"\-?\d+(\.\d{0,})?", ErrorMessage = "Введите число")]
        public int ID_Status { get; set; }

        [Required(ErrorMessage = "Заполните это поле")]
        public string StatusName { get; set; }

        public int [] Months { get; set; }


    }
}
