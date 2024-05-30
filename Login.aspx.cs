using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinishGoodSMT
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Cookies["userLogin"] != null)
                {
                    HttpCookie myCookie = new HttpCookie("userLogin");
                    myCookie.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                }
                if ((string)Session["userLogin"] != null)
                {
                    Session.Remove("userLogin");
                }
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.AddHeader("Pragma", "no-cache");
            txtUsuario.Focus();
        }

        public void saveDataUser()
        {
            string username;
            username = txtUsuario.Text;
            Session["user"] = txtUsuario.Text;
            Session["userLogin"] = lblUser.Text;
            Session["password"] = txtPassword.Text;

            string conect = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection cn = new SqlConnection(conect);
            SqlCommand cmd = new SqlCommand("GetFullName", cn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Connection.Open();
            cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            sqlDataReader.Read();
            string area = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Area"));
            string fullName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("FullName"));
            cn.Close();
            Session["fullName"] = fullName;
            Session["area"] = area;
        }


        protected void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtUsuario.Text == "")
            {
                labelwrong.Text = "Ingresa tus datos";
                labelwrong.ForeColor = Color.Red;
                txtUsuario.Focus();
            }
            else
            {
                string conect = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(conect);
                SqlCommand cmd = new SqlCommand("ValidateUser", sqlCon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Connection.Open();
                cmd.Parameters.Add("@User", SqlDbType.VarChar, 50).Value = txtUsuario.Text;
                cmd.Parameters.Add("@Pass", SqlDbType.VarChar, 50).Value = txtPassword.Text;
                cmd.CommandTimeout = 9000;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                int result = dr.GetInt32(dr.GetOrdinal("Users"));
                if (result > 0)
                {
                    SqlConnection sqlConAdmin = new SqlConnection(conect);
                    SqlCommand cmdAdmin = new SqlCommand("ValidateUserAdmin", sqlConAdmin)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmdAdmin.Connection.Open();
                    cmdAdmin.Parameters.Add("@User", SqlDbType.VarChar, 50).Value = txtUsuario.Text;
                    cmdAdmin.Parameters.Add("@Pass", SqlDbType.VarChar, 50).Value = txtPassword.Text;
                    cmdAdmin.CommandTimeout = 9000;
                    SqlDataReader drAdmin = cmdAdmin.ExecuteReader();
                    drAdmin.Read();
                    int resultAdmin = drAdmin.GetInt32(drAdmin.GetOrdinal("Users"));
                    sqlConAdmin.Close();
                    saveDataUser();
                    Response.Redirect("Menu.aspx");

                }
                else
                {
                    labelwrong.Text = "Usuario o contraseña incorrecto";
                    labelwrong.ForeColor = System.Drawing.Color.PaleVioletRed;
                    txtPassword.Focus();
                }
                sqlCon.Close();
            }
        }
    }
}