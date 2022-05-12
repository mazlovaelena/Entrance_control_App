using Entrance_Control_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;



namespace Entrance_Control_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Entrance_ControlContext _context;

        public HomeController(Entrance_ControlContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public IActionResult HomePage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EntranceReport()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var Ep = new ExcelPackage();
            FileStream fs = new FileStream("Entrance.xlsx", FileMode.OpenOrCreate);
            
            var Sheet1 = Ep.Workbook.Worksheets.Add("Доступ");
            Sheet1.Cells["A1"].Value = "ID_Запись";
            Sheet1.Cells["B1"].Value = "Дата_Входа";
            Sheet1.Cells["C1"].Value = "Дата_Выхода";
            Sheet1.Cells["D1"].Value = "Помещение";
            Sheet1.Cells["E1"].Value = "Сотрудник";
            Sheet1.Cells["F1"].Value = "ТипТурникета";
            Sheet1.Cells["G1"].Value = "СтатусВхода";

            var row1 = 2;
            foreach (var entrance in _context.Entrances.ToList())
            {
                Sheet1.Cells[string.Format("A{0}", row1)].Value = entrance.IdЗапись;
                Sheet1.Cells[string.Format("B{0}", row1)].Value = entrance.ДатаВхода.ToString();
                Sheet1.Cells[string.Format("C{0}", row1)].Value = entrance.ДатаВыхода.ToString();
                Sheet1.Cells[string.Format("D{0}", row1)].Value = entrance.IdПомещения;
                Sheet1.Cells[string.Format("E{0}", row1)].Value = entrance.IdСотрудника;
                Sheet1.Cells[string.Format("F{0}", row1)].Value = entrance.IdТипТурникета;
                Sheet1.Cells[string.Format("G{0}", row1)].Value = entrance.IdСтатус;
                row1++;
            }
            Sheet1.Cells["A:AZ"].AutoFitColumns();

            var Sheet2 = Ep.Workbook.Worksheets.Add("Сотрудники");
            Sheet2.Cells["A1"].Value = "ID_Сотрудника";
            Sheet2.Cells["B1"].Value = "ФамилияСотрудника";
            Sheet2.Cells["C1"].Value = "ИмяСотрудника";
            Sheet2.Cells["D1"].Value = "ОтчетсвоСотрудника";
            Sheet2.Cells["E1"].Value = "ДатаРождения";
            Sheet2.Cells["F1"].Value = "КорпоративнаяПочта";
            Sheet2.Cells["G1"].Value = "ТелефонМобильный";

            var row2 = 2;
            foreach (var entrance in _context.Personals.ToList())
            {
                Sheet2.Cells[string.Format("A{0}", row2)].Value = entrance.IdСотрудника;
                Sheet2.Cells[string.Format("B{0}", row2)].Value = entrance.ФамилияСотрудника;
                Sheet2.Cells[string.Format("C{0}", row2)].Value = entrance.ИмяСотрудника;
                Sheet2.Cells[string.Format("D{0}", row2)].Value = entrance.ОтчествоСотрудника;
                Sheet2.Cells[string.Format("E{0}", row2)].Value = entrance.ДатаРождения.ToString();
                Sheet2.Cells[string.Format("F{0}", row2)].Value = entrance.КорпоративнаяПочта;
                Sheet2.Cells[string.Format("G{0}", row2)].Value = entrance.ТелефонМобильный;
                row2++;
            }
            Sheet2.Cells["A:AZ"].AutoFitColumns();

            var Sheet3 = Ep.Workbook.Worksheets.Add("Должности");
            Sheet3.Cells["A1"].Value = "ID_Должности";
            Sheet3.Cells["B1"].Value = "НаименованиеДолжности";

            var row3 = 2;
            foreach (var entrance in _context.Positions.ToList())
            {
                Sheet3.Cells[string.Format("A{0}", row3)].Value = entrance.IdДолжности;
                Sheet3.Cells[string.Format("B{0}", row3)].Value = entrance.НаименованиеДолжности;
                row3++;
            }
            Sheet3.Cells["A:AZ"].AutoFitColumns();

            var Sheet4 = Ep.Workbook.Worksheets.Add("Отделы");
            Sheet4.Cells["A1"].Value = "ID_Отдела";
            Sheet4.Cells["B1"].Value = "НаименованиеОтдела";

            var row4 = 2;
            foreach (var entrance in _context.Departments.ToList())
            {
                Sheet4.Cells[string.Format("A{0}", row4)].Value = entrance.IdОтдела;
                Sheet4.Cells[string.Format("B{0}", row4)].Value = entrance.НаименованиеОтдела;
                row4++;
            }
            Sheet4.Cells["A:AZ"].AutoFitColumns();

            var Sheet5 = Ep.Workbook.Worksheets.Add("СотрудникиОтделы");
            Sheet5.Cells["A1"].Value = "ID_Сотрудника";
            Sheet5.Cells["B1"].Value = "ID_Отдела";
            Sheet5.Cells["C1"].Value = "ID_Должности";
            Sheet5.Cells["D1"].Value = "ВремяНачалаРаботы";
            Sheet5.Cells["E1"].Value = "ВремяЗавершенияРаботы";
            Sheet5.Cells["F1"].Value = "ТелефонРабочий";

            var row5 = 2;
            foreach (var entrance in _context.PersDaparts.ToList())
            {
                Sheet5.Cells[string.Format("A{0}", row5)].Value = entrance.IdСотрудника;
                Sheet5.Cells[string.Format("B{0}", row5)].Value = entrance.IdОтдела;
                Sheet5.Cells[string.Format("C{0}", row5)].Value = entrance.IdДолжности;
                Sheet5.Cells[string.Format("D{0}", row5)].Value = entrance.ВремяНачалаРаботы.ToString();
                Sheet5.Cells[string.Format("E{0}", row5)].Value = entrance.ВремяЗавершенияРаботы.ToString();
                Sheet5.Cells[string.Format("F{0}", row5)].Value = entrance.ТелефонРабочий;
                row5++;
            }
            Sheet5.Cells["A:AZ"].AutoFitColumns();

            var Sheet6 = Ep.Workbook.Worksheets.Add("Помещения");
            Sheet6.Cells["A1"].Value = "ID_Помещения";
            Sheet6.Cells["B1"].Value = "НаименованиеПомещения";

            var row6 = 2;
            foreach (var entrance in _context.Rooms.ToList())
            {
                Sheet6.Cells[string.Format("A{0}", row6)].Value = entrance.IdПомещения;
                Sheet6.Cells[string.Format("B{0}", row6)].Value = entrance.НаименованиеПомещения;
                row6++;
            }
            Sheet6.Cells["A:AZ"].AutoFitColumns();

            var Sheet7 = Ep.Workbook.Worksheets.Add("ТипыТурникетов");
            Sheet7.Cells["A1"].Value = "ID_ТипТурникета";
            Sheet7.Cells["B1"].Value = "НаименованиеТипаТурникета";

            var row7 = 2;
            foreach (var entrance in _context.Turnstiles.ToList())
            {
                Sheet7.Cells[string.Format("A{0}", row7)].Value = entrance.IdТипТурникета;
                Sheet7.Cells[string.Format("B{0}", row7)].Value = entrance.НаименованиеТипаТурникета;
                row7++;
            }
            Sheet7.Cells["A:AZ"].AutoFitColumns();

            var Sheet8 = Ep.Workbook.Worksheets.Add("СтатусДоступа");
            Sheet8.Cells["A1"].Value = "ID_Статус";
            Sheet8.Cells["B1"].Value = "НаименованиеСтатус";

            var row8 = 2;
            foreach (var entrance in _context.Statuses.ToList())
            {
                Sheet8.Cells[string.Format("A{0}", row8)].Value = entrance.IdСтатус;
                Sheet8.Cells[string.Format("B{0}", row8)].Value = entrance.НаименованиеСтатус;
                row8++;
            }
            Sheet8.Cells["A:AZ"].AutoFitColumns();

            var xlFile = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "EntranceReport.xlsx"));
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Ep.SaveAs(xlFile);
            fs.Close();
             
            return RedirectToAction(nameof(Entrance));
        }
        public IActionResult Entrance(EntranceViewModel entr)
        {
            entr.Rooms = _context.Rooms.ToList();
            entr.Personal = _context.Personals.ToList();
            entr.Turnstile = _context.Turnstiles.ToList();
            entr.Status = _context.Statuses.ToList();
            entr.Entrance = _context.Entrances.ToList();

            return View(entr);
        }

        public IActionResult RemoveDataEntr(EntranceViewModel entr, int id)
        {
           
            var data = _context.Entrances.FirstOrDefault(x => x.IdЗапись == id);

            if (data != null)
            {
                _context.Entrances.Remove(data);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Entrance));
        }

       
        [HttpPost]
        public IActionResult CreateEntr(EntranceViewModel entr)
        {

            entr.Entrance = _context.Entrances.ToList();
                                              
            var create = new Entrance { IdЗапись = entr.ID_Item, ДатаВхода = entr.Date_Entance.Date, ДатаВыхода = entr.Date_Exit.Date, IdПомещения = entr.ID_Room, IdСотрудника = entr.ID_Person, IdСтатус = entr.ID_Status, IdТипТурникета = entr.ID_Type };
            
            _context.Entrances.Add(create);
            _context.SaveChanges();

            return RedirectToAction(nameof(Entrance));
        }
        public IActionResult CreateEntr()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditEntr(EntranceViewModel entr)
        {
            var edit = _context.Entrances.FirstOrDefault(x => x.IdЗапись == entr.ID_Item);

            edit.ДатаВхода = entr.Date_Entance;
            edit.ДатаВыхода = entr.Date_Exit;
            edit.IdПомещения = entr.ID_Room;
            edit.IdСотрудника = entr.ID_Person;
            edit.IdТипТурникета = entr.ID_Type;
            edit.IdСтатус = entr.ID_Status;

            _context.SaveChanges();

            return RedirectToAction(nameof(Entrance));
        }
        public IActionResult EditEntr(EntranceViewModel entr, int id)
        {
            var view = _context.Entrances.FirstOrDefault(x => x.IdЗапись == id);

            if (id != 0)
            {
                var edit = _context.Entrances.FirstOrDefault(x => x.IdЗапись == id);
                entr.ID_Item = edit.IdЗапись;
                entr.Date_Entance = edit.ДатаВхода;
                entr.Date_Exit = edit.ДатаВыхода;
                entr.ID_Room = edit.IdПомещения;
                entr.ID_Person = edit.IdСотрудника;
                entr.ID_Type = edit.IdТипТурникета;
                entr.ID_Status = edit.IdСтатус;

            }
            return View(entr);
        }

        public IActionResult Positions(PositiosViewModel pos)
        {
            pos.Positions = _context.Positions.ToList();
            return View(pos);
        }

        [HttpPost]
        public IActionResult CreatPos(PositiosViewModel pos)
        {
            var create = new Position { НаименованиеДолжности = pos.NamePosition };
            _context.Positions.Add(create);
            _context.SaveChanges();

            return RedirectToAction(nameof(Positions));
        }

        public IActionResult CreatePos()
        {
            return View();

        }

        public IActionResult RemoveDataPos(int id)
        {
            var data = _context.Positions.FirstOrDefault(x => x.IdДолжности == id);

            if (data != null)
            {
                _context.Positions.Remove(data);
            }

            return RedirectToAction(nameof(Positions));
        }

        [HttpPost]
        public IActionResult EditPos(PositiosViewModel pos)
        {
            var edit = _context.Positions.FirstOrDefault(x => x.IdДолжности == pos.ID_Position);

            edit.IdДолжности = pos.ID_Position;
            edit.НаименованиеДолжности = pos.NamePosition;

            _context.SaveChanges();

            return RedirectToAction(nameof(Positions));
        }

        public IActionResult EditPos(PositiosViewModel pos, int id)
        {
            var view = _context.Positions.FirstOrDefault(x => x.IdДолжности == id);
            if (id != 0)
            {
                var edit = _context.Positions.FirstOrDefault(x => x.IdДолжности == id);
                pos.ID_Position = edit.IdДолжности;
                pos.NamePosition = edit.НаименованиеДолжности;
            }

            return View(pos);
        }


        public IActionResult Personal(PersonalViewModel pers)
        {
            pers.Personal = _context.Personals.ToList();
            return View(pers);
        }

        public IActionResult RemoveDataPers(int id)
        {
            var data = _context.Personals.FirstOrDefault(x => x.IdСотрудника == id);

            if (data != null)
            {
                _context.Personals.Remove(data);
            }

            return RedirectToAction(nameof(Personal));
        }


        [HttpPost]
        public IActionResult CreatePers(PersonalViewModel pers)
        {

            var create = new Personal{ IdСотрудника = pers.ID_Person, ФамилияСотрудника = pers.Surname, ИмяСотрудника = pers.Name, ОтчествоСотрудника = pers.Patronymic, ДатаРождения = pers.BirthDay, КорпоративнаяПочта = pers.WorkEmail, ТелефонМобильный = pers.MobilePhone  };

            _context.Personals.Add(create);
            _context.SaveChanges();

            return RedirectToAction(nameof(Personal));
        }
        public IActionResult CreatePers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditPers(PersonalViewModel pers)
        {
            var edit = _context.Personals.FirstOrDefault(x => x.IdСотрудника == pers.ID_Person);

            edit.IdСотрудника = pers.ID_Person;
            edit.ФамилияСотрудника = pers.Surname;
            edit.ИмяСотрудника = pers.Name;
            edit.ОтчествоСотрудника = pers.Patronymic;
            edit.ДатаРождения = pers.BirthDay;
            edit.КорпоративнаяПочта = pers.WorkEmail;
            edit.ТелефонМобильный = pers.MobilePhone;

            _context.SaveChanges();

            return RedirectToAction(nameof(Personal));
        }
        public IActionResult EditPers(PersonalViewModel pers, int id)
        {
            var view = _context.Personals.FirstOrDefault(x => x.IdСотрудника == id);
            if (id != 0)
            {
                var edit = _context.Personals.FirstOrDefault(x => x.IdСотрудника == id);
                pers.ID_Person = edit.IdСотрудника;
                pers.Surname = edit.ФамилияСотрудника;
                pers.Name = edit.ИмяСотрудника;
                pers.Patronymic = edit.ОтчествоСотрудника;
                pers.BirthDay = edit.ДатаРождения;
                pers.WorkEmail = edit.КорпоративнаяПочта;
                pers.MobilePhone = edit.ТелефонМобильный;

            }
            return View(pers);
        }

        public IActionResult Departments(DepartmentViewModel dep)
        {
            dep.Departments = _context.Departments.ToList();
            return View(dep);
        }

        [HttpPost]
        public IActionResult CreateDep(DepartmentViewModel dep)
        {
            var create = new Department { НаименованиеОтдела = dep.Name_Dep };
            _context.Departments.Add(create);
            _context.SaveChanges();

            return RedirectToAction(nameof(Departments));
        }

        public IActionResult CreateDep()
        {
            return View();

        }

        public IActionResult RemoveDataDep(int id)
        {
            var data = _context.Departments.FirstOrDefault(x => x.IdОтдела == id);

            if (data != null)
            {
                _context.Departments.Remove(data);
            }

            return RedirectToAction(nameof(Departments));
        }

        [HttpPost]
        public IActionResult EditDep(DepartmentViewModel dep)
        {
            var edit = _context.Departments.FirstOrDefault(x => x.IdОтдела == dep.ID_Dep);

            edit.IdОтдела = dep.ID_Dep;
            edit.НаименованиеОтдела = dep.Name_Dep;

            _context.SaveChanges();

            return RedirectToAction(nameof(Departments));
        }

        public IActionResult EditDep(DepartmentViewModel dep, int id)
        {
            var view = _context.Departments.FirstOrDefault(x => x.IdОтдела == id);
            if (id != 0)
            {
                var edit = _context.Departments.FirstOrDefault(x => x.IdОтдела == id);
                dep.ID_Dep = edit.IdОтдела;
                dep.Name_Dep = edit.НаименованиеОтдела;

            }

            return View(dep);
        }


        public IActionResult Depart_Pers(PersDepartViewModel pers)
        {
            pers.PersDeparts = _context.PersDaparts.ToList();
            pers.Personal = _context.Personals.ToList();
            pers.Position = _context.Positions.ToList();
            pers.Department = _context.Departments.ToList();
            return View(pers);
        }

        public IActionResult Rooms(RoomsViewModel room)
        {
            room.Rooms = _context.Rooms.ToList();
            return View(room);
        }

        [HttpPost]
        public IActionResult CreateRoom (RoomsViewModel room)
        {
            var create = new Room { НаименованиеПомещения = room.RoomName };
            _context.Rooms.Add(create);
            _context.SaveChanges();

            return RedirectToAction(nameof(Rooms));
        }

        public IActionResult CreateRoom()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditRoom(RoomsViewModel room)
        {
            var edit = _context.Rooms.FirstOrDefault(x => x.IdПомещения == room.ID_Room);

            edit.IdПомещения = room.ID_Room;
            edit.НаименованиеПомещения = room.RoomName;

            _context.SaveChanges();

            return RedirectToAction(nameof(Rooms));
        }

        public IActionResult EditRoom(RoomsViewModel room, int id)
        {
            var view = _context.Rooms.FirstOrDefault(x => x.IdПомещения == id);

            if(id != 0)
            {
                var edit = _context.Rooms.FirstOrDefault(x => x.IdПомещения == id);
                room.ID_Room = edit.IdПомещения;
                room.RoomName = edit.НаименованиеПомещения;
            }

            return View(room);
        }

        public IActionResult RemoveDataRoom(int id)
        {
            var data = _context.Rooms.FirstOrDefault(x => x.IdПомещения == id);

            if (data != null)
            {
                _context.Rooms.Remove(data);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Rooms));
        }
        public IActionResult Turnstiles(TurnstilesViewModel turn)
        {
            turn.Turnstiles = _context.Turnstiles.ToList(); 
            return View(turn);
        }

        [HttpPost]
        public IActionResult CreateType (TurnstilesViewModel turn)
        {
            var create = new Turnstile { НаименованиеТипаТурникета = turn.TypeName };

            _context.Turnstiles.Add(create);
            _context.SaveChanges();

            return RedirectToAction(nameof(Turnstiles));
        }
        public IActionResult CreateType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditType(TurnstilesViewModel turn)
        {
            var edit = _context.Turnstiles.FirstOrDefault(x => x.IdТипТурникета == turn.ID_Type);

            edit.IdТипТурникета = turn.ID_Type;
            edit.НаименованиеТипаТурникета = turn.TypeName;

            _context.SaveChanges();

            return RedirectToAction(nameof(Turnstiles));
        }
        public IActionResult EditType(TurnstilesViewModel turn, int id)
        {
            var view = _context.Turnstiles.FirstOrDefault(x => x.IdТипТурникета == id);
            if(id != 0)
            {
                var edit = _context.Turnstiles.FirstOrDefault(x => x.IdТипТурникета == id);
                turn.ID_Type = edit.IdТипТурникета;
                turn.TypeName = edit.НаименованиеТипаТурникета;
            }

            return View(turn);
        }

        public IActionResult RemoveDataTurn(int id)
        {
            var data = _context.Turnstiles.FirstOrDefault(x => x.IdТипТурникета == id);

            if (data != null)
            {
                _context.Turnstiles.Remove(data);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Turnstiles));
        }

        public IActionResult Statuses(StatusesViewModel stat)
        {
            stat.Statuses = _context.Statuses.ToList();
            return View(stat);
        }

        public IActionResult ChartEntrance(EntranceViewModel entr)
        {
            entr.Entrance = _context.Entrances.ToList();

            
            int jan = _context.Entrances.Count(x => x.ДатаВхода.Date.ToString().Contains("01"));
            int feb = _context.Entrances.Count(x => x.ДатаВхода.Month.ToString().Contains("2"));
            int mar = _context.Entrances.Count(x => x.ДатаВхода.Month.ToString().Contains("3"));
            int apr = _context.Entrances.Count(x => x.ДатаВхода.Month.ToString().Contains("4"));
            int may = _context.Entrances.Count(x => x.ДатаВхода.Month.ToString().Contains("5"));
            int jun = _context.Entrances.Count(x => x.ДатаВхода.Month.ToString().Contains("6"));
            int jul = _context.Entrances.Count(x => x.ДатаВхода.Month.ToString().Contains("7"));
            int aug = _context.Entrances.Count(x => x.ДатаВхода.Month.ToString().Contains("8"));
            int sep = _context.Entrances.Count(x => x.ДатаВхода.Month.ToString().Contains("9"));
            int oct = _context.Entrances.Count(x => x.ДатаВхода.Month.ToString().Contains("10"));
            int nov = _context.Entrances.Count(x => x.ДатаВхода.Month.ToString().Contains("11"));
            int dec = _context.Entrances.Count(x => x.ДатаВхода.Month.ToString().Contains("12"));

            entr.Months = new int[] { jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec };

            return View(entr);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int code)
        {
            if (code == 404)
            {
                return View("Error");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
