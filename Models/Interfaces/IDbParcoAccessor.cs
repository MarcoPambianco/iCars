using System;
using System.Data;
using System.Threading.Tasks;

namespace iCars.Models.Interfaces
{
    public interface IDbParcoAccessor
    {
         FormattableString GetQueryCars();
         FormattableString GetQueryDetailsCar(string strTarga);
         Task<DataSet> GetDataFromQueryAsync(FormattableString strQuery);
    }
}