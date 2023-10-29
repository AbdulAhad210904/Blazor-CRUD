using Microsoft.Data.SqlClient;
using MidsPractice.Data;
using System.Data;

namespace MidsPractice.DAL
{
    public class DALUserForm
    {
        public static void SaveForm(UserForm um)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@FirstName",um.FirstName),
                new SqlParameter("@LastName",um.LastName),
                new SqlParameter("Email",um.Email),
                new SqlParameter("@Age",um.Age),
                new SqlParameter("@Country",um.Country),
                new SqlParameter("@Interests",um.Interests),
                new SqlParameter("@Comments",um.Comments)
            };
            CRUD.CUD("SaveUserForm", sp);
        }
        public static void UpdateForm(UserForm um)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("UserID",um.UserID),
                new SqlParameter("@FirstName",um.FirstName),
                new SqlParameter("@LastName",um.LastName),
                new SqlParameter("Email",um.Email),
                new SqlParameter("@Age",um.Age),
                new SqlParameter("@Country",um.Country),
                new SqlParameter("@Interests",um.Interests),
                new SqlParameter("@Comments",um.Comments)
            };
            CRUD.CUD("UpdateUserForm", sp);
        }
        public static void DeleteForm(UserForm um)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("UserID",um.UserID)
            };
            CRUD.CUD("DeleteUserForm", sp);
        }

        public static List<UserForm> GetFormsData()
        {
            List<UserForm> formlist = new List<UserForm>();
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetUserForms", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserForm um = new UserForm();
                um.UserID = int.Parse(reader["UserID"].ToString());
                um.FirstName = reader["FirstName"].ToString();
                um.LastName= reader["LastName"].ToString() ;
                um.Email= reader["Email"].ToString();
                um.Age = int.Parse(reader["Age"].ToString());
                um.Country = reader["Country"].ToString();
                um.Interests = reader["Comments"].ToString();
                um.Comments = reader["Comments"].ToString();
                formlist.Add(um);
            }
            conn.Close();
            return formlist;

        }

    }
}
