using System;
using System.Linq;
using System.Web.Mvc;
using DataBase.Models;
using DataBase.ViewModels; // подключаем ViewModel

namespace DataBase.Controllers
{
    public class AccountController : Controller
    {
        private Massage_SalonEntities db = new Massage_SalonEntities();

        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = db.Users.FirstOrDefault(u => u.email == model.Email);
            if (user == null || user.password_hash != Hash(model.Password))
            {
                ModelState.AddModelError("", "Неверный email или пароль");
                return View(model);
            }

            Session["UserId"] = user.id_user;
            Session["UserRole"] = user.role;
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (db.Users.Any(u => u.email == model.Email))
            {
                ModelState.AddModelError("", "Пользователь с таким email уже существует");
                return View(model);
            }

            var newUser = new Users
            {
                email = model.Email,
                password_hash = Hash(model.Password),
                role = "Client",
                created_at = DateTime.Now
            };

            db.Users.Add(newUser);
            db.SaveChanges();

            return RedirectToAction("Login");
        }

        // GET: /Account/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        // Простейшая "хеш-функция", только для демонстрации
        private string Hash(string input)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input));
        }
    }
}
