using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace FinishGoodSMT
{
    public partial class RepairValidation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userlabel.Text = Session["user"].ToString();

        }

        protected void myTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "ID";
                e.Row.Cells[1].Text = "Modo de falla";
                e.Row.Cells[2].Text = "Localidad(es)";
                e.Row.Cells[3].Text = "Lado";
                e.Row.Cells[4].Text = "Registró";
                e.Row.Cells[5].Text = "Fecha";
                e.Row.Cells[6].Text = "Validar";
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
                    SqlCommand sqlCommand4 = new SqlCommand("RepairUnit", connection);
                    sqlCommand4.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    sqlCommand4.Parameters.Add("@ID", SqlDbType.Int).Value = row2.Cells[0].Text.ToString();
                    sqlCommand4.Parameters.Add("@Username", SqlDbType.VarChar, 30).Value = userlabel.Text.ToString();
                    sqlCommand4.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
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

        protected void myTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void myTable_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                SqlCommand sqlCommand = new SqlCommand("GetDetailsWorkOrderFGRepair", sqlConnection)
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
                        divInfo.Visible = false;
                        QR.Visible = true;
                        myTable.Visible = false;
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", "bi bi-exclamation-triangle-fill");
                        alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center fixed-bottom ");
                        alertText.Text = "La unidad " + dataQRSN.Text + "  No cuenta con fallas pendientes por reparar, regrese al menú reparación para registrar una falla";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                        txtQRMain.Text = string.Empty;
                        txtQRMain.Focus();
                        break;
                    case 1:
                        workOrder = sqlDataReader.GetString(sqlDataReader.GetOrdinal("WorkOrder"));
                        initialSN = sqlDataReader.GetString(sqlDataReader.GetOrdinal("InitialSN"));
                        finalSN = sqlDataReader.GetString(sqlDataReader.GetOrdinal("FinalSN"));
                        ywWO = sqlDataReader.GetString(sqlDataReader.GetOrdinal("YearWeek"));
                        qty = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Quantity"));
                        divInfo.Visible = true;
                        QR.Visible = true;
                        myTable.Visible = true;
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", "bi bi-tools");
                        alert.Attributes.Add("class", " alert alert-info  alert-dismissible  w-100 text-center fixed-bottom ");
                        alertText.Text = "Unidad encontrada con fallas por reparar";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                        txtWorkOrder.Text = workOrder;
                        dataPieces.Text = qty.ToString() + " PCS";
                        dataQRSN.Text = dataScan;
                        dataModel.Text = model;
                        BindGridView();
                        dataBindInfoWO();
                        btnReset.Visible = true;
                        txtQRMain.Text = string.Empty;
                        RepairBtn.Visible = true;
                        break;
                    case 2:
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", "  bi bi-trash3-fill");
                        alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center  ");
                        alertText.Text = "Unidad ya se encuentra registrada como SCRAP";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",2500)</script>");
                        txtQRMain.Text = string.Empty;
                        txtQRMain.Focus();
                        break;
                    case 3:
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", "bi bi-info-circle-fill");
                        alert.Attributes.Add("class", " alert alert-primary  alert-dismissible  w-100 text-center  ");
                        alertText.Text = "Unidad ya se encuentra registrada como Finish Good";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",2500)</script>");
                        btnReset.Visible = true;
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
                        QR.Visible = true;
                        txtQRMain.Text = string.Empty;
                        myTable.Visible = false;
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
                QR.Visible = true;
                txtQRMain.Text = string.Empty;
                myTable.Visible = false;
                txtQRMain.Text = string.Empty;
                txtQRMain.Focus();
            }

        }
        private void dataBindInfoWO()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string str = txtWorkOrder.Text;
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand sqlCommand1 = new SqlCommand("GetWoInfoCount", connection1);
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
                SqlCommand sqlCommand = new SqlCommand("GetRepairs", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                sqlCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 60).Value = dataQRSN.Text.ToString();
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

        protected void btnReset_Click(object sender, EventArgs e)
        {
            QR.Visible = true;
            myTable.Visible = false;
            dataQRSN.Text = string.Empty;
            dataQRSN.Visible = false;
            divInfo.Visible = false;
            txtQRMain.Text = string.Empty;
            txtQRMain.Focus();
            btnReset.Visible = false;
            alert.Visible = true;
            AlertIcon.Attributes.Add("class", "bi bi-repeat");
            alert.Attributes.Add("class", " alert alert-warning  alert-dismissible  w-100 text-center fixed-bottom ");
            alertText.Text = "Operación cancelada: Escanee otra unidad QR";
            ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
            RepairBtn.Visible = false;

        }

        protected void RepairBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //int index2 = Convert.ToInt32(e.CommandArgument);
                //GridViewRow row2 = myTable.Rows[index2];
                string connectionString8 = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection connection8 = new SqlConnection(connectionString8);
                SqlCommand sqlCommand48 = new SqlCommand("RepairUnitAll", connection8);
                sqlCommand48.CommandType = CommandType.StoredProcedure;
                connection8.Open();
                sqlCommand48.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 50).Value = dataQRSN.Text.ToString();
                sqlCommand48.Parameters.Add("@Username", SqlDbType.VarChar, 30).Value = userlabel.Text.ToString();
                sqlCommand48.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
                SqlDataReader reader8 = sqlCommand48.ExecuteReader();
                reader8.Read();
                string row = reader8.GetString(reader8.GetOrdinal("RowUpdated"));
                connection8.Close();
                if (row == "FG")
                {
                    alert.Visible = true;
                    AlertIcon.Attributes.Add("class", "bi bi-check-circle-fill");
                    alert.Attributes.Add("class", " alert alert-success  alert-dismissible w-100 text-center fixed-bottom ");
                    alertText.Text = "Fallas reparadas y enviado a Finish Good";
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                }
                else if (row == "DP")
                {
                    alert.Visible = true;
                    AlertIcon.Attributes.Add("class", "bi bi-check-circle-fill");
                    alert.Attributes.Add("class", " alert alert-success  alert-dismissible w-100 text-center fixed-bottom ");
                    alertText.Text = "No fue posible, unidad duplicada en Finish Good";
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                }
                else
                {
                    alert.Visible = true;
                    AlertIcon.Attributes.Add("class", "bi bi-database-fill-x");
                    alert.Attributes.Add("class", " alert alert-danger  alert-dismissible w-100 text-center fixed-bottom ");
                    alertText.Text = "No fue posible reparar la fallas, Algo ha ocurrido, por favor contacte a IT.";
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


        protected void btnResetAll_Click(object sender, EventArgs e)
        {
            QR.Visible = true;
            myTable.Visible = false;
            dataQRSN.Text = string.Empty;
            dataQRSN.Visible = false;
            divInfo.Visible = false;
            txtQRMain.Text = string.Empty;
            txtQRMain.Focus();
            btnResetAll.Visible = false;
            alert.Visible = true;
            AlertIcon.Attributes.Add("class", "bi bi-repeat");
            alert.Attributes.Add("class", " alert alert-warning  alert-dismissible  w-100 text-center fixed-bottom ");
            alertText.Text = "Operación cancelada: Escanee otra unidad QR";
            ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
        }
    }
}