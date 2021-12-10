using System;

namespace iCars.Models.ValueTypes
{
    public class TipoIntervento
    {

        public TipoIntervento(int id, string descrizione)
        {
            strDescrizione = descrizione;
            nId = id;
            prossimoControllo = new Controllo(TipoScadenza.Kilometri, 0);
        }

        public TipoIntervento(int id, string descrizione, Controllo contr)
        {
            nId = id;
            strDescrizione = descrizione;
            prossimoControllo = contr;
        }

        public int nId { get; private set; }
        public string strDescrizione { get; private set; }
        public Controllo prossimoControllo { get;private set; }


        public void CambiaDescrizione(string strNewdescr) {
            if (strNewdescr.Trim() == "") 
            {
                throw new InvalidOperationException("La descrizione non può essere vuota");
            }
            strDescrizione = strNewdescr;
        }
        
        public void CambiaProssimoControllo(Controllo newControllo){
            if (newControllo is null)
            {
                throw new InvalidOperationException("L'oggetto non può essere nullo");
            }
            prossimoControllo = newControllo;
        }

    }
}