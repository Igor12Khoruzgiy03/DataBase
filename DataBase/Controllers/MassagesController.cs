using System.Web.Mvc;
using System.Linq;
using DataBase.Models; // или просто DataBase, если модели не в папке

namespace DataBase.Controllers
{

    public class MassagesController : Controller
    {
        Massage_SalonEntities db = new Massage_SalonEntities();

        public ActionResult Index()
        {
            var massages = db.Massager.ToList();
            return View(massages);
        }

        public ActionResult Details(int id)
        {
            var massage = db.Massager.Find(id);
            if (massage == null)
                return HttpNotFound();

            return View(massage);
        }

        public ActionResult VRmassage()
        {
            using (var db = new Massage_SalonEntities())
            {
                var massages = db.Massage.ToList();
                return View(massages);
            }
        }

        public ActionResult immerrion()
        {
            using (var db = new Massage_SalonEntities())
            {
                var massages = db.Massage.ToList();
                return View(massages);
            }
        }

        public ActionResult Classic()
        {
            using (var db = new Massage_SalonEntities())
            {
                var massages = db.Massage.ToList();
                return View(massages);
            }
        }

        // ✅ Вот сюда вставь новый метод
        [HttpPost]
        public ActionResult BookSession(DataBase.ViewModels.BookingViewModel model)
        {   
            if (!ModelState.IsValid)
                return RedirectToAction("Index"); // Или вернуть View с ошибками, если хочешь

            // Пример: сохранить в базу, если будет таблица Booking
            // var booking = new Booking { ... };
            // db.Booking.Add(booking);
            // db.SaveChanges();

            TempData["Success"] = "Вы успешно записались!";
            return RedirectToAction("Index");
        }
    }

}
