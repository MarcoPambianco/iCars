using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using iCars.Models.Interfaces;
using iCars.Models.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace iCars.Models.Infrastructure
{
    public class SqlClientService : IDbParcoAccessor
    {
        private readonly IOptionsMonitor<DatabaseOptions> databaseOptions;
        private readonly ILogger logger;
        public SqlClientService(IOptionsMonitor<DatabaseOptions> databaseOptions,
                                ILogger<SqlClientService> logger)
        {
            this.logger = logger;
            this.databaseOptions = databaseOptions;

        }
        public async Task<DataSet> GetDataFromQueryAsync(FormattableString formattableQuery)
        {

            var queryArgs = formattableQuery.GetArguments();
            List<SqlParameter> lsParam = new List<SqlParameter>();
            for (int i = 0; i < queryArgs.Length; i++)
            {
                SqlParameter par = new SqlParameter(i.ToString(), queryArgs[i]);
                lsParam.Add(par);
                queryArgs[i] = "@" + i;

            }

            string strQuery = formattableQuery.ToString();
            logger.LogInformation(strQuery);
            DataSet ds = new DataSet();

            using (var conn = new SqlConnection(databaseOptions.CurrentValue.connectionString))
            {
                await conn.OpenAsync();
                using (var sqlCommand = new SqlCommand(strQuery, conn))
                {
                    foreach (SqlParameter par in lsParam)
                    {
                        sqlCommand.Parameters.Add(par);
                    }

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


        public FormattableString GetQueryCars()
        {
            FormattableString query = $"select paTarga, paMarca, paModello, paImagePath from tabparco;";
            return query;
        }

        public FormattableString GetQueryDetailsCar(string strTarga)
        {
            FormattableString query = @$"select paTarga, paMarca, paModello, paImagePath, paKilometri, paDataImmatricolazione, paDataAcquisto, 
                                        paNuova, paCilindrata, paCavalli, paKw, paAlimentazione from tabparco where paTarga = {strTarga}
                                        order by paTarga ASC; 
                                        SELECT tabinterventi.*, tabtipointervento.*
                                        FROM   tabinterventi INNER JOIN
                                        tabtipointervento ON tabinterventi.inIdTipoIntervento = tabtipointervento.id
                                        WHERE inTarga = {strTarga} order by inDataIntervento DESC";
            return query;
        }
    }
}