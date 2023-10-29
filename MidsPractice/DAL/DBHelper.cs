using Microsoft.Data.SqlClient;

namespace MidsPractice.DAL
{
    public class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=prac;Integrated Security=True;TrustServerCertificate=true;");
            return conn;
        }
    }
}
