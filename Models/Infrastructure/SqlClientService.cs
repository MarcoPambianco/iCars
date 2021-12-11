using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using iCars.Models.Interfaces;
using iCars.Models.Options;
using Microsoft.Extensions.Options;

namespace iCars.Models.Infrastructure
{
    public class SqlClientService : IDbParcoAccessor
    {
        private readonly IOptionsMonitor<DatabaseOptions> databaseOptions;
        public SqlClientService(IOptionsMonitor<DatabaseOptions> databaseOptions)
        {
            this.databaseOptions = databaseOptions;

        }
        public async Task<DataSet> GetDataFromQueryAsync(string strQuery)
        {
            DataSet ds = new DataSet();

            using (var conn = new SqlConnection(databaseOptions.CurrentValue.connectionString))
            {
                await conn.OpenAsync();
                using (var sqlCommand = new SqlCommand(strQuery, conn))
                {
                    using (SqlDataReader reader = await sqlCommand.ExecuteReaderAsync())
                    {

                        while (!reader.IsClosed)
                        {

                            DataTable dtt = new DataTable();
                            dtt.Load(reader);
                            ds.Tables.Add(dtt);
                        }
                    };
                };
            };

            return ds;
        }

        public string GetQueryCars()
        {
            string query = "select paTarga, paMarca, paModello, paImagePath from tabparco;";
            return query;
        }

        public string GetQueryDetailsCar(string strTarga)
        {
            string query = @$"select paTarga, paMarca, paModello, paImagePath, paKilometri, paDataImmatricolazione, paDataAcquisto, 
                             paNuova, paCilindrata, paCavalli, paKw, paAlimentazione from tabparco where paTarga = '{strTarga}' 
                             order by paTarga ASC; 
                             SELECT tabinterventi.*, tabtipointervento.*
                             FROM   tabinterventi INNER JOIN
                                    tabtipointervento ON tabinterventi.inIdTipoIntervento = tabtipointervento.id
                             WHERE inTarga = '{strTarga}' order by inDataIntervento DESC";
            return query;
        }
    }
}