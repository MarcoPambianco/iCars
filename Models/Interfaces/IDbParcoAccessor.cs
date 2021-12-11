using System.Data;
using System.Threading.Tasks;

namespace iCars.Models.Interfaces
{
    public interface IDbParcoAccessor
    {
         string GetQueryCars();
         string GetQueryDetailsCar(string strTarga);
         Task<DataSet> GetDataFromQueryAsync(string strQuery);
    }
}