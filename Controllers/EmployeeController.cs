using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Check_In.Models;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using Firebase.Storage;
using Google.Cloud.Firestore;

namespace Check_In.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepos employeeRepos;
        public EmployeeController(IEmployeeRepos _employeeRepos)
        {
            employeeRepos = _employeeRepos;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public async Task<IActionResult> AllEmployees()
        {
            var All_Employees = await employeeRepos.GetEmployees();
            return View(All_Employees);
        }
        public async Task<IActionResult> GetEmployee(string id)
        {

           var Emp= await employeeRepos.GetEmployee(id);

            return View(Emp);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            await employeeRepos.AddEmployee(employee);
            return RedirectToAction("AllEmployees");
        }

        public async Task<IActionResult> Update(string id)
        {
            var emp = await employeeRepos.GetEmployee(id);
            return View(emp);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(Employee_informations e)
        {
             employeeRepos.UpdateEmployee(e);
            return RedirectToAction("AllEmployees");
        }
      
        
       
      
        public IActionResult CheckIn()
        {
            return View();
        }
        public IActionResult GenerateQrCode()
        {

            return View();
        }
        [HttpPost]
        public IActionResult GenerateQrCode(string QrCodeString)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator QrCodeGenerator = new QRCodeGenerator();
                QrCodeString = "Ics554454";
                QRCodeData qrcodedata = QrCodeGenerator.CreateQrCode(QrCodeString, QRCodeGenerator.ECCLevel.Q);
                QRCode CODE = new QRCode(qrcodedata);
                using (Bitmap bitmap = CODE.GetGraphic(20))
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    ViewBag.QrCodeImg = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
                
            }
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(LogInViewModel Model)
        {
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var emp = await employeeRepos.GetEmployee(id);

            return View(emp);
        }
        [HttpPost]
        public  IActionResult DeleteConfirm(string Id)
        {
              employeeRepos.DeleteEmployee(Id);
            return RedirectToAction("AllEmployees");
        }

    }
}
