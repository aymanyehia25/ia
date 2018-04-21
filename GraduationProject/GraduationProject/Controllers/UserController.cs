using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GraduationProject.Models;
using System.Net.Mail;
using System.Net;
using System.Web.Security;

namespace GraduationProject.Controllers
{
    public class UserController : Controller
    {
        DBcontext db = new DBcontext();
        bool Status = false;
        string Message = "";
        [HttpGet]
        public ActionResult signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult signup([Bind(Exclude = "Role,IsEmail,Activationcode")] User user)
        {
            if (ModelState.IsValid)
            {
                //email verification
                var exist = ISEmailValid(user.Email);
                if (exist)
                {
                    ModelState.AddModelError("Email Exist", "This Email is already exist");
                    return View(user);
                }

                //activation code
                user.Activationcode = Guid.NewGuid().ToString();

                //passwordhashing
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);


                user.IsEmail = false;
                user.Role = "Student";
                db.Users.Add(user);
                db.SaveChanges();
                //sending mail 
                sendverificationmaillink(user.Email, user.Activationcode);
                Message = "Registration Successfully done .Account activation link" + "has been sent to your email " + user.Email;
                Status = true;
            }
            else
            {
                Message = "Invalid Request";
            }
            ViewBag.Message = Message;
            ViewBag.Status = Status;
            return View();
        }

        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            db.Configuration.ValidateOnSaveEnabled = false;
            // this line to avoid confirum password does not match issue on save changes

            var v = db.Users.Where(a => a.Activationcode == new Guid(id).ToString()).FirstOrDefault();
            if (v != null)
            {
                v.IsEmail = true;
                db.SaveChanges();
                Status = true;
            }
            else
            {
                ViewBag.Message = "Invalid Request";
            }
            ViewBag.Status = Status;
            return View();
        }



        [HttpGet]
        public ActionResult login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(User user, string returnurl = "")
        {
            string message = "";

            var x = db.Users.Where(a => a.Email == user.Email).FirstOrDefault();
            if (x != null)
            {
                if (string.Compare(Crypto.Hash(user.Password), x.Password) == 0)
                {
                    int timeout = user.Rememberme ? 525600 : 20;
                    var ticket = new FormsAuthenticationTicket(user.Email, user.Rememberme, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);
                    if (Url.IsLocalUrl(returnurl))
                    {
                        return Redirect(returnurl);
                    }
                    else
                    {
                        return RedirectToAction("index", "Home");

                    }
                }
                else
                {
                    message = "invalid Credential";
                }
            }
            else
            {
                message = "invalid Credential";
            }
            ViewBag.Message = message;
            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "User");


        }



        [NonAction]
        public bool ISEmailValid(string email)
        {
            var b = db.Users.Where(a => a.Email == email).FirstOrDefault();
            return b != null;
        }
        [NonAction]
        public void sendverificationmaillink(string email, string actvcode)
        {
            /*var schema = Request.Url.Scheme;
            var host = Request.Url.Host;
            var port = Request.Url.Port;
            */
            var verifyurl = "/User/VerifyAccount/" + actvcode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyurl);
            var fromemail = new MailAddress("aymanyehia25179@gmail.com", "Ayman Yehia");
            var toemail = new MailAddress(email);
            var fromemailpass = "01151207984";
            string subject = "your Account is successfully Created!";
            string body = "<br/><br/> we are excited to tell you that your account is successfully completed!! welcome,please click on the below link to verify you account" + "<br/><br/> <a href='" + link + "'>" + link + "</a>";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromemail.Address, fromemailpass)
            };
            using (var message = new MailMessage(fromemail, toemail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }


        [HttpPost]
        public ActionResult function_adduser(User user)
        {
            if (ModelState.IsValid)
            {
                //email verification
                var exist = ISEmailValid(user.Email);
                if (exist)
                {
                    ModelState.AddModelError("Email Exist", "This Email is already exist");
                    return View(user);
                }

                //activation code
                user.Activationcode = Guid.NewGuid().ToString();

                //passwordhashing
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);


                user.IsEmail = false;
                user.Role = "Professor";
                db.Users.Add(user);
                db.SaveChanges();
                //sending mail 
                sendverificationmaillink(user.Email, user.Activationcode);
                Message = "Registration Successfully done .Account activation link" + "has been sent to your email " + user.Email;
                Status = true;
            }
            else
            {
                Message = "Invalid Request";
            }
            ViewBag.Message = Message;
            ViewBag.Status = Status;
            return View();
        }







        [HttpGet]
        public ActionResult Adduser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adduser(User user)
        { 
            function_adduser(user);
            int id =user.ID;
            ProfessorController pr = new ProfessorController();
            pr.AddProfessor(id);
            return View();
        }



        /*

        [HttpGet]
        public ActionResult searchuserr(string email)
        {
            var y = db.Users.Where(x => x.Email == email);
            return View(y);
        }






        [HttpGet]
        public ActionResult searchuser()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult searchuser(string email)
        {
            string message;
            var y = db.Users.Where(x => x.Email == email);
            if (y != null)
            {
                searchuserr(email);
                message = "";
                ViewBag.x = message;
            }
            else
            {
                message = "Invalid email !";
                ViewBag.x = message;
            }
            return View();
        }
         * */
        
     // [ActionName("searchuser")]
     









    }



}