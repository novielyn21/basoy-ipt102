using BasoyIPT102FinalProject.Classes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Security.Claims;
#nullable disable
using Dapper;
using Microsoft.Data.SqlClient;
namespace BasoyIPT102FinalProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration config;

        [BindProperty]
        public Accounts acc { get; set; }
        public bool IsAuthenticated { get; private set; }
        public IndexModel(IConfiguration _config)
        {
            config = _config;
        }
        public IActionResult OnGet()
        {
            IsAuthenticated = User?.Identity?.IsAuthenticated ?? false;
            return Page();
        }
        public IActionResult OnPostLogin()
        {
            if (ModelState.IsValid)
            {
                using var sqlcon = new SqlConnection(config.GetConnectionString("BASOY"));
                var storeProcedure = "[dbo].[Login]";
                var parameter = new DynamicParameters();
                parameter.Add("@username", acc.username, DbType.String, ParameterDirection.Input);
                parameter.Add("@password", acc.password, DbType.String, ParameterDirection.Input);
                var user = sqlcon.QueryFirstOrDefault<Accounts>(storeProcedure, parameter);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, user.username),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties { };

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToPage("/AddBioData");
                }
            }

            return Page();
        }
        public IActionResult OnPostCreate()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using var sqlcon = new SqlConnection(config.GetConnectionString("BASOY"));
            var storeProcedure = "[dbo].[Create]";
            var parameter = new DynamicParameters();
            parameter.Add("@username", acc.username, DbType.String, ParameterDirection.Input);
            parameter.Add("@password", acc.password, DbType.String, ParameterDirection.Input);
            sqlcon.Execute(storeProcedure, parameter, commandType: CommandType.StoredProcedure);
            return RedirectToPage("/Index");
        }
    }
}
