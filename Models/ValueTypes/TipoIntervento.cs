using System;

namespace iCars.Models.ValueTypes
{
    public class TipoIntervento
    {

        public TipoIntervento(int id, string descrizione, TipoScadenza tipoScadenza, int durata)
        {
            nId = id;
            strDescrizione = descrizione;
            this.tipoScadenza = tipoScadenza;
            this.durata = durata;
        }


        public int nId { get; private set; }
        public string strDescrizione { get; private set; }

        public TipoScadenza tipoScadenza { get; set; }
        public int durata { get; set; }


        public void CambiaDescrizione(string strNewdescr) {
            if (strNewdescr.Trim() == "") 
            {
                throw new InvalidOperationException("La descrizione non può essere vuota");
            }
            strDescrizione = strNewdescr;
        }
        
        public override string ToString() {
            
            string scadenza = "";
            if (tipoScadenza == TipoScadenza.Kilometri)
            {
                scadenza = "Km";
            } else {
                scadenza = Convert.ToString(tipoScadenza);
            }
            string strTipoIntervento = scadenza + " " + Convert.ToString(durata);

            return strTipoIntervento;
        }
    }
}