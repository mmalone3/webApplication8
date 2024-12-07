using System;

namespace WebApplication8
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] != null && Session["Username"] != null)
                {
                    UsernameLabel.Text = Session["Username"].ToString();
                    UserIDLabel.Text = Session["UserID"].ToString();
                }
                else
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        protected global::System.Web.UI.WebControls.Label UsernameLabel;
        protected global::System.Web.UI.WebControls.Label UserIDLabel;
    }
}