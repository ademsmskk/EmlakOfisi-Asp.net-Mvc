using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmlakOfisi.Controllers
{        //Bu controller içindeki controller açılması için giriş yapılması gerekmektedir.
    [Authorize]
    [Authorize(Roles = "admin")]
    public class RolController : Controller
    {

        public ActionResult Index()
        {

            //Tüm rolleri string tipinde roller değişkenine atadık.
         List<string> roller=  Roles.GetAllRoles().ToList();
            return View(roller);
        }
        // Rol Ekleme işlemleri
        public ActionResult RolEkle()
        {
            return View();

        }

        [HttpPost]
        public ActionResult RolEkle(string RolAdi)
        {
            Roles.CreateRole(RolAdi);
            return RedirectToAction("Index");
        }
        /*
        Rol atama işlemleri yapan fonksiyon.
        Rolata fonksiyonu string türünde parametre alıyor,
        id yazılmasının sebebi rootconfig sınıfında id diye belirlendiği 
        için id değeri verilir.
        */


        //Sadece admin kullanıcısının erişimi sağlayan ifade.
        [Authorize(Roles ="admin")]
        public ActionResult RolAta()
        {
            ViewBag.Roller = Roles.GetAllRoles().ToList();
            ViewBag.Kullanicilar = Membership.GetAllUsers();
            return View();
        }

        //Sadece admin kullanıcısının erişimi sağlayan ifade.
        [Authorize(Roles = "admin")]
        [HttpPost]

        public ActionResult RolAta(string KullaniciAdi, string RolAdi)
        {
            Roles.AddUserToRole(KullaniciAdi, RolAdi);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public string UyeRolleri(string kadi)
        {
         List<string> roller =   Roles.GetRolesForUser(kadi).ToList();
            string rol = "";
            foreach (string  r in roller)
            {
                rol += r + "-";
              
            }
                rol = rol.Remove(rol.Length - 1, 1);
                return rol;

        }

    }
}