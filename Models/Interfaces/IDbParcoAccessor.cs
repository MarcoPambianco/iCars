using System.Data;

namespace iCars.Models.Interfaces
{
    public interface IDbParcoAccessor
    {
         string GetQueryCars();
         string GetQueryDetailsCar(string strTarga);
         DataSet GetDataFromQuery(string strQuery);
    }
}