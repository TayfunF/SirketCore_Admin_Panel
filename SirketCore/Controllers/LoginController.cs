using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SirketCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SirketCore.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;
        public LoginController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }

        public async Task<IActionResult> GirisYap(Admin p)
        {
           /* 
              Önce kullanıcı bilgisi kontrol edilir.
              Eğer kullanıcı varsa
              HttpContext.Session.SetInt32("session_adi", bilgiler.id); //Session kaydı

              ViewBag.UserId = HttpContext.Session.GetInt32("session_adi"); //Session get alma


              Her girişi zorunlu sayfada viewbag'in null olup olmadığını kontrol et
              Boşsa logine at
              Değilse view'i göster
           */
           //İLERİ SEVİYE IDENTITY SERVER 4 KONUSU BU
           //3 FARKLI YÖNTEM VAR ;
           /*
            1-) Claim Bazlı Doğrulama
            2-) Rol Bazlı Doğrulama
            3-) Cookie Bazlı Doğrulama
            */
            var bilgiler = _context.Admins.FirstOrDefault(x => x.Kullanici == p.Kullanici && x.Sifre == p.Sifre);
            if(bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.Kullanici)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Personelim");
            }
            return View();
        }

        public async Task<IActionResult> CikisYap()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("GirisYap");

        }
    }
}
