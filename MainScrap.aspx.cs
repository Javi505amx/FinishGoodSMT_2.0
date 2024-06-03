using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FinishGoodSMT
{
    public partial class MainScrap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userlabel.Text = Session["user"].ToString();
            txtQRMain.Focus();
        }

        protected void txtQRMain_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string workOrder, initialSN, finalSN, ywWO;
                int qty;
                string dataScan = txtQRMain.Text;
                string yearWeek = dataScan.Substring(0, 4);
                string area = dataScan.Substring(4, 3);
                string[] split = dataScan.Split(new char[] { '-' });
                string serial = split[0].ToUpper();
                string model = split[1].ToUpper();
                string consec = serial.Substring(8);
                if (split.Length > 2)
                {
                    model = model + "-" + split[2].ToUpper();
                }

                string conect = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(conect);
                SqlCommand sqlCommand = new SqlCommand("GetDetailsWorkOrderFGScrap", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnection.Open();
                sqlCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 50).Value = dataScan;
                sqlCommand.Parameters.Add("@Main", SqlDbType.VarChar, 50).Value = model;
                sqlCommand.Parameters.Add("@YearWeek", SqlDbType.VarChar, 4).Value = yearWeek;
                sqlCommand.CommandTimeout = 9000;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                int int32_2 = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("rowAffected"));
                switch (int32_2)
                {
                    case 0:
                        workOrder = sqlDataReader.GetString(sqlDataReader.GetOrdinal("WorkOrder"));
                        initialSN = sqlDataReader.GetString(sqlDataReader.GetOrdinal("InitialSN"));
                        finalSN = sqlDataReader.GetString(sqlDataReader.GetOrdinal("FinalSN"));
                        ywWO = sqlDataReader.GetString(sqlDataReader.GetOrdinal("YearWeek"));
                        qty = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Quantity"));
                        divInfo.Visible = true;
                        QR.Visible = false;
                        txtQRMain.Text = string.Empty;
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", "bi bi-check-fill");
                        alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center fixed-bottom ");
                        alertText.Text = "Unidad encontrada lista para registra como scrap: " + dataQRSN.Text;
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                        txtWorkOrder.Text = workOrder;
                        dataQtyWO.Text = qty.ToString() + " PCS";
                        dataQRSN.Text = dataScan;
                        dataModel.Text = model;
                        dataBind();
                        //bind();
                        btnReset2.Visible = true;
                        divScrap.Visible = true;
                        //CancelBtn.Visible = true;
                        ddlScrap.Focus();
                        break;
                    case 1:
                        workOrder = sqlDataReader.GetString(sqlDataReader.GetOrdinal("WorkOrder"));
                        initialSN = sqlDataReader.GetString(sqlDataReader.GetOrdinal("InitialSN"));
                        finalSN = sqlDataReader.GetString(sqlDataReader.GetOrdinal("FinalSN"));
                        ywWO = sqlDataReader.GetString(sqlDataReader.GetOrdinal("YearWeek"));
                        qty = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Quantity"));
                        divInfo.Visible = true;
                        QR.Visible = false;
                        txtQRMain.Text = string.Empty;
                        //myTable.Visible = true;
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", "  bi bi-exclamation-triangle-fill");
                        alert.Attributes.Add("class", " alert alert-warning  alert-dismissible  w-100 text-center  ");
                        alertText.Text = "Unidad ya se encuentra registrada como FINISH GOOD, Verifíque antes de registrar como SCRAP";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",2500)</script>");
                        txtQRMain.Text = string.Empty;
                        txtQRMain.Focus();
                        txtWorkOrder.Text = workOrder;
                        dataQtyWO.Text = qty.ToString() + " PCS";
                        dataQRSN.Text = dataScan;
                        dataModel.Text = model;
                        dataBind();
                        //bind();
                        btnReset2.Visible = true;
                        divScrap.Visible = true;
                        divScrap.Visible = true;
                        //CancelBtn.Visible = true;
                        ddlScrap.Focus();
                        break;
                    case 2:
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", "bi bi-trash3-fill");
                        alert.Attributes.Add("class", "alert alert-danger  alert-dismissible  w-100 text-center");
                        alertText.Text = "Unidad ya se encuentra registrada como SCRAP";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",2500)</script>");
                        txtQRMain.Text = string.Empty;
                        txtQRMain.Focus();
                        break;
                    case 3:
                        workOrder = sqlDataReader.GetString(sqlDataReader.GetOrdinal("WorkOrder"));
                        initialSN = sqlDataReader.GetString(sqlDataReader.GetOrdinal("InitialSN"));
                        finalSN = sqlDataReader.GetString(sqlDataReader.GetOrdinal("FinalSN"));
                        ywWO = sqlDataReader.GetString(sqlDataReader.GetOrdinal("YearWeek"));
                        qty = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Quantity"));
                        int RepairNumber = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("RepairNumber"));
                        divInfo.Visible = true;
                        QR.Visible = false;
                        txtQRMain.Text = string.Empty;
                        txtWorkOrder.Text = workOrder;
                        dataQtyWO.Text = qty.ToString() + " PCS";
                        dataQRSN.Text = dataScan;
                        dataModel.Text = model;
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", "bi bi-info-circle-fill");
                        alert.Attributes.Add("class", " alert alert-primary  alert-dismissible  w-100 text-center  ");
                        alertText.Text = "Unidad con reparaciones abiertas, está a punto de registrarla como SCRAP";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",2500)</script>");
                        DataBind();
                        btnReset2.Visible = true;
                        divScrap.Visible = true;
                        //CancelBtn.Visible = true;
                        ddlScrap.Focus();
                        break;
                    case 9:
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", "  bi bi-trash3-fill");
                        alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center  ");
                        alertText.Text = "Un error ha ocurrido contacta a IT";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",2500)</script>");
                        txtQRMain.Text = string.Empty;
                        txtQRMain.Focus();
                        break;
                    default:
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", "bi bi-exclamation-octagon-fill");
                        alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center fixed-bottom ");
                        alertText.Text = "QR no ha sido encontrado, falta información....inténtelo nuevamente, si el problema persiste contacte a IT";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                        divInfo.Visible = false;
                        divScrap.Visible = false;
                        QR.Visible = true;
                        txtQRMain.Text = string.Empty;
                        txtQRMain.Focus();
                        break;
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                AlertIcon.Attributes.Add("class", "bi bi-exclamation-octagon-fill");
                alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center fixed-bottom ");
                alertText.Text = "Contacte a IT      ERROR:  " + ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                divInfo.Visible = false;
                divScrap.Visible = false;
                QR.Visible = true;
                txtQRMain.Text = string.Empty;
                txtQRMain.Text = string.Empty;
                txtQRMain.Focus();
            }
        }



        protected void btnReset_Click(object sender, EventArgs e)
        {

            QR.Visible = true;
            dataQRSN.Text = string.Empty;
            dataQRSN.Visible = false;
            divScrap.Visible = false;
            divInfo.Visible = false;
            txtQRMain.Text = string.Empty;
            txtQRMain.Focus();
            alert.Visible = true;
            btnReset2.Visible = false;
            //CancelBtn.Visible = false;
            AlertIcon.Attributes.Add("class", "bi bi-repeat");
            alert.Attributes.Add("class", " alert alert-warning  alert-dismissible  w-100 text-center fixed-bottom ");
            alertText.Text = "Operación cancelada: Escanee otra unidad QR";
            ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
        }


        private void dataBind()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string str = txtWorkOrder.Text;
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand sqlCommand1 = new SqlCommand("GetWoInfoCountSCRAP", connection1);
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
            divInfo.Visible = true;
        }

        protected void ScrapBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection connection2 = new SqlConnection(connectionString);
                SqlCommand sqlCommand3 = new SqlCommand("AddScrapFGComments", connection2);
                sqlCommand3.CommandType = CommandType.StoredProcedure;
                connection2.Open();
                sqlCommand3.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = txtWorkOrder.Text;
                sqlCommand3.Parameters.Add("@Model", SqlDbType.VarChar, 30).Value = dataModel.Text.ToString();
                sqlCommand3.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 100).Value = dataQRSN.Text.ToString();
                sqlCommand3.Parameters.Add("@UserScan", SqlDbType.VarChar, 30).Value = userlabel.Text.ToLower();
                sqlCommand3.Parameters.Add("@ScanDate", SqlDbType.DateTime, 50).Value = DateTime.Now;
                sqlCommand3.Parameters.Add("@Comments", SqlDbType.VarChar, 150).Value = comments.Text.ToString();
                sqlCommand3.Parameters.Add("@ddlScrap", SqlDbType.VarChar, 35).Value = ddlScrap.SelectedValue.ToString();
                sqlCommand3.CommandTimeout = 9000;
                SqlDataReader sqlDataReader2 = sqlCommand3.ExecuteReader();
                sqlDataReader2.Read();
                int int32_2 = sqlDataReader2.GetInt32(sqlDataReader2.GetOrdinal("rowAffected"));
                connection2.Close();
                switch (int32_2)
                {
                    case 0:
                        dataBind();
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", " fs-3 bi bi-exclamation-triangle-fill");
                        alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center  ");
                        alertText.Text = "QR DUPLICADO EN SCRAP";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",8000)</script>");

                        break;
                    case 1:
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", " fs-3 bi bi-check-circle-fill");
                        alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center fixed-bottom ");
                        alertText.Text = "REGISTRO GUARDADO EN SCRAP";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",5000)</script>");
                        dataBind();
                        txtQRMain.Text = "";
                        txtQRMain.Focus();
                        dataQRSN.Text = txtQRMain.Text;
                        break;
                    case 2:
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", " fs-3 bi bi-exclamation-octagon");
                        alert.Attributes.Add("class", " alert alert-warning  alert-dismissible  w-100 text-center fixed-bottom ");
                        alertText.Text = "REGISTRO GUARDADO EN SCRAP Y ELIMINADO DE FINISH GOOD";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",5000)</script>");
                        dataBind();
                        txtQRMain.Text = "";
                        txtQRMain.Focus();
                        dataQRSN.Text = txtQRMain.Text;
                        break;
                    case 3:
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", " fs-3 bi bi-exclamation-octagon");
                        alert.Attributes.Add("class", " alert alert-warning  alert-dismissible  w-100 text-center fixed-bottom ");
                        alertText.Text = "REGISTRO GUARDADO EN SCRAP Y ELIMINADO DE REPA";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",5000)</script>");
                        dataBind();
                        txtQRMain.Text = "";
                        txtQRMain.Focus();
                        dataQRSN.Text = txtQRMain.Text;
                        break;
                    default:
                        dataBind();
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", " fs-3 bi bi-check-circle-fill");
                        alert.Attributes.Add("class", " alert alert-warning  alert-dismissible  w-100 text-center fixed-bottom ");
                        alertText.Text = "SOMETHING WENT WRONG";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",5000)</script>");
                        divInfo.Visible = false;
                        QR.Visible = true;
                        txtQRMain.Text = string.Empty;
                        txtQRMain.Focus();
                        break;
                }
                
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                AlertIcon.Attributes.Add("class", " fs-3 bi bi-database-fill-x");
                alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center fixed-bottom ");
                alertText.Text = "Algo salió mal: ERROR: " + ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",8000)</script>");
                divInfo.Visible = false;
                txtQRMain.Text = "";
                txtQRMain.Focus();
            }
            dataBind();
            divInfo.Visible = false;
            ddlScrap.SelectedValue = "Seleccione una opcion";
            btnReset2.Visible = false;
            txtQRMain.Text = string.Empty;
            comments.Text = string.Empty;
            divScrap.Visible = false;
            txtQRMain.Visible = true;
            ScrapBtn.Visible = false;
            txtQRMain.Focus();
            QR.Visible = true;
        }

        protected void btnReset_Click1(object sender, EventArgs e)
        {

        }

        protected void ddlFailureMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlScrap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlScrap.SelectedValue == "Seleccione una opcion")
            {
                ScrapBtn.Visible = false;
            }
            else
            {
                ScrapBtn.Visible = true;
            }
        }

        protected void ddlScrap_TextChanged(object sender, EventArgs e)
        {

        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {

        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            ddlScrap.SelectedValue = "Seleccione una opcion";
            btnReset2.Visible = false;
            txtQRMain.Text = string.Empty;
            txtQRMain.Focus();
            comments.Text = string.Empty;
            divScrap.Visible = false;
            alert.Visible = true;
            AlertIcon.Attributes.Add("class", "bi bi-eraser");
            alert.Attributes.Add("class", " alert alert-warning  alert-dismissible  w-100 text-center fixed-bottom ");
            alertText.Text = "Registro de falla cancelado";
            ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
            ScrapBtn.Visible = false;
            QR.Visible = true;
        }
    }
}