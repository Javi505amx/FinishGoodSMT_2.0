using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.EnterpriseServices.CompensatingResourceManager;

namespace FinishGoodSMT
{
    public partial class ReportFG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }



        protected void txtWorkOrder_TextChanged(object sender, EventArgs e)
        {
            //divInfo.Visible = true;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }

        protected void myTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void myTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void myTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void myTable_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
        private void BindGridView()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("GetDashboardFG", connection);
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

        protected void CancelBtn_Click(object sender, EventArgs e)
        {

        }

        protected void QueryBtn_Click(object sender, EventArgs e)
        {

        }

        protected void filterText_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {

        }

        protected void RefreshBtn_Click(object sender, EventArgs e)
        {

        }

        protected void TextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}