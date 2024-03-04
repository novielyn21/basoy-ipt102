using BasoyBlazorApp.Classes;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BasoyBlazorApp.DBSTORE
{
    public class StudentListDb
    {
        private readonly SqlConnection connection;
        private readonly IConfiguration config;

        public StudentListDb(IConfiguration _config)
        {
            config = _config;
            connection = new SqlConnection(config.GetConnectionString("BASOY"));
        }

        public IEnumerable<Student> list()
        {
            var sqlstr = "DisplayStudentList";
            return connection.Query<Student>(sqlstr);
        }
        public void Delete(int Id)
        {
            var sqlstr = "Delete";
            var parameter = new { StudentId = Id };
            connection.Execute(sqlstr, parameter, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<Student> SearchById(int Id)
        {
            var sqlstr = "SearchById";
            var parameter = new { StudentId = Id };
            return connection.Query<Student>(sqlstr, parameter);
        }
        public void Update(Student student)
        {
            var sqlstr = "Update";
            var parameter = new DynamicParameters();
            parameter.Add("@StudentId", student.StudentId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@FirstName", student.FirstName, DbType.String, ParameterDirection.Input);
            parameter.Add("@LastName", student.LastName, DbType.String, ParameterDirection.Input);
            parameter.Add("@Email", student.Email, DbType.String, ParameterDirection.Input);
            parameter.Add("@Country", student.Country, DbType.String, ParameterDirection.Input);
            parameter.Add("@SMessage", student.SMessage, DbType.String, ParameterDirection.Input);
            connection.Execute(sqlstr, parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
