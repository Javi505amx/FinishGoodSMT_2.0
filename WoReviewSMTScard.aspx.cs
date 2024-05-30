using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace FinishGoodSMT
{
    public partial class WoReviewSMTScard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userlbl.Visible = true;
            userlabel.Text = Session["user"].ToString();
            BindGridView2();
        }

        protected void txtWO_TextChanged(object sender, EventArgs e)
        {
            if (txtWO.Text.ToString() == "")
            {
                BindGridView2();
            }
            else
            {

                BindGridView();
                String WO = txtWO.Text;
                Session["WO"] = WO;
            }
        }
        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Finish Good SMT  SCARD WO Review " + "_" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView1.GridLines = GridLines.Both;
            GridView1.HeaderStyle.Font.Bold = true;
            GridView1.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        private void BindGridView()
        {

            string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlConnectionData = new SqlConnection(connection);
            {
                SqlCommand sqlCommand = new SqlCommand("GetScanHistoricScardFGWO", sqlConnectionData)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnectionData.Open();
                sqlCommand.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = txtWO.Text;
                GridView1.DataSource = sqlCommand.ExecuteReader();
                if (GridView1.Rows.Count >= 1)
                {
                    GridView1.DataBind();
                }
                else
                {
                    lblTotalWO.Text = "WO No Encontrada";
                    lblTotalWO.ForeColor = System.Drawing.Color.Red;
                }
                sqlConnectionData.Close();
            }
        }
        private void BindGridView2()
        {

            string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlConnectionData = new SqlConnection(connection);
            {
                SqlCommand sqlCommand = new SqlCommand("GetScanHistoricScardFG", sqlConnectionData)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnectionData.Open();
                GridView1.DataSource = sqlCommand.ExecuteReader();
                GridView1.DataBind();

                sqlConnectionData.Close();
            }
        }

        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }
    }
}