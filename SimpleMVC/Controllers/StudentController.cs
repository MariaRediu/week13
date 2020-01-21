using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleMVC.Models;

namespace SimpleMVC.Controllers
{
    public class StudentController : Controller
    {
        public StudentController()
        {

        }

        // GET: Student
        public ActionResult Index()
        {
            List<Student> stud = new List<Student>
            {
                new Student
                {
                    StudentId=1, StudentName="Ilinca",Age=5, City="Iasi", Adress="Pacurari 45"
                }
            };

            return View(stud);
        }

        [ActionName("find")]
        public ActionResult GetById(int id)
        {
            // get student from the database 
            return View();
        }


    

        [HttpPost]
        public ActionResult Details(Student std)
        {
            // details student to the database

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Student std)
        {
            // update student to the database

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            // delete student from the database whose id matches with specified id

            return RedirectToAction("Index");
        }
    }
}