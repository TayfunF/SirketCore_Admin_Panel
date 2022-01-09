using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SirketCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SirketCore.Controllers
{
    public class PersonelimController : Controller
    {
        private readonly Context _context;
        public PersonelimController(Context context)
        {
            _context = context;
        } 
        [Authorize]
        public IActionResult Index()
        {
            var listele = _context.Personels.Include(x=>x.Birim).ToList();
            return View(listele);
        }

        [HttpGet]
        public IActionResult YeniPersonel()
        {
            //DropDownListFor Backend Kısmı
            ViewBag.yeniPersonel = _context.Birims.ToList();
            return View();
        }
        public IActionResult YeniPersonel(Personel p)
        {
            var personelEkle = _context.Birims.Where(x => x.BirimID == p.Birim.BirimID).FirstOrDefault();
            p.Birim = personelEkle;
            _context.Personels.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
