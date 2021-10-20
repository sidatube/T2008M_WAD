using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using T2008M_WAD.Models;
using System.Web.Security;

namespace T2008M_WAD.Controllers
{
    public class AutheticateController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Autheticate
        public ActionResult Register()
        {
            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Email == user.Email);// lay user co email nhap vao
                if (check == null)
                {
                    // tao password - SHA256
                    user.Password = GetMD5(user.Password);
                    db.Users.Add(user);
                    db.SaveChanges();
                    FormsAuthentication.SetAuthCookie(user.Email, true);
                    return Redirect("/Categories");
                }
                else
                {
                    ViewBag.Error = "Email này đã tồn tại";
                }
            }
            return View();
        }
        public static string GetMD5(string str)
        {
            MD5 md5 =new MD5CryptoServiceProvider();
            byte[] frData = Encoding.UTF8.GetBytes(str);
            byte[] toData = md5.ComputeHash(frData);
            string hashstring = "";
            for( int i=0;i< toData.Length; i++)
            {
                hashstring += toData[i].ToString("x2");
            }
            return hashstring;

        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                login.Password = GetMD5(login.Password);
                var data = db.Users.Where(s => s.Email.Equals(login.Email) && s.Password.Equals(login.Password)).FirstOrDefault();
                if (data != null)
                {
                    FormsAuthentication.SetAuthCookie(data.Email, true);
                    return Redirect("/Categories");
                }
            }
            return View();
        }
    }
}