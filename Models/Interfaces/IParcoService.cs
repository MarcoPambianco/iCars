using System.Collections.Generic;
using System.Threading.Tasks;
using iCars.ViewModels;

namespace iCars.Models.Interfaces
{
    public interface IParcoService
    {
     Task<List<CarViewModel>> GetParcoMacchine();    
     Task<CarDetailsViewModel> GetDettagliMacchinaAsync(string strTarga);
    }
}