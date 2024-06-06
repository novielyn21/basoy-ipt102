using BasoyIPT102FinalProject.Classes;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
#nullable disable
namespace BasoyIPT102FinalProject.Pages
{
    public class AddBioDataModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly SqlConnection connection;

        [BindProperty]
        public Persons persons { get; set; }
        public bool IsEditing { get; set; } = false;
        public List<Persons> AllPersons { get; set; }

        public AddBioDataModel(IConfiguration _config)
        {
            config = _config;
            connection = new SqlConnection(config.GetConnectionString("BASOY"));

            RetrieveAllPersons();
        }
        
        private void RetrieveAllPersons()
        {
            var sqlStr = "[dbo].[DisplayAllPersons]"; 

            AllPersons = connection.Query<Persons>(sqlStr, commandType: CommandType.StoredProcedure).AsList();
        }

        public IActionResult OnPostAddPerson()
        {
            var sqlStr = "[dbo].[AddPerson]";
            var param = new DynamicParameters();
            param.Add("@FirstName", persons.FirstName, DbType.String, ParameterDirection.Input);
            param.Add("@LastName", persons.LastName, DbType.String, ParameterDirection.Input);
            param.Add("@DateOfBirth", persons.DateOfBirth, DbType.Date, ParameterDirection.Input);
            param.Add("@Gender", persons.Gender, DbType.String, ParameterDirection.Input);
            param.Add("@Address", persons.Address, DbType.String, ParameterDirection.Input);
            param.Add("@PhoneNumber", persons.PhoneNumber, DbType.String, ParameterDirection.Input);
            param.Add("@Email", persons.Email, DbType.String, ParameterDirection.Input);
            param.Add("@Education", persons.Education, DbType.String, ParameterDirection.Input);
            param.Add("@Skills", persons.Skills, DbType.String, ParameterDirection.Input);
            connection.Execute(sqlStr, param, commandType: CommandType.StoredProcedure);
            persons = new Persons();
            RetrieveAllPersons();
            return Page();
        }

        public IActionResult OnPostUpdatePerson()
        {
            var sqlStr = "[dbo].[UpdatePerson]";
            var param = new DynamicParameters();
            param.Add("@PersonID", persons.PersonId, DbType.Int32, ParameterDirection.Input);
            param.Add("@FirstName", persons.FirstName, DbType.String, ParameterDirection.Input);
            param.Add("@LastName", persons.LastName, DbType.String, ParameterDirection.Input);
            param.Add("@DateOfBirth", persons.DateOfBirth, DbType.Date, ParameterDirection.Input);
            param.Add("@Gender", persons.Gender, DbType.String, ParameterDirection.Input);
            param.Add("@Address", persons.Address, DbType.String, ParameterDirection.Input);
            param.Add("@PhoneNumber", persons.PhoneNumber, DbType.String, ParameterDirection.Input);
            param.Add("@Email", persons.Email, DbType.String, ParameterDirection.Input);
            param.Add("@Education", persons.Education, DbType.String, ParameterDirection.Input);
            param.Add("@Skills", persons.Skills, DbType.String, ParameterDirection.Input);

            connection.Execute(sqlStr, param, commandType: CommandType.StoredProcedure);

            RetrieveAllPersons();
            persons = new();
            IsEditing = false;
            return Page();
        }

        public IActionResult OnGetFindPersonById(int personId)
        {
            var sqlStr = "[dbo].[FindPersonById]";
            var param = new DynamicParameters();
            param.Add("@PersonID", personId, DbType.Int32, ParameterDirection.Input);
            persons = connection.QueryFirstOrDefault<Persons>(sqlStr, param, commandType: CommandType.StoredProcedure);
            IsEditing = true;


            return Page();
        }

        public IActionResult OnGetDeletePerson(int personId)
        {
            var sqlStr = "[dbo].[DeletePerson]";
            var param = new DynamicParameters();
            param.Add("@PersonID", personId, DbType.Int32, ParameterDirection.Input);
            connection.Execute(sqlStr, param, commandType: CommandType.StoredProcedure);

            RetrieveAllPersons();

            return Page();
        }
        public IActionResult OnPostCancelUpdate()
        {
            IsEditing = false;
            return Page();
        }
        public IActionResult OnPostSearchPeople()
        {
            if (!string.IsNullOrEmpty(persons.FirstName))
            {
                var sqlStr = "[dbo].[SearchByName]";
                var param = new { CustomerName = persons.FirstName };
                AllPersons = connection.Query<Persons>(sqlStr, param).ToList();
                return Page();
            }
            else
            {
                return RedirectToPage();
            }
        }
        }
    }

