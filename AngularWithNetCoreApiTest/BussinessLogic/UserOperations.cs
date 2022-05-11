using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AngularWithNetCoreApiTest.BussinessLogic
{

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
    public class UserOperations
    {
        private IConfiguration Configuration;
        public UserOperations(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public string ConnectionString()
        {
            return this.Configuration.GetConnectionString("DefaultConnection");
        }
        public List<User> GetUsersData()
        {
            List<User> UsersData = new List<User>();
            DataTable userResult = new DataTable();
            try
            {
                SqlDataReader myReader;

                using (SqlConnection myCon = new SqlConnection(ConnectionString()))
                {
                    myCon.Open();
                    //GetSelectedUserData
                    using (SqlCommand myCommand = new SqlCommand("GetUsersData", myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        userResult.Load(myReader);

                        myReader.Close();
                        myCon.Close();
                        foreach (DataRow row in userResult.Rows)
                        {
                            User userData = new User();
                            userData.FirstName = row["FirstName"].ToString();
                            userData.LastName = row["LastName"].ToString();
                            userData.Mobile = row["Mobile"].ToString();
                            userData.Email = row["Email"].ToString();
                            userData.Id = Convert.ToInt32(row["Id"].ToString());
                            UsersData.Add(userData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return UsersData;

        }

        public User GetSelectedUserData(int UserId)
        {
            DataTable UserResult = new DataTable();
            User UserData = new User();
            try
            {
                SqlDataReader myReader;

                using (SqlConnection myCon = new SqlConnection(ConnectionString()))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand("GetSelectedUserData", myCon))
                    {
                        myCommand.Parameters.Add(new SqlParameter("@UserId", UserId));
                        myReader = myCommand.ExecuteReader();
                        UserResult.Load(myReader);

                        myReader.Close();
                        myCon.Close();
                        foreach (DataRow row in UserResult.Rows)
                        {
                            UserData.FirstName = row["FirstName"].ToString();
                            UserData.LastName = row["LastName"].ToString();
                            UserData.Mobile = row["Mobile"].ToString();
                            UserData.Email = row["Email"].ToString();
                            UserData.Id = Convert.ToInt32(row["Id"].ToString());
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return UserData;

        }

        public void InsertUserData(User userData)
        {
            DataTable objresutl = new DataTable();
            try
            {

                using (SqlConnection myCon = new SqlConnection(ConnectionString()))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand("InsertUser", myCon))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@FirstName", userData.FirstName);
                        myCommand.Parameters.AddWithValue("@LastName", userData.LastName);
                        myCommand.Parameters.AddWithValue("@Mobile", userData.Mobile);
                        myCommand.Parameters.AddWithValue("@Email", userData.Email);
                        myCommand.ExecuteNonQuery();
                        myCon.Close();
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }
    }
}
