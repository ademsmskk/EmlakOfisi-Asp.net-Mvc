using EmlakOfisi.AppClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmlakOfisi.Controllers
{
    //Bu controller içindeki controller açılması için giriş yapılması gerekmektedir.
    [Authorize]
    [Authorize(Roles = "admin")]
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        public ActionResult Index()
        { 
            
            // Tüm kullanıcıları users değişkenine atama işlemi
           MembershipUserCollection users = Membership.GetAllUsers();
            return View(users);
        }

        [AllowAnonymous]
        public ActionResult KullaniciEkle()
        {
            return View();
        }
        [AllowAnonymous]
        //Fonksiyonun tipi postdur.
        [HttpPost]
        //Kullanıcı sınıfından parametre alıyor
        public ActionResult KullaniciEkle(Kullanici k)
        {
            //Kullanıcı oluşturma sırasında durum kontrolü için değişken tanımlama.Durum değişkeni burada bir enum tipi.
            MembershipCreateStatus durum;

            //kullanıcı oluşturma
            Membership.CreateUser(k.KullaniciAdi, k.Parola, k.Email, k.FirmaAdi, k.FirmaAdiTekrar, true, out durum);
            //  MembershipCreateStatus enum olduğundan durum değerleri bu şekilde belirlendi ve değer atamaları yapıldı.

            string mesaj ="";
            
            
            switch (durum)
            {
                case MembershipCreateStatus.Success:
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    mesaj += "Geçersiz kullanıcı adı girdiniz";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    mesaj += "Geçersiz parola girdiniz";
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    mesaj += "Geçersiz firma adı girdiniz";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    mesaj += "Geçersiz firma adı girdiniz";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    mesaj += "Geçersiz Email girdiniz";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    mesaj += "Kullanılmış kullanıcı adı girdiniz";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    mesaj += "Kullanılan Email Girdiniz.";
                    break;
                case MembershipCreateStatus.UserRejected:
                    mesaj += "Kullanıcı engel hatası";
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    mesaj += "Geçersiz kullanıcı key hatası";
                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    mesaj += "Kullanılan UserKey Girildi.";
                    break;
                case MembershipCreateStatus.ProviderError:
                    mesaj += "Üye yönetimi sağlayıcısı hatası";
                    break;
                default:
                    break;
            }

            ViewBag.Mesaj = mesaj;
            if (durum == MembershipCreateStatus.Success)
            {
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }



        }

    }
}