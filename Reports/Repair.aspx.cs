using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;

namespace FinishGoodSMT.Reports
{
    public partial class Repair : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    BindGridView();
            //}
            ExportBtn.Visible = true;
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            filterText.BackColor = System.Drawing.Color.White;
            filterText.Enabled = false;
            SearchBtn.Visible = false;
            RefreshBtn.Visible = true;
            QueryBtn.Visible = true;
            CancelBtn.Visible = false;
            alerts.Visible = true;
            AlertIcon.Attributes.Add("class", "bi bi-exclamation-diamond");
            alerts.Attributes.Add("class", " alert alert-danger  alert-dismissible ");
            alertText.Text = "Query cancelled";
            ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alerts.ClientID + "').style.display='none'\",3000)</script>");
            filterText.Text = string.Empty;
        }

        protected void QueryBtn_Click(object sender, EventArgs e)
        {
            //clearFields();
            filterText.BackColor = System.Drawing.Color.LightYellow;
            filterText.Enabled = true;
            filterText.Focus();
            SearchBtn.Visible = true;
            RefreshBtn.Visible = false;
            QueryBtn.Visible = false;
            CancelBtn.Visible = true;
            alerts.Visible = true;
            AlertIcon.Attributes.Add("class", "bi bi-database-fill");
            alerts.Attributes.Add("class", " alert alert-info  alert-dismissible ");
            alertText.Text = "Query enabled: Search by work order or model";
            ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alerts.ClientID + "').style.display='none'\",3000)</script>");
            filterText.Text = string.Empty;

        }

        protected void filterText_TextChanged(object sender, EventArgs e)
        {

            DataFilter();

        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            DataFilter();

        }


       
        //private void BindGridView()
        //{

        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
        //    {
        //        //SqlCommand sqlCommand = new SqlCommand("ReportRepair", connection);
        //        SqlCommand sqlCommand = new SqlCommand("GetRepairsLog", connection);

        //        sqlCommand.CommandType = CommandType.StoredProcedure;
        //        sqlCommand.CommandTimeout = 10000;
        //        connection.Open();
        //        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        //        DataSet data = new DataSet();
        //        adapter.Fill(data);
        //        if (data.Tables.Count > 0)
        //        {
        //            myTable.DataSource = data.Tables[0];
        //            myTable.AllowPaging = true;
        //            myTable.DataBind();
        //            connection.Close();
        //            //AlertIcon.Attributes.Add("class", "bi bi-clipboard2-data");
        //            //alert.Attributes.Add("class", " alert alert-danger  alert-dismissible ");
        //            //alertText.Text = "Query Executed Succesfully ";
        //            //ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",2500)</script>");
        //        }
        //        else
        //        {
        //            alerts.Visible = true;
        //            AlertIcon.Attributes.Add("class", " bi bi-exclamation-octagon");
        //            alerts.Attributes.Add("class", " alert alert-danger  alert-dismissible ");
        //            alertText.Text = "Data Not Found";
        //            ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alerts.ClientID + "').style.display='none'\",5000)</script>");
        //        }

        //    }
        //}

        public void DataFilter()
        {
            using (SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                SqlCommand sqlCommand1 = new SqlCommand("GetRepairsFilter", connection1);
                sqlCommand1.CommandType = CommandType.StoredProcedure;
                connection1.Open();
                sqlCommand1.Parameters.Add("@data", SqlDbType.VarChar, 100).Value = filterText.Text;
                SqlDataAdapter adapter1 = new SqlDataAdapter(sqlCommand1);
                DataSet data1 = new DataSet();
                adapter1.Fill(data1);
                if (data1.Tables.Count > 0)
                {
                    myTable.DataSource = data1.Tables[0];
                    myTable.AllowPaging = true;
                    myTable.DataBind();
                    connection1.Close();
                    /*IF DATA IS AVAILABLE*/
                    RefreshBtn.Visible = false;
                    SearchBtn.Visible = true;
                    CancelBtn.Visible = true;

                    AlertIcon.Attributes.Add("class", "bi bi-clipboard2-data");
                    alerts.Attributes.Add("class", " alert alert-danger  alert-dismissible ");
                    alertText.Text = "Query executed succesfully ";
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alerts.ClientID + "').style.display='none'\",2500)</script>");
                }
                else
                {
                    alerts.Visible = true;
                    AlertIcon.Attributes.Add("class", " bi bi-exclamation-octagon");
                    alerts.Attributes.Add("class", " alert alert-danger  alert-dismissible ");
                    alertText.Text = "Data not found, try again";
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alerts.ClientID + "').style.display='none'\",5000)</script>");
                }
                    filterText.Text = string.Empty;

            }
        }

        public void Excel()
        {
            //1.bind with paging disabled
            myTable.AllowPaging = false;
            myTable.DataBind();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                myTable.AllowPaging = false;
                //this.BindGridView();

                myTable.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in myTable.HeaderRow.Cells)
                {
                    cell.BackColor = myTable.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in myTable.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = myTable.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = myTable.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                myTable.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

            myTable.AllowPaging = true;
            myTable.DataBind();


        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void ExportBtn_Click(object sender, EventArgs e)
        {
            Excel();
        }
    }
}