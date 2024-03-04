#nullable disable
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using BasoyBlazorApp.Classes;

namespace BasoyBlazorApp.DBSTORE
{
    public class IndexDb
    {
        private readonly SqlConnection konek;
        private readonly IConfiguration config;

        public IndexDb(IConfiguration _config)
        {
            config = _config;
            konek = new SqlConnection(config.GetConnectionString("BASOY"));
        }
        public void Create(Student NewPerson)
        {
            var sqlstring = "[dbo].[NewStudent]";
            var parameter = new DynamicParameters();
            parameter.Add("@FirstName", NewPerson.FirstName, DbType.String, ParameterDirection.Input);
            parameter.Add("@LastName", NewPerson.LastName, DbType.String, ParameterDirection.Input);
            parameter.Add("@Email", NewPerson.Email, DbType.String, ParameterDirection.Input);
            parameter.Add("@Country", NewPerson.Country, DbType.String, ParameterDirection.Input);
            parameter.Add("@SMessage", NewPerson.SMessage, DbType.String, ParameterDirection.Input);
            konek.Execute(sqlstring, parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
