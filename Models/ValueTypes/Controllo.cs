namespace iCars.Models.ValueTypes
{
    public class Controllo
    {
        public Controllo(TipoScadenza scadenza, int durata)
        {
            this.durata = durata;
            this.scadenza = scadenza;

        }
        public TipoScadenza scadenza { get; set; }
        public int durata { get; set; }

    }

    public enum TipoScadenza
    {
        Mesi,
        Kilometri
    }

}