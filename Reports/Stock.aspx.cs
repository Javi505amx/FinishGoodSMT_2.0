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
    public partial class Stock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }

        }

        private void BindGridView(string sortExpression = null, string sortDirection = "ASC")
        {
            // Cadena de conexión (ajusta según tu configuración)
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //using (SqlCommand cmd = new SqlCommand("sp_GetWorkOrderDetails", con))
                using (SqlCommand cmd = new SqlCommand("sp_GetWorkOrderDetails_CTEs", con)) 

                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    // Asegurarnos de que los parámetros se están pasando correctamente
                    cmd.Parameters.AddWithValue("@StartWO", string.IsNullOrEmpty(txtStartWO.Text) ? (object)DBNull.Value : txtStartWO.Text);
                    cmd.Parameters.AddWithValue("@EndWO", string.IsNullOrEmpty(txtEndWO.Text) ? (object)DBNull.Value : txtEndWO.Text);
                    //cmd.Parameters.AddWithValue("@Model", txtModel.Text); 

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    // Agregar una columna para el formato condicional
                    dt.Columns.Add("QuantityProducedClass", typeof(string));
                    dt.Columns.Add("QuantityRepairedClass", typeof(string));
                    dt.Columns.Add("QuantityScrapClass", typeof(string));
                    dt.Columns.Add("EfficiencyRateClass", typeof(string));
                    dt.Columns.Add("TotalCountClass", typeof(string));
                    dt.Columns.Add("DifferenceClass", typeof(string));
                    dt.Columns.Add("StatusClass", typeof(string));


                    foreach (DataRow row in dt.Rows)
                    {
                        // asignando estilos segun el valor
                        double efficiencyRate = Convert.ToDouble(row["EfficiencyRate"]);
                        row["QuantityProducedClass"] = Convert.ToDouble(row["QuantityProduced"]) >= Convert.ToDouble(row["QuantityOrdered"]) ? "text-success fw-bold" : "text-danger fw-bold ";
                        row["QuantityRepairedClass"] = Convert.ToDouble(row["QuantityRepaired"]) >= 1 ? "text-warning fw-bold" : "text-body-secondary fw-bold ";
                        row["QuantityScrapClass"] = Convert.ToDouble(row["QuantityScrap"]) >= 1 ? "text-danger fw-bold " : "text-body-secondary fw-bold";
                        row["EfficiencyRateClass"] = efficiencyRate >= 98.5 ? " bi bi-emoji-smile   text-success fw-bold bg-success-subtle" : " bg-danger-subtle bi bi-emoji-frown text-danger   fw-bold ";
                        row["TotalCountClass"] = Convert.ToDouble(row["TotalCount"]) >= Convert.ToDouble(row["QuantityOrdered"]) ? " fw-bold  text-success " : "text-danger fw-bold";
                        row["DifferenceClass"] = Convert.ToDouble(row["Difference"]) >= 0 ? "text-success fw-bold  " : "text-danger fw-bold ";

                        // asignando estilos a la columna status segun el valor 
                        string status = row["WorkOrderStatus"].ToString().Trim();

                        if (status == "Completed")
                        {
                            row["StatusClass"] = "bg-success-subtle text-success";
                        }
                        else if (status == "In Progress")
                        {
                            row["StatusClass"] = "bg-warning-subtle text-warning";
                        }
                        else if (status == "Pending")
                        {
                            row["StatusClass"] = " bg-primary-subtle text-primary ";
                        }
                        else if(status == "Not Started")
                        {
                            row["StatusClass"] = "bg-danger-subtle text-danger";

                        }
                        else
                        {
                            row["StatusClass"] = "bg-dark-subtle text-dark";
                        }




                    }

                    // Asignar el DataTable al GridView
                    if (!string.IsNullOrEmpty(sortExpression))
                    {
                        dt.DefaultView.Sort = sortExpression + " " + sortDirection;
                    }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    CalculateTotals(dt);
                }
            }
        }
        private void CalculateTotals(DataTable dt)
        {
            double totalQuantityOrdered = 0;
            double totalQuantityProduced = 0;
            double totalQuantityRepaired = 0;
            double totalQuantityScrap = 0;
            double totalTotalCount = 0;
            double totalDifference = 0;
            int totalWorkOrderCount = dt.AsEnumerable().Select(row => row.Field<string>("WorkOrder")).Distinct().Count();
            int totalModelCount = dt.AsEnumerable().Select(row => row.Field<string>("Model")).Distinct().Count();

            foreach (DataRow row in dt.Rows)
            {
                totalQuantityOrdered += Convert.ToDouble(row["QuantityOrdered"]);
                totalQuantityProduced += Convert.ToDouble(row["QuantityProduced"]);
                totalQuantityRepaired += Convert.ToDouble(row["QuantityRepaired"]);
                totalQuantityScrap += Convert.ToDouble(row["QuantityScrap"]);
                totalTotalCount += Convert.ToDouble(row["TotalCount"]);
                totalDifference += Convert.ToDouble(row["Difference"]);
            }

            // Asignar los totales a las etiquetas del footer
            Label lblTotalWorkOrderCount = (Label)GridView1.FooterRow.FindControl("lblTotalWorkOrderCount");
            Label lblTotalModelCount = (Label)GridView1.FooterRow.FindControl("lblTotalModelCount");
            Label lblTotalQuantityOrdered = (Label)GridView1.FooterRow.FindControl("lblTotalQuantityOrdered");
            Label lblTotalQuantityProduced = (Label)GridView1.FooterRow.FindControl("lblTotalQuantityProduced");
            Label lblTotalQuantityRepaired = (Label)GridView1.FooterRow.FindControl("lblTotalQuantityRepaired");
            Label lblTotalQuantityScrap = (Label)GridView1.FooterRow.FindControl("lblTotalQuantityScrap");
            Label lblTotalEfficiencyRate = (Label)GridView1.FooterRow.FindControl("lblTotalEfficiencyRate");
            Label lblTotalTotalCount = (Label)GridView1.FooterRow.FindControl("lblTotalTotalCount");
            Label lblTotalDifference = (Label)GridView1.FooterRow.FindControl("lblTotalDifference");
            Label lblTotalWorkOrderStatus = (Label)GridView1.FooterRow.FindControl("lblTotalWorkOrderStatus");


            lblTotalWorkOrderCount.Text = totalWorkOrderCount.ToString();
            lblTotalModelCount.Text = totalModelCount.ToString();
            lblTotalQuantityOrdered.Text = string.Format("{0:N0}", totalQuantityOrdered);
            lblTotalQuantityProduced.Text = string.Format("{0:N0}", totalQuantityProduced);
            lblTotalQuantityRepaired.Text = string.Format("{0:N0}", totalQuantityRepaired);
            lblTotalQuantityScrap.Text = string.Format("{0:N0}", totalQuantityScrap);
            lblTotalTotalCount.Text = string.Format("{0:N0}", totalTotalCount);
            lblTotalDifference.Text = string.Format("{0:N0}", totalDifference);
            lblTotalEfficiencyRate.Text = "N/A"; // Puedes calcular un promedio o un valor significativo si es necesario
            lblTotalWorkOrderStatus.Text = "N/A"; // Puedes calcular un promedio o un valor significativo si es necesario

        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.CssClass = "gridview-header";
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            // Determine the sort direction
            string sortExpression = e.SortExpression;
            string sortDirection = ViewState["SortDirection"] as string ?? "ASC";

            // Toggle sort direction
            if (sortDirection == "ASC")
            {
                sortDirection = "DESC";
            }
            else
            {
                sortDirection = "ASC";
            }

            // Store sort direction in ViewState
            ViewState["SortDirection"] = sortDirection;

            // Re-bind GridView with new sort parameters
            BindGridView(sortExpression, sortDirection);
        }
        private string GetStatusClass(string status)
        {
            switch (status)
            {
                case "Completed":
                    return " bg-success-subtle text-success";
                case "In Progress":
                    return " bg-warning-subtle text-warning";
                case "Pending":
                    return "bg-primary-subtle text-primary";
                case "Not Started":
                    return "bg-danger-subtle text-danger";
                case "":
                    return "bg-info";
                default:
                    return "bg-dark-subtle text-body-secondary";
            }
        }
        public void Excel()
        {
            //1.bind with paging disabled
            GridView1.AllowPaging = false;
            GridView1.DataBind();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView1.AllowPaging = false;
                this.BindGridView();

                //GridView1.HeaderRow.BackColor = Color.White;
                GridView1.CssClass = "table table-striped";
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                GridView1.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

            GridView1.AllowPaging = true;
            GridView1.DataBind();


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
        protected void RefreshBtn_Click(object sender, EventArgs e)
        {
            BindGridView();
        }


    }

}
