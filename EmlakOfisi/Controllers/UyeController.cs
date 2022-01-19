using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmlakOfisi.Controllers
{   
    
    
    //Classtaki Kullanıcılara erişim sağlıyoruz.
    using AppClasses;
    using System.Web.Security;
    //Bu controller içindeki controller açılması için giriş yapılması gerekmektedir.
    [Authorize]
    public class UyeController : Controller
    { 
        //Altındaki Action'a her kullanıcı açabilir amacımız giriş yapma sayfasına herkesin kullanımına izin vermek.
        [AllowAnonymous]
        public ActionResult GirisYap()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult GirisYap(Kullanici k,string Hatirla)
        {
            //kullanıcı girişini kontrol eden fonksiyon bunu da bool değişkenine atadık.
            bool sonuc = Membership.ValidateUser(k.KullaniciAdi, k.Parola);
            if (sonuc)
            {
                //Cookie de oturum açılıp açılmayacağını kontrol ediyoruz.
                if (Hatirla == "on")
                    FormsAuthentication.RedirectFromLoginPage(k.KullaniciAdi, true);
                else
                    FormsAuthentication.RedirectFromLoginPage(k.KullaniciAdi, false);

                return RedirectToAction("Index", "Home");


            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı adı veya parola hatalı";
                return View();
            }

        }

        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap");
        }

        [AllowAnonymous]
        public ActionResult ParolamiUnuttum()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ParolamiUnuttum(Kullanici k)
        {  
            MembershipUser mu = Membership.GetUser(k.KullaniciAdi);

            if (k.FirmaAdi==k.FirmaAdiTekrar)
            {
              

                string pwd = mu.ResetPassword(k.FirmaAdiTekrar);
                mu.ChangePassword(pwd, k.Parola);
                return RedirectToAction("GirisYap");
            }
            else
            {
                ViewBag.Mesaj2 = "Girilen bilgiler yanlış";
                return View();
            }

        }
        
	      
	

    }
}