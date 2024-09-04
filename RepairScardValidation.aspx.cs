using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;

namespace FinishGoodSMT
{
    public partial class RepairScardValidation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //userlbl.Visible = true;
            userlabel.Text = Session["user"].ToString();
            txtWorkOrderQR.Focus();
        }

        protected void txtWorkOrder_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {   string wo = txtWorkOrderQR.Text.ToString();
                SqlCommand sqlCommand = new SqlCommand("sp_GetRepairsScard", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                sqlCommand.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 60).Value = wo;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataSet data = new DataSet();
                adapter.Fill(data);
                if (data.Tables.Count > 0)
                {
                    myTable.DataSource = data.Tables[0];
                    myTable.AllowPaging = true;
                    myTable.DataBind();
                    connection.Close();
                }
                else
                {
                    alert.Visible = true;
                    AlertIcon.Attributes.Add("class", " bi bi-exclamation-octagon");
                    alert.Attributes.Add("class", " alert alert-danger  alert-dismissible ");
                    alertText.Text = "Data Not Found";
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",5000)</script>");
                }
            }
        }

        protected void btnResetAll_Click(object sender, EventArgs e)
        {

        }

        protected void myTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "ID";
                e.Row.Cells[1].Text = "WorkOrder";
                e.Row.Cells[2].Text = "Modelo";
                e.Row.Cells[3].Text = "Pieces";
                e.Row.Cells[4].Text = "Status";
                e.Row.Cells[5].Text = "Registró";
                e.Row.Cells[6].Text = "Fecha";
                e.Row.Cells[7].Text = "Validar";
            }
        }

        protected void myTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Reparar")
            {
                try
                {
                    int index2 = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row2 = myTable.Rows[index2];
                    string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand sqlCommand4 = new SqlCommand("RepairPanel", connection);
                    sqlCommand4.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    sqlCommand4.Parameters.Add("@ID", SqlDbType.Int).Value = row2.Cells[0].Text.ToString();
                    SqlDataReader reader = sqlCommand4.ExecuteReader();
                    reader.Read();
                    int row = reader.GetInt32(reader.GetOrdinal("RowUpdated"));
                    connection.Close();
                    if (row == 1)
                    {
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", "bi bi-check-circle-fill");
                        alert.Attributes.Add("class", " alert alert-success  alert-dismissible w-100 text-center fixed-bottom ");
                        alertText.Text = "Falla reparada";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                    }
                    else
                    {
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", "bi bi-database-fill-x");
                        alert.Attributes.Add("class", " alert alert-danger  alert-dismissible w-100 text-center fixed-bottom ");
                        alertText.Text = "No fue posible reparar la falla, Algo ha ocurrido, por favor contacte a IT.";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                    }
                }
                catch (Exception ex)
                {
                    alert.Visible = true;
                    AlertIcon.Attributes.Add("class", " bi bi-info-circle-fill");
                    alert.Attributes.Add("class", " alert alert-danger  alert-dismissible w-100 text-center fixed-bottom ");
                    alertText.Text = "Something went wrong: " + ex.Message;
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                    myTable.DataBind();
                }
                dataBindInfoWO();
                BindGridView();
            }
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
            int FinishGoodDay = sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("FinishGoodDay"));
            int FinishGood = sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("FinishGood"));
            int Scrap = sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("Scrap"));
            int Repair = sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("Repair"));
            connection1.Close();
            dataAcumWO.Text = FinishGood.ToString();
            dataAcumDia.Text = FinishGoodDay.ToString();
            dataQtyRepair.Text = Repair.ToString();
            dataQtyScrap.Text = Scrap.ToString();
        }


        private void BindGridView()
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_GetRepairsScard", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                sqlCommand.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 60).Value = txtWorkOrderQR.Text.ToString();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataSet data = new DataSet();
                adapter.Fill(data);
                if (data.Tables.Count > 0)
                {
                    myTable.DataSource = data.Tables[0];
                    myTable.AllowPaging = true;
                    myTable.DataBind();
                    connection.Close();
                }
                else
                {
                    alert.Visible = true;
                    AlertIcon.Attributes.Add("class", " bi bi-exclamation-octagon");
                    alert.Attributes.Add("class", " alert alert-danger  alert-dismissible ");
                    alertText.Text = "Data Not Found";
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",5000)</script>");
                }
            }
        }

        protected void myTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void myTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}