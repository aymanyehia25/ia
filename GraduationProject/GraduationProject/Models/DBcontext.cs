using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GraduationProject.Models
{
    public class DBcontext : DbContext
    {
        public DbSet<User> Users { get; set; }
       
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Student> Students { get; set; }

        
        public DbSet<TeamLeader> TeamLeaders { get; set; }


        


        public DBcontext()
            : base("DefaultConnection")
        {

        }
    }
}