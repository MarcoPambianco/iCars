using iCars.Models.ValueTypes;

namespace iCars.ViewModels
{
    public class CarViewModel
    {
        public string strTarga { get; set; }
        public Produttore strMarca { get; set; }
        public string strModello { get; set; }
        public int Kilometri { get; set; }
        public string strImagePath { get; set; }
        
    }
}