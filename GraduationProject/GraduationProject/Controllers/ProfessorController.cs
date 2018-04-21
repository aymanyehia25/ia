using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GraduationProject.Models;

namespace GraduationProject.Controllers
{
    public class ProfessorController : Controller
    {
        DBcontext db = new DBcontext();
        // GET: Professor
        [HttpGet]
        public ActionResult AddProfessor()
        {

            return View();
        }
        [HttpPost]
        public void AddProfessor(int id)
        {
         
            Professor prof = new Professor();
            prof.Num_teams = id;
            prof.Department = "None";
            prof.History = "None";
            prof.Interest = "None";
            prof.photo = "None";

            if (ModelState.IsValid)
            {
                db.Professors.Add(prof);
                db.SaveChanges();

            } }



        [HttpGet]
        public ActionResult Update(int Userid=7)
        {
           
            var prof = db.Professors.Find(Userid);
       
            return View(prof);
        }

        [HttpPost]
        public ActionResult Update(Professor prof)
        {
           // prof.Num_teams = Session;
            db.Entry(prof).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AddProfessor");
        }























        /*
        [HttpGet]
        public ActionResult searchprof( )
        {

            return View();
        }
        [HttpPost]
        public ActionResult searchprof(string profemail)
        {
            UserController user = new UserController();
         //  var x= user.searchuser(profemail);
            return View();

        }
          */

/*
        [HttpGet]
        public ActionResult deleteStudent(int id)
        {
            var selectedStd = db.Students.Find(id);
            return View(selectedStd);
        }

        [HttpPost]
        [ActionName("deleteStudent")]
        public ActionResult deleteStd(int id)
        {
            var selectedStd = db.Students.Find(id);
            var deletedStd = db.Students.Remove(selectedStd);
            db.SaveChanges();
            return View();
        }
 */
    }
}