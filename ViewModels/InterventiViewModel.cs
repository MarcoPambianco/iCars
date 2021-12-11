using System;
using iCars.Models.ValueTypes;

namespace iCars.ViewModels
{
    public class InterventiViewModel
    {
        public int idIntervento { get; set; }
        public string strDescr { get; set; }
        public DateTime dataIntervento { get; set; }
        public int kilometriMacchina { get; set; }
        public TipoIntervento tipoIntervento { get; set; }
    }

    

}