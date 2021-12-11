using System;
using System.Collections.Generic;
using System.Data;
using iCars.Models.ValueTypes;

namespace iCars.ViewModels
{
    public class CarDetailsViewModel : CarViewModel
    {
        public EngineDetails motorizzazione { get; set; }
        public DateTime dDataImmatricolazione { get; set; }
        public DateTime dDataAcquisto { get; set; }
        public bool bNuova { get; set; }

        public List<InterventiViewModel> lsInterventi { get; set; }

        public static new CarDetailsViewModel FromDataRow (DataRow dtr)
        {
            CarDetailsViewModel car = new CarDetailsViewModel {
                strTarga = Convert.ToString(dtr["paTarga"]),
                strMarca = Enum.Parse<Produttore>(Convert.ToString(dtr["paMarca"])),
                strModello = Convert.ToString(dtr["paModello"]),
                Kilometri = Convert.ToInt32(dtr["paKilometri"]),
                strImagePath = Convert.ToString(dtr["paImagePath"]),
                dDataImmatricolazione = Convert.ToDateTime(dtr["paDataImmatricolazione"]),
                dDataAcquisto = Convert.ToDateTime(dtr["paDataAcquisto"]),
                motorizzazione = new EngineDetails() {
                    cilindrata = Convert.ToInt16(dtr["paCilindrata"]),
                    cavalli = Convert.ToInt16(dtr["paCavalli"]),
                    kw = Convert.ToInt16(dtr["paKw"]),
                    alimentazione = Enum.Parse<Carburante>(Convert.ToString(dtr["paAlimentazione"]))
                },
                lsInterventi = new List<InterventiViewModel>()  
            };

            return car;
        }
    }
}