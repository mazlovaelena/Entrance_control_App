using Entrance_Control_App.Models;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Entrance_Control_App.Controllers
{
    public class AdminController : Controller
    {
        
        private Entrance_ControlContext _context;

        public AdminController(Entrance_ControlContext context)
        {
            _context = context;
        }

        public IActionResult Cabinet()
        {
            return View();
        }

        public IActionResult Users(UserViewModel user)
        {
            user.Users = _context.Users.ToList();
            return View(user);
        }

        public IActionResult DeleteUsers(int id)
        {
            var data = _context.Users.FirstOrDefault(x => x.IdUser == id);
            if(data != null)
            {
                _context.Users.Remove(data);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Users));
        }


        public IActionResult Monitor(MonitorDBViewModel mon)
        {
            mon.MonitorDB = _context.MonitorDatabases.ToList();
            return View(mon);
        }

        [HttpPost]
        public IActionResult MonitorReport()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var Ep = new ExcelPackage();
            var Sheet = Ep.Workbook.Worksheets.Add("MonitorDB");

            FileStream fs = new FileStream("MonitorDB.xlsx", FileMode.OpenOrCreate);

            Sheet.Cells["A1"].Value = "IdItem";
            Sheet.Cells["B1"].Value = "Hostname";
            Sheet.Cells["C1"].Value = "NtUsername";
            Sheet.Cells["D1"].Value = "NameOperation";
            Sheet.Cells["E1"].Value = "NameTable";
            Sheet.Cells["F1"].Value = "NameColumns";
            Sheet.Cells["G1"].Value = "IdRecord";
            Sheet.Cells["H1"].Value = "OldRecord";
            Sheet.Cells["I1"].Value = "NewRecord";
            Sheet.Cells["J1"].Value = "DataModificationRecord";


            var row = 2;
            foreach (var entrance in _context.MonitorDatabases.ToList())
            {
                Sheet.Cells[string.Format("A{0}", row)].Value = entrance.IdItem;
                Sheet.Cells[string.Format("B{0}", row)].Value = entrance.Hostname;
                Sheet.Cells[string.Format("C{0}", row)].Value = entrance.NtUsername;
                Sheet.Cells[string.Format("D{0}", row)].Value = entrance.NameOperation;
                Sheet.Cells[string.Format("E{0}", row)].Value = entrance.NameTable;
                Sheet.Cells[string.Format("F{0}", row)].Value = entrance.NameColumns;
                Sheet.Cells[string.Format("G{0}", row)].Value = entrance.IdRecord;
                Sheet.Cells[string.Format("H{0}", row)].Value = entrance.OldRecord;
                Sheet.Cells[string.Format("I{0}", row)].Value = entrance.NewRecord;
                Sheet.Cells[string.Format("J{0}", row)].Value = entrance.DataModificationRecord.ToString();
                row++;
            }
            Sheet.Cells["A:AZ"].AutoFitColumns();

            var xlFile = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MonitorDBReport.xlsx"));
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Ep.SaveAs(xlFile);
            fs.Close();

            return RedirectToAction(nameof(Monitor));
        }
    }
}
