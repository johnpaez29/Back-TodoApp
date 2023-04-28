using Microsoft.Extensions.Configuration;
using TodoServiceApp.Model.DTO;

namespace ToDoServiceApp.DataService.Utils
{
    public static class Utils
    {
        public static string GetConectionString(IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString(Constants.CONNECTIONSTRING_SQL) ?? string.Empty;
            return connection;
        }

    }
}
