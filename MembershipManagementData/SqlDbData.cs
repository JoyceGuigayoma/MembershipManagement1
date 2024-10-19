
using MembershipManagementModels;
using System.Data.SqlClient;

namespace MembershipManagementData
{
    public class SqlDbData : IDisposable
    {
        string connectionString
        = "Data Source=DESKTOP-20HVAVU\\SQLEXPRESS; Initial Catalog=MembershipManagement; Integrated Security=True;";
        //= "Server = tcp:20.205.140.106, 1433;Database= MembershipManagement; User Id = sa; Password = Joyce123;";
        SqlConnection sqlConnection;
        private bool disposed = false;

        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<Member> GetUsers()
        {
            string selectStatement = "SELECT username, password, recruit FROM users";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            List<Member> users = new List<Member>();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string username = reader["username"].ToString();
                string password = reader["password"].ToString();
                int recruit = Convert.ToInt32(reader["recruit"]);

                Member readUser = new Member
                {
                    username = username,
                    password = password,
                    recruit = recruit
                };

                users.Add(readUser);
            }

            sqlConnection.Close();
            return users;
        }

        public Member GetUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectStatement = "SELECT username, password, recruit FROM users WHERE username = @Username AND password = @Password";
                SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                selectCommand.Parameters.AddWithValue("@Username", username);
                selectCommand.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    SqlDataReader reader = selectCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        Member user = new Member
                        {
                            username = reader["username"].ToString(),
                            password = reader["password"].ToString(),
                            recruit = Convert.ToInt32(reader["recruit"])
                        };

                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching user: " + ex.Message);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public List<Member> GetMember()
        {
            string selectStatement = "SELECT username, recruit FROM users";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            List<Member> users = new List<Member>();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string username = reader["username"].ToString();
                int recruit = Convert.ToInt32(reader["recruit"]);

                Member readUser = new Member
                {
                    username = username,
                    recruit = recruit
                };

                users.Add(readUser);
            }

            sqlConnection.Close();
            return users;
        }



        public int AddUser(string username, string password, int recruit)
        {
            int success;

            string insertStatement = "INSERT INTO users (username, password, recruit) VALUES (@username, @password, @recruit)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@username", username);
            insertCommand.Parameters.AddWithValue("@password", password);
            insertCommand.Parameters.AddWithValue("@recruit", recruit);

            try
            {
                sqlConnection.Open();
                success = insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding user: " + ex.Message);
                success = 0;
            }
            finally
            {
                sqlConnection.Close();
            }

            return success;
        }

        public int UpdateUser(string username, string password, int recruit)
        {
            int success;

            string updateStatement = "UPDATE users SET password = @Password, recruit = @Recruit WHERE username = @Username";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@Password", password);
            updateCommand.Parameters.AddWithValue("@Recruit", recruit);
            updateCommand.Parameters.AddWithValue("@Username", username);

            try
            {
                sqlConnection.Open();
                success = updateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating user: " + ex.Message);
                success = 0;
            }
            finally
            {
                sqlConnection.Close();
            }

            return success;
        }

        public int DeleteUser(string username)
        {
            int success;

            string deleteStatement = "DELETE FROM users WHERE username = @username";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            deleteCommand.Parameters.AddWithValue("@username", username);

            try
            {
                sqlConnection.Open();
                success = deleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting user: " + ex.Message);
                success = 0;
            }
            finally
            {
                sqlConnection.Close();
            }

            return success;
        }

        public List<Member> GetUsersByRecruit(int recruitStatus)
        {
            string query = "SELECT username, password, recruit FROM users WHERE recruit = @RecruitStatus";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@RecruitStatus", recruitStatus);

            List<Member> users = new List<Member>();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string username = reader["username"].ToString();
                    string password = reader["password"].ToString();
                    int recruit = Convert.ToInt32(reader["recruit"]);

                    Member readUser = new Member
                    {
                        username = username,
                        password = password,
                        recruit = recruit
                    };

                    users.Add(readUser);
                }

                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching users by recruit status: " + ex.Message);
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<Member> GetAllUsers()
        {
            string selectStatement = "SELECT username, password, recruit FROM users"; 
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            List<Member> users = new List<Member>();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string username = reader["username"].ToString();
                string password = reader["password"].ToString();
                int recruit = Convert.ToInt32(reader["recruit"]);

                Member readUser = new Member
                {
                    username = username,
                    password = password,
                    recruit = recruit
                };

                users.Add(readUser);
            }

            sqlConnection.Close();
            return users;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                    sqlConnection.Dispose();
                }



                disposed = true;
            }
        }

        ~SqlDbData()
        {
            Dispose(false);
        }
    }
}

