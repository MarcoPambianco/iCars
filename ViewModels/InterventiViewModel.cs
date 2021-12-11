using System;
using System.Data;
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

        public static InterventiViewModel FromDataRow(DataRow dtr)
        {
            InterventiViewModel intervento = new InterventiViewModel {
              idIntervento = Convert.ToInt16(dtr["id"]),
              strDescr = Convert.ToString(dtr["inDescrizione"]),
              dataIntervento = Convert.ToDateTime(dtr["inDataIntervento"]),
              kilometriMacchina = Convert.ToInt16(dtr["inKilometriMacchina"]),
              tipoIntervento = new TipoIntervento(Convert.ToInt16(dtr["inIdTipoIntervento"]), 
                                                  Convert.ToString(dtr["tiDescrizione"]),
                                                  Enum.Parse<TipoScadenza>(Convert.ToString(dtr["tiTipoScadenza"])),
                                                  Convert.ToInt32(dtr["tiDurata"])
                                                  ) 
            };

            return intervento;
        }

        public string DataToString(DateTime data){
            string strData = Convert.ToString(data).Substring(0, 10);
            return strData;
        }

        public string GetProssimoControllo() {
            string strProssimoControllo ="";

            if (tipoIntervento.tipoScadenza == TipoScadenza.Kilometri) {
                strProssimoControllo = "Km " + Convert.ToString(kilometriMacchina + tipoIntervento.durata);
            } else if (tipoIntervento.tipoScadenza == TipoScadenza.Mesi) {
                strProssimoControllo = DataToString(dataIntervento.AddMonths(tipoIntervento.durata));
            }

            return strProssimoControllo;
        }
    }

}