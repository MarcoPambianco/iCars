using System.Collections.Generic;
using System.Data;
using iCars.Models.Infrastructure;
using iCars.Models.Interfaces;
using iCars.ViewModels;

namespace iCars.Models.Applications
{
    public class AdoNetParcoService : IParcoService
    {
        private readonly IDbParcoAccessor dbService;

        public AdoNetParcoService(IDbParcoAccessor dbService)
        {
            this.dbService = dbService;
        }

        public List<CarViewModel> GetParcoMacchine()
        {
            string query = dbService.GetQueryCars();
            DataSet dsParco = dbService.GetDataFromQuery(query);
            if (dsParco.Tables.Count == 0)
            {
                throw new InvalidExpressionException("Errore leggendo i dati del parco");
            }

            List<CarViewModel> parco = new List<CarViewModel>();
            foreach (DataRow dtr in dsParco.Tables[0].Rows)
            {
                CarViewModel car = CarViewModel.FromDataRow(dtr);
                parco.Add(car);
            }

            return parco;
        }

        public CarDetailsViewModel GetDettagliMacchina(string strTarga)
        {

            string query = dbService.GetQueryDetailsCar(strTarga);
            DataSet ds = dbService.GetDataFromQuery(query);
            if (ds.Tables.Count == 0)
            {
                throw new InvalidExpressionException("Errore leggendo i dati del parco");
            }
            

             throw new System.NotImplementedException();
        }
    }
}