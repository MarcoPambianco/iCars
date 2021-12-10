using System.Collections.Generic;
using iCars.ViewModels;

namespace iCars.Models.Interfaces
{
    public interface IParcoService
    {
     List<CarViewModel> GetParcoMacchine();    
     CarDetailsViewModel GetDettagliMacchina(string strTarga);
    }
}