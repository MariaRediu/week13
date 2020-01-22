using SimpleMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace SimpleMVC.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models;

    public class UsersController : Controller
    {
        private readonly UserData userData;
  

        public UsersController()
        {
            this.userData = new UserData();
        }

        //users/index
        public ActionResult Index()
        {
            List<Users> users = this.userData.GetUsers();

            return this.View(users);
        }
        [HttpGet]
        public ActionResult ById(int id)
        {
            var u = this.userData.GetUser(id);

            return this.View(u);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult CreateUser()
        {
            var form = this.Request.Form;
            var userName = form["Name"];
            var email = form["Email"];
            return this.View("Create");
        }
        [HttpPost]
        public ActionResult CreateUser2(Users u)
        {
            
            //return this.View("Index");
            return RedirectToAction("Index");
        }

    }
}
