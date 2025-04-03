using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace DataBase.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Views/Home/Index.cshtml");
        }
        public ActionResult Classic()
        {
            return View("Classic.cshtml"); // Указываем полный путь
        }

        public ActionResult VRMassage()
        {
            return View("VRmassage.cshtml");
        }

        public ActionResult Immersion()
        {
            return View("immerrion.cshtml");
        }



        public ActionResult ClientList()
        {
            using (Massage_SalonEntities database = new Massage_SalonEntities())
            {
                var result = database.Client.ToList();
                return View(result);
            }
        }
        [HttpPost]
        public ActionResult BookMassage(MassageBookingModel model)
        {
            if (ModelState.IsValid)
            {
                using (Massage_SalonEntities database = new Massage_SalonEntities())
                {
                    var newBooking = new Massage_Booking
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Date = model.Date,
                        Time = model.Time
                    };
                    database.Massage_Booking.Add(newBooking);
                    database.SaveChanges();
                }
                return RedirectToAction("Classic");
            }
            return View("Classic", model);
        }




        [HttpGet]
        public ActionResult EditClient(int? Id_client)
        {
            if (Id_client == null)
                return RedirectToAction("ClientList");

            using (Massage_SalonEntities database = new Massage_SalonEntities())
            {
                var client = database.Client.Find(Id_client);
                if (client == null)
                    return HttpNotFound();

                return View(client);
            }
        }

        [HttpPost]
        public ActionResult EditClient(Client client)
        {
            Massage_SalonEntities database = new Massage_SalonEntities();
            database.Client.AddOrUpdate(client);
            database.SaveChanges();
            return RedirectToAction("ClientList", "Home");
        }
        public ActionResult ClientCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Massage_SalonEntities database = new Massage_SalonEntities();
            var Client = database.Client.Find(Id);
            database.Client.Remove(Client);
            database.SaveChanges();
            return RedirectToAction("ClientList", "Home");
        }
    }
}