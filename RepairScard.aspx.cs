using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinishGoodSMT
{
    public partial class RepairScard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //userlbl.Visible = true;
            userlabel.Text = Session["user"].ToString();
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string str = Session["workOrder"].ToString();
            txtWorkOrder.Text = str;
            dataModel.Text = Session["modelWO"].ToString();

            labelModel.Text = dataModel.Text.ToString();
            dataQtyWO.Text = Session["qty"].ToString() + " PCS";
            string str2 = Session["modelWO"].ToString();
            dataBindInfoWO();
            SqlConnection connection5 = new SqlConnection(connectionString);
            SqlCommand sqlCommand9 = new SqlCommand("GetPiecesPerPanel", connection5);
            sqlCommand9.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand10 = sqlCommand9;
            connection5.Open();
            sqlCommand10.Parameters.Add("@Model", SqlDbType.VarChar, 50).Value = str2;
            SqlDataReader sqlDataReader5 = sqlCommand10.ExecuteReader();
            sqlDataReader5.Read();
            int int32_5 = sqlDataReader5.GetInt32(sqlDataReader5.GetOrdinal("PiecesPerPanel"));
            connection5.Close();
            dataPieces.Text = int32_5.ToString();
            //txtQty.Attributes.Add("Placeholder", labelModel.Text.ToString() + " "+int32_5.ToString() + " por panel");
            txtQty.Attributes.Add("Placeholder", "Cantidad máxima " + int32_5.ToString() + " por panel");

            validator.MaximumValue = int32_5.ToString();
            txtQty.Focus();
        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            //string str2 = Session["modelWO"].ToString();
            //string str3 = Session["workOrder"].ToString();
            try
            //if (str2.ToString() == txtQRMain.Text.ToString())
            {
                int pieces = Convert.ToInt32(dataPieces.Text);
                if (Convert.ToInt32(txtQty.Text) <= pieces)
                {

                    SqlConnection connection2 = new SqlConnection(connectionString);
                    SqlCommand sqlCommand3 = new SqlCommand("AddScardRepair", connection2);
                    sqlCommand3.CommandType = CommandType.StoredProcedure;
                    SqlCommand sqlCommand4 = sqlCommand3;
                    connection2.Open();
                    sqlCommand4.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = txtWorkOrder.Text;
                    sqlCommand4.Parameters.Add("@Model", SqlDbType.VarChar, 50).Value = dataModel.Text;
                    sqlCommand4.Parameters.Add("@Pieces", SqlDbType.Int, 32).Value = Convert.ToInt32(txtQty.Text.ToString());
                    sqlCommand4.Parameters.Add("@ScanDate", SqlDbType.DateTime, 50).Value = DateTime.Now;
                    sqlCommand4.Parameters.Add("@UserScan", SqlDbType.VarChar, 30).Value = userlabel.Text.ToLower();
                    sqlCommand4.CommandTimeout = 9000;
                    SqlDataReader sqlDataReader10 = sqlCommand4.ExecuteReader();
                    sqlDataReader10.Read();
                    int rowsInserted = sqlDataReader10.GetInt32(sqlDataReader10.GetOrdinal("RowAffected"));
                    //
                    if (rowsInserted == 1)
                    {
                        //TODO: modificar alertas
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", " fs-3 bi bi-check-tras3-fill");
                        alert.Attributes.Add("class", " alert alert-warning  alert-dismissible  w-100 text-center fixed-bottom ");
                        alertText.Text = txtQty.Text.ToString() + " piezas registradas - PANEL INGRESADO  A SCRAP";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",8000)</script>");
                        dataQRSN.Text = "Última cantidad ingresada: " + txtQty.Text + " / " + dataPieces.Text;
                        txtQty.Text = "";
                        txtQty.Enabled = true;
                        txtQty.Focus();
                    }
                    connection2.Close();
                }
                else
                {
                    errorQty.Visible = true;
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + errorQty.ClientID + "').style.display='none'\",4000)</script>");
                }
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                AlertIcon.Attributes.Add("class", " fs-3 bi bi-database-fill-x");
                alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center fixed-bottom ");
                alertText.Text = "ERROR: PANEL NO INGRESADO " + ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",8000)</script>");
                txtQty.Enabled = true;
                txtQty.Text = "";
                txtQty.Focus();
                txtQty.Text = "";
            }

            dataBindInfoWO();
        }

        private void dataBindInfoWO()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string str = txtWorkOrder.Text;
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand sqlCommand1 = new SqlCommand("sp_GetInfoWoCountScard", connection1);
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand2 = sqlCommand1;
            connection1.Open();
            sqlCommand2.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str;
            sqlCommand2.CommandTimeout = 9000;
            SqlDataReader sqlDataReader1 = sqlCommand2.ExecuteReader();
            sqlDataReader1.Read();
            int FinishGood = sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("FinishGood"));
            int FinishGoodDay = sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("FinishGoodDay"));
            int Scrap = sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("Scrap"));
            int Repair = sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("Repair"));
            connection1.Close();
            dataAcumWO.Text = FinishGood.ToString();
            dataQtyRepair.Text = Repair.ToString();
            dataQtyScrap.Text = Scrap.ToString();
            dataAcumDia.Text = FinishGoodDay.ToString();
        }
    }
}