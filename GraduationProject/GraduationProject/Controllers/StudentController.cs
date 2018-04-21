using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GraduationProject.Models;

namespace GraduationProject.Controllers
{
    public class StudentController : Controller
    {
        DBcontext db = new DBcontext();
        // GET: Student
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student std)
        {
            string message;
            /*   TeamLeaderController tm = new TeamLeaderController();
              int count=tm.checkleader(1);
              int teamcount = team_count(1);
              if (count < 1)
              {
                  message = "you should add project first";
                  ViewBag.Message = message;

              }
              
               else if(teamcount>5){
                   message = "the team should not be more than 5 students";
                   ViewBag.Message = message;
                }
             * */
            if (ModelState.IsValid)
            {
                int leaderID = 5;
                std.teamleaderid = leaderID;
                std.projectid = null;
                db.Students.Add(std);
                db.SaveChanges();
                message = "ADDEd";
                ViewBag.Message = message;
            }
            else
            {
                message = "Error";
                ViewBag.Message = message;

            }
            return View();
        }
        public int team_count(int id)
        {
            int count = db.Students.Count(x => x.teamleaderid == id);
            return count;
        }
    }
}