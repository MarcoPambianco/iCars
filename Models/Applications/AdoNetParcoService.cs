using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
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

        public async Task<List<CarViewModel>> GetParcoMacchine()
        {
            string query = dbService.GetQueryCars();
            DataSet dsParco = await dbService.GetDataFromQueryAsync(query);
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

        public async Task<CarDetailsViewModel> GetDettagliMacchinaAsync(string strTarga)
        {

            string query = dbService.GetQueryDetailsCar(strTarga);
            DataSet ds = await dbService.GetDataFromQueryAsync(query);
            if (ds.Tables.Count == 0)
            {
                throw new InvalidExpressionException("Errore leggendo i dati del parco");
            }
            DataTable dttCar = ds.Tables[0];
            DataTable dttInterventi = ds.Tables[1];

            CarDetailsViewModel car = CarDetailsViewModel.FromDataRow(dttCar.Rows[0]);

            foreach (DataRow dtr in dttInterventi.Rows)
            {
                InterventiViewModel intervento = InterventiViewModel.FromDataRow(dtr);
                car.lsInterventi.Add(intervento);
            }

             return car;
        }
    }
}