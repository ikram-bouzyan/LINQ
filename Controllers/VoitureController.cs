using Microsoft.AspNetCore.Mvc;
using Tp5_LINQ.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tp5_LINQ.Controllers
{
    public class VoitureController : Controller
    {
        public static List<Voiture> ListVoiture = new List<Voiture>();
        static int id = 1;

        

        public IActionResult Index()
        {
            ViewBag.Voiture = ListVoiture;
            return View();
        }

        [HttpGet]
        public IActionResult Ajouter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ajouter([FromForm] Voiture vr)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Voiture non vide";
                return RedirectToAction("Index");
            }

            TempData["success"] = "voiture Ajoutee";
            vr.Id = id;
            ListVoiture.Add(vr);
            id++;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Modifier(int id = 0)
        {
            Voiture v = ListVoiture.Find(v => v.Id == id);
            return View(v);
        }

        [HttpPost]
        public IActionResult Modifier(Voiture vr)
        {
            Voiture v = ListVoiture.Find(v => v.Id == vr.Id);
            v.Kilometrage = vr.Kilometrage;
            v.AnneeImmatriculation = vr.AnneeImmatriculation;
            v.Marque = vr.Marque;
            v.Model = vr.Model;
            v.Type = vr.Type;
            return RedirectToAction("Index");
        }

        public IActionResult Supprimer(int id = 0)
        {
            Voiture v = ListVoiture.Find(v => v.Id == id);
            ListVoiture.Remove(v);
            return RedirectToAction("Index");
        }


        public IActionResult Afficher()
        {
            IEnumerable<Voiture> list25 = ListVoiture.Where(v => v.Kilometrage >= 25000);
            //IEnumerable<Voiture> list19 = ListVoiture.Where(v => v.AnneeImmatriculation.Year == 2019);
            //IEnumerable<Voiture> listBA15 = ListVoiture.Where(v => v.AnneeImmatriculation.Year >= 2015 && v.Type == "Berline");
            ViewBag.Voiture = list25;
            return View();
        }
        [HttpGet]
        public IActionResult Rechercher()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Rechercher([FromForm] string marque, [FromForm] string trier)
        {

            if (!string.IsNullOrEmpty(marque))
            {
                var lvv = ListVoiture.Where(v => v.Marque.ToUpper().Contains(marque.ToUpper()));

                switch (trier)
                {
                    case "TAnnee":
                        lvv = lvv.OrderByDescending(s => s.AnneeImmatriculation.Year);
                        break;
                    case "TKilo":
                        lvv = lvv.OrderByDescending(s => s.Kilometrage);
                        break;
                    default:
                        lvv = lvv.OrderBy(s => s.Type);
                        break;
                }

                ViewBag.lr = lvv;
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}
