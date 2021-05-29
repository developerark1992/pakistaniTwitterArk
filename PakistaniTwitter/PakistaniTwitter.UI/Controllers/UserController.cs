using System;
using System.Web.Mvc;
using PakistaniTwitter.Models;


namespace PakistaniTwitter.Controllers
{
    public class UserController : Controller
    {
        UserBL obj = new UserBL();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PersonVM item)
        {
            if (ModelState.IsValid)
            {
                Users_PakistaniTwitter p = new Users_PakistaniTwitter()
                {
                    UserId = item.UserId,
                    Password = item.Pwd,
                    Email = item.Email,
                    FullName = item.Name,
                    Active = true,
                    Joined = DateTime.Now
                };
                obj.AddUser(p);
                return RedirectToAction("Login");

            }
            else
                return View();
        }

        public ViewResult Update()
        {
            Users_PakistaniTwitter person = obj.SearchUser(Session["UserId"].ToString());
            PersonVM peopleVM = new PersonVM();
            peopleVM.UserId = person.UserId;
            peopleVM.Email = person.Email;
            peopleVM.Active = person.Active;
            peopleVM.Joined = person.Joined;
            peopleVM.Name = person.FullName;
            peopleVM.Pwd = person.Password;
            return View(peopleVM);
        }

        [HttpPost]
        public ActionResult Update(PersonVM item)
        {
            if (ModelState.IsValid)
            {
                Users_PakistaniTwitter p = new Users_PakistaniTwitter()
                {
                    UserId = item.UserId,
                    Password = item.Pwd,
                    Email = item.Email,
                    FullName = item.Name,
                    Active = item.Active,
                    Joined = DateTime.Now
                };
                obj.UpdateUser(p);
                return RedirectToAction("Login");

            }
            else
                return View();
        }

        [HttpPost]
        public ActionResult Deactivate()
        {
            Users_PakistaniTwitter p = obj.SearchUser(Session["UserId"].ToString());
            if(p != null)
            {
                p.Active = false;                
            };
            obj.UpdateUser(p);
            //return RedirectToAction("Login");
            var result = "success";
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string uname, string pwd)
        {
            Users_PakistaniTwitter p = obj.Validate(uname, pwd);
            if (p != null)
            {
              
                Session["UserName"] = p.FullName;
                Session["UserId"] = p.UserId;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["err"] = "Invalid Login Details";
                return View();
            }
        }
        public ViewResult Details(Users_PakistaniTwitter p)
        {
            return View(p);
        }

    }
}