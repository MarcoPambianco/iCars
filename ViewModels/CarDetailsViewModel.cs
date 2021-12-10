using System.Collections.Generic;
using iCars.Models.ValueTypes;

namespace iCars.ViewModels
{
    public class CarDetailsViewModel : CarViewModel
    {
        public EngineDetails motorizzazione { get; set; }
        public int nAnnoImmatricolazione { get; set; }
        public int nAnnoAcquisto { get; set; }
        public bool bNuova { get; set; }

        public List<InterventiViewModel> lsInterventi { get; set; }
    }
}