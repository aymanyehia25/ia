using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GraduationProject.Models;

namespace GraduationProject.Controllers
{

    public class TeamLeaderController : Controller
    {
        DBcontext db = new DBcontext();
        [HttpGet]
        public ActionResult AddTeamleader()
        {
            return View();
        }



        [HttpPost]
        public void AddTeamleader(int leaderid, int projid)
        {

            //var x=db.TeamLeaders.Select(y => y.teamleaderid == leaderid);

            TeamLeader xy = new TeamLeader();
            xy.teamleaderid = leaderid;
            xy.projectID = projid;
            xy.professorId = 0;
            db.TeamLeaders.Add(xy);
            db.SaveChanges();



        }
        public int checkleader(int id)
        {
            int count = db.TeamLeaders.Count(x => x.teamleaderid == id);

            return count;
        }

    }
}