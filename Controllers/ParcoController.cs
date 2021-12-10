using System.Collections.Generic;
using iCars.Models.Interfaces;
using iCars.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace iCars.Controllers
{
    public class ParcoController : Controller
    {
        private readonly IParcoService parcoService;
        public ParcoController(IParcoService parcoService)
        {
            this.parcoService = parcoService;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Parco macchine";
            
            // leggo l'elenco delle macchine del parco
            List<CarViewModel> lsAuto = parcoService.GetParcoMacchine();

            return View(lsAuto);
        }

    }
}