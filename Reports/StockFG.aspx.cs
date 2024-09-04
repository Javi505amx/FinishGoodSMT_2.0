using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinishGoodSMT.Reports
{
    public partial class WO_Tracking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void myTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void myTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void myTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            filterText.BackColor = System.Drawing.Color.White;
            filterText.Enabled = false;
            SearchBtn.Visible = false;
            RefreshBtn.Visible = true;
            QueryBtn.Visible = true;
            CancelBtn.Visible = false;
            alert.Visible = true;
            AlertIcon.Attributes.Add("class", "bi bi-exclamation-diamond");
            alert.Attributes.Add("class", " alert alert-danger  alert-dismissible ");
            alertText.Text = "Query Aborted";
            ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",3000)</script>");
            filterText.Text = string.Empty;
            filterText.Enabled = false;

        }

        protected void QueryBtn_Click(object sender, EventArgs e)
        {
            filterText.BackColor = System.Drawing.Color.LightYellow;
            filterText.Enabled = true;
            filterText.Focus();
            SearchBtn.Visible = true;
            RefreshBtn.Visible = false;
            QueryBtn.Visible = false;
            CancelBtn.Visible = true;
            alert.Visible = true;
            AlertIcon.Attributes.Add("class", "bi bi-database-fill");
            alert.Attributes.Add("class", " alert alert-info  alert-dismissible ");
            alertText.Text = "Query Enabled";
            ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",3000)</script>");
        }

        protected void filterText_TextChanged(object sender, EventArgs e)
        {
            DataFilter();
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            DataFilter();
        }

        protected void RefreshBtn_Click(object sender, EventArgs e)
        {
            filterText.Enabled = false;
            SearchBtn.Visible = false;
            RefreshBtn.Visible = true;
            QueryBtn.Visible = true;

            BindGridView();
            alert.Visible = true;
            AlertIcon.Attributes.Add("class", "bi bi-list-check");
            alert.Attributes.Add("class", " alert alert-primary  alert-dismissible ");
            alertText.Text = "Updated Succesfully";
            ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",3000)</script>");

        }
        private void BindGridView()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("GetStockFG", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 10000;
                connection.Open();
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
        public void DataFilter()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("GetStockFGFilterLike", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                sqlCommand.Parameters.Add("@data", SqlDbType.VarChar, 30).Value = filterText.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataSet data = new DataSet();
                adapter.Fill(data);
                connection.Close();
                if (data.Tables.Count > 0)
                {
                    myTable.DataSource = data.Tables[0];
                    myTable.AllowPaging = true;
                    myTable.DataBind();
                    /*IF DATA IS AVAILABLE*/
                    RefreshBtn.Visible = true;
                    AlertIcon.Attributes.Add("class", "bi bi-clipboard2-data");
                    alert.Attributes.Add("class", " alert alert-danger  alert-dismissible ");
                    alertText.Text = "Query Executed Succesfully ";
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",2500)</script>");
                }
                else
                {
                    alert.Visible = true;
                    AlertIcon.Attributes.Add("class", " bi bi-exclamation-octagon");
                    alert.Attributes.Add("class", " alert alert-danger  alert-dismissible ");
                    alertText.Text = "Work Order Not Found";
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",5000)</script>");
                }
            }
        }
    }
}