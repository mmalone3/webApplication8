using System;
using System.Data;
using System.Data.OleDb; // Change to OleDb
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication8
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString3"].ConnectionString;
            using (OleDbConnection connection = new OleDbConnection(connectionString)) // Change to OleDbConnection
            {
                string query = "SELECT [ID], [User_id], [PlainTextPassword] FROM [user_data] WHERE [User_id] = @UserId AND [PlainTextPassword] = @Password";
                OleDbCommand command = new OleDbCommand(query, connection); // Change to OleDbCommand
                command.Parameters.AddWithValue("@UserId", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader(); // Change to OleDbDataReader
                if (reader.HasRows)
                {
                    // User authenticated successfully
                    if (reader.Read())
                    {
                        Session["UserID"] = reader["ID"];
                        Session["Username"] = reader["User_id"];
                    }
                    Response.Redirect("Profile.aspx");
                }
                else
                {
                    // Authentication failed
                    ErrorMessageLabel.Text = "Invalid username or password.";
                }
            }
        }
    }
}
