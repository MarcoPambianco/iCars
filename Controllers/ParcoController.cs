using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Parco macchine";
            
            // leggo l'elenco delle macchine del parco
            List<CarViewModel> lsAuto = await parcoService.GetParcoMacchine();

            return View(lsAuto);
        }

        public async Task<IActionResult> Interventi(string strTarga) {
            
            CarDetailsViewModel carDetails = await parcoService.GetDettagliMacchinaAsync(strTarga);
            
            return View(carDetails);
        }

    }
}