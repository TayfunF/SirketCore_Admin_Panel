using Microsoft.AspNetCore.Mvc;
using SirketCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SirketCore.Controllers
{
    public class BirimController : Controller
    {
        private readonly Context _context;
        public BirimController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var listele = _context.Birims.ToList();
            return View(listele);
        }
        [HttpGet]
       public IActionResult YeniBirim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniBirim(Birim b)
        {
            _context.Birims.Add(b);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimSil(int id)
        {
            var brmSil = _context.Birims.Find(id);
            _context.Birims.Remove(brmSil);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimGetir(int id)
        {
            var brmGetir = _context.Birims.Find(id);
            return View("BirimGetir", brmGetir);
        }
        public IActionResult BirimGuncelle(Birim b)
        {
            var brmGuncelle = _context.Birims.Find(b.BirimID);
            brmGuncelle.BirimAd = b.BirimAd;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult BirimDetay(int id)
        {
            /*
            var list = (from birim in _context.Birims.ToList()
                        join deger in _context.Personels.ToList()
                        on birim.BirimID equals deger.BirimID

                        select new {
                            personelAd = deger.Ad,
                            personelSoyad =deger.Soyad,
                            personelSehir = deger.Sehir
                        }
                        ).ToList();
            */

            var degerler = _context.Personels.Where(x => x.BirimID == id).ToList();
            var brmad = _context.Birims.Where(x => x.BirimID == id).Select(y => y.BirimAd).FirstOrDefault();
            ViewBag.brm = brmad;
            return View(degerler);
        }
    }
}
