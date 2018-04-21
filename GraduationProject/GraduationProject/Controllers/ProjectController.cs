using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GraduationProject.Models;

namespace GraduationProject.Controllers
{
    public class ProjectController : Controller
    {
        DBcontext db = new DBcontext();
        // GET: Project
        [HttpGet]
        public ActionResult Addproject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Addproject(Project proj)
        {
            String message;
            if (ModelState.IsValid)
            {

                db.Projects.Add(proj);
                db.SaveChanges();
                int leaderid = 5;
                int projid = proj.ID;
                TeamLeaderController x = new TeamLeaderController();
                x.AddTeamleader(leaderid, projid);
                message = "added";
                ViewBag.message = message;

            }
            else
            {

                message = "error";
                ViewBag.message = message;

            }
            return RedirectToAction("AddStudent", "Student");
        }
        public int SelectprojId()
        {
            var y = db.Projects.Max(x => x.ID);

            return y;
        }
        public Project selectrecord()
        {
            var id = SelectprojId();
            var y = db.Projects.Find(id);
            return y;
        }

    }
}