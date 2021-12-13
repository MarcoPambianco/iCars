using System.Collections.Generic;
using System.Threading.Tasks;
using iCars.Models.Interfaces;
using iCars.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace iCars.Controllers
{
    public class ParcoController : Controller
    {
        private readonly IParcoService parcoService;
        private readonly ILogger<ParcoController>  logger;
        public ParcoController(ICachedParcoService parcoService, ILogger<ParcoController> logger)
        {
            this.logger = logger;
            this.parcoService = parcoService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Parco macchine";

            // leggo l'elenco delle macchine del parco
            List<CarViewModel> lsAuto = await parcoService.GetParcoMacchineAsync();

            return View(lsAuto);
        }

        public async Task<IActionResult> Interventi(string strTarga)
        {

            // leggo i dettagli dell'auto e i relativi interventi
            CarDetailsViewModel carDetails = await parcoService.GetDettagliMacchinaAsync(strTarga);
            return View(carDetails);
        }

    }
}