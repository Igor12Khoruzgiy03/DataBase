using DataBase.Models;
using DataBase.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

namespace DataBase.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
                return RedirectToAction("Classic", "Massages"); // Перенаправляем в новый контроллер
            }
            return View("Classic", model);
        }
        public ActionResult IndexMassages()
        {
            using (Massage_SalonEntities database = new Massage_SalonEntities())
            {
                var model = new MassagePageViewModel
                {
                    Massagers = database.Massager.ToList(),
                    Massages = database.Massage.ToList()
                };

                return View(model);
            }
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
            using (Massage_SalonEntities database = new Massage_SalonEntities())
            {
                database.Client.AddOrUpdate(client);
                database.SaveChanges();
            }
            return RedirectToAction("ClientList", "Home");
        }

        public ActionResult ClientCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (Massage_SalonEntities database = new Massage_SalonEntities())
            {
                var client = database.Client.Find(Id);
                if (client != null)
                {
                    database.Client.Remove(client);
                    database.SaveChanges();
                }
            }
            return RedirectToAction("ClientList", "Home");
        }
    }
}
