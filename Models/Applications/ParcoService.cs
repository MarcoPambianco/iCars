using System.Collections.Generic;
using iCars.Models.Interfaces;
using iCars.Models.ValueTypes;
using iCars.ViewModels;

namespace iCars.Models.Applications
{
    public class ParcoService : IParcoService 
    {
        public List<CarViewModel> GetParcoMacchine()
        {
            // per ora genero una lista di oggetti temporanei direttamente da codice

            List<CarViewModel> lsAuto = new List<CarViewModel>();

            CarViewModel car1 = new CarViewModel {
                strTarga = "GB621NN",
                strMarca = Produttore.Ford,
                strModello = "Puma 1.0 Hybrid STLine",
                Kilometri = 9800,
                strImagePath = "/Loghi/Ford.jpg"
            };

            lsAuto.Add(car1);

            CarViewModel car2 = new CarViewModel {
                strTarga = "AA123BB",
                strMarca = Produttore.Fiat,
                strModello = "500 1.3",
                Kilometri = 60000,
                strImagePath = "/Loghi/Fiat.jpg"
            };

            lsAuto.Add(car2);
            
            return lsAuto;
        }
    
        public CarDetailsViewModel GetDettagliMacchina(string strTarga)
        {
            CarDetailsViewModel carDetails = new CarDetailsViewModel {
                strTarga = strTarga,
                strMarca = Produttore.Ford,
                 strModello = "Puma 1.0 Hybrid STLine",
                Kilometri = 9800,
                motorizzazione = new EngineDetails {
                    cilindrata = 1000,
                    cavalli = 125,
                    kw = 93
                },
                lsInterventi = new List<InterventiViewModel>()
            };

            InterventiViewModel int1 = new InterventiViewModel{
                idIntervento = 1,
                strDescr = "Cambio Olio 30000 km",
                tipoIntervento = new TipoIntervento(1, "Cambio Olio", new Controllo(TipoScadenza.Kilometri, 30000)) 
            };
            carDetails.lsInterventi.Add(int1);

            InterventiViewModel int2 = new InterventiViewModel{
                idIntervento = 2,
                strDescr = "Cambio Gomme estive",
                tipoIntervento = new TipoIntervento(1, "Cambio Gomme", new Controllo(TipoScadenza.Kilometri, 45000)) 
            };
            carDetails.lsInterventi.Add(int2);
            
            throw new System.NotImplementedException();
        }

    }
}