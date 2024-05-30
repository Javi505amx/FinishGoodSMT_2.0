using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinishGoodSMT
{
    public partial class ScanWoRepair : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtWorkOrderRepair_TextChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand sqlCommand1 = new SqlCommand("GetModelQtyByWorkOrder", connection);
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand2 = sqlCommand1;
            connection.Open();
            sqlCommand2.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = (object)txtWorkOrderRepair.Text.ToUpper();
            SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
            sqlDataReader.Read();
            try
            {
                string str1 = sqlDataReader.GetString(sqlDataReader.GetOrdinal("WorkOrder"));
                string str2 = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Model"));
                int int32 = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Quantity"));
                connection.Close();
                Session["workOrder"] = str1;
                Session["modelWO"] = str2;
                Session["qty"] = int32.ToString();
                if (str2.Substring(0, 3) == "MX1")
                {
                    Response.Redirect("MainRepair.aspx");
                }
                else
                {
                    if (!(str2.Substring(0, 3) == "MX2"))
                        return;
                    Response.Redirect("ScardRepair.aspx");
                }
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                AlertIcon.Attributes.Add("class", "fs-3  bi bi-database-x");
                alert.Attributes.Add("class", " alert alert-danger  alert-dismissible text-center w-100 fixed-bottom ");
                alertText.Text = "Workorder no existe, verifíque el QR o inténtelo de nuevo...";
                ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",6000)</script>");
                txtWorkOrderRepair.Text = string.Empty;
                txtWorkOrderRepair.Focus();
            }
        }
    }
}