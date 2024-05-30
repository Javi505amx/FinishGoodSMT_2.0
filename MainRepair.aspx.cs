using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace FinishGoodSMT
{
    public partial class MainRepair : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            userlabel.Text = Session["user"].ToString();

            dataBindInfoWO();

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
            SqlCommand sqlCommand = new SqlCommand("GetDetailsWorkOrderFG", sqlConnection)
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
                    divFailure.Visible = true;
                    QR.Visible = false;
                    txtQRMain.Text = string.Empty;
                    myTable.Visible = true;
                    alert.Visible = true;
                    AlertIcon.Attributes.Add("class", "bi bi-check-fill");
                    alert.Attributes.Add("class", " alert alert-info  alert-dismissible  w-100 text-center fixed-bottom ");
                    alertText.Text = "Unidad encontrada: " + dataQRSN.Text;
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");

                    txtWorkOrder.Text = workOrder;
                    dataPieces.Text = qty.ToString() + " PCS";
                    dataQRSN.Text = dataScan;
                    dataModel.Text = model;
                    BindGridView();
                    dataBindInfoWO();
                    btnReset.Visible = true;
                    break;
                case 1:
                    alert.Visible = true;
                    AlertIcon.Attributes.Add("class", "  bi bi-exclamation-triangle-fill");
                    alert.Attributes.Add("class", " alert alert-warning  alert-dismissible  w-100 text-center  ");
                    alertText.Text = "Unidad ya se encuentra registrada como FINISH GOOD";
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",2500)</script>");
                    txtQRMain.Text = string.Empty;
                    txtQRMain.Focus();
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
                    workOrder = sqlDataReader.GetString(sqlDataReader.GetOrdinal("WorkOrder"));
                    initialSN = sqlDataReader.GetString(sqlDataReader.GetOrdinal("InitialSN"));
                    finalSN = sqlDataReader.GetString(sqlDataReader.GetOrdinal("FinalSN"));
                    ywWO = sqlDataReader.GetString(sqlDataReader.GetOrdinal("YearWeek"));
                    qty = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Quantity"));
                    int RepairNumber = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("RepairNumber"));

                    divInfo.Visible = true;
                    divFailure.Visible = true;
                    QR.Visible = false;
                    txtQRMain.Text = string.Empty;
                    myTable.Visible = true;
                    txtWorkOrder.Text = workOrder;
                    dataPieces.Text = qty.ToString() + " PCS";
                    dataQRSN.Text = dataScan;
                    dataModel.Text = model;
                    alert.Visible = true;
                    AlertIcon.Attributes.Add("class", "bi bi-info-circle-fill");
                    alert.Attributes.Add("class", " alert alert-primary  alert-dismissible  w-100 text-center  ");
                    alertText.Text = "Unidad ya cuenta con reparaciones abiertas";
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",2500)</script>");
                    BindGridView();
                    dataBindInfoWO();
                    btnReset.Visible = true;
                    break;
                case 9:
                    alert.Visible = true;
                    AlertIcon.Attributes.Add("class", "  bi bi-trash3-fill");
                    alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center  ");
                    alertText.Text = "SCRAP";
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
                    divFailure.Visible = false;
                    QR.Visible = true;
                    txtQRMain.Text = string.Empty;
                    myTable.Visible = false;
                    txtQRMain.Focus();
                    break;
            }
            sqlConnection.Close();                                         
        }
            catch(Exception ex)
            {
                alert.Visible = true;
                AlertIcon.Attributes.Add("class", "bi bi-exclamation-octagon-fill");
                alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center fixed-bottom ");
                alertText.Text = "Contacte a IT      ERROR:  " + ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                divInfo.Visible = false;
                divFailure.Visible = false;
                QR.Visible = true;
                txtQRMain.Text = string.Empty;
                myTable.Visible = false;
                txtQRMain.Text = string.Empty;
                txtQRMain.Focus();
            }

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
                    //AlertIcon.Attributes.Add("class", "bi bi-clipboard2-data");
                    //alert.Attributes.Add("class", " alert alert-danger  alert-dismissible ");
                    //alertText.Text = "Query Executed Succesfully ";
                    //ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",2500)</script>");
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
            SaveBtn.Visible = false;
            ClearBtn.Visible = false;
            NewBtn.Visible = false;
            UpdateBtn.Visible = false;
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

        protected void ExportBtn_Click(object sender, EventArgs e)
        {

        }

        protected void myTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ComDelete")
            {
                try
                {
                    int index2 = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row2 = myTable.Rows[index2];
                    string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand sqlCommand4 = new SqlCommand("DeleteFailureMode", connection);
                    sqlCommand4.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    //sqlCommand4.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = row2.Cells[2].Text.ToString();
                    sqlCommand4.Parameters.Add("@ID", SqlDbType.Int).Value = row2.Cells[1].Text.ToString();

                    SqlDataReader reader = sqlCommand4.ExecuteReader();
                    reader.Read();
                    int row = reader.GetInt32(reader.GetOrdinal("RowDeleted"));
                    //sqlCommand4.ExecuteReader().Read();
                    connection.Close();
                    if (row == 1)
                    {
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", "bi bi-database-exclamation");
                        alert.Attributes.Add("class", " alert alert-warning  alert-dismissible w-100 text-center fixed-bottom ");
                        alertText.Text = "Falla eliminada";
                        ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                    }
                    //if (row > 1)
                    //{
                    //    alert.Visible = true;
                    //    AlertIcon.Attributes.Add("class", "bi bi-database-exclamation");
                    //    alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center fixed-bottom");
                    //    alertText.Text = "ERROR: 1 or more failures modes has been deleted, please, provide this info to it team. ";
                    //    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                    //}
                    else
                    {
                        alert.Visible = true;
                        AlertIcon.Attributes.Add("class", "bi bi-database-fill-x");
                        alert.Attributes.Add("class", " alert alert-danger  alert-dismissible w-100 text-center fixed-bottom ");
                        alertText.Text = "No fue posible eliminar la falla, Algo ha ocurrido, por favor contacte a IT.";
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
                SaveBtn.Visible = false;
                ClearBtn.Visible = false;
                UpdateBtn.Visible = false;
                dataBindInfoWO();
                BindGridView();
            }
            else if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = myTable.Rows[index];
                alert.Visible = true;
                AlertIcon.Attributes.Add("class", "bi bi-pencil-square");
                alert.Attributes.Add("class", " alert alert-info  alert-dismissible w-100 text-center fixed-bottom ");
                //alertText.Text = "Modo de falla listo para editar: " + row.Cells[2].Text + "   -    " +dataQRSN.Text;
                alertText.Text = "Modo de falla listo para editar: " + row.Cells[4].Text + "-" + dataQRSN.Text;

                ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",3000)</script>");
                inputID.Text = row.Cells[1].Text;
                ddlFailureMode.SelectedValue = row.Cells[2].Text;
                inputLocation.Text = row.Cells[3].Text;
                ddlSide.SelectedValue = row.Cells[4].Text;
                NewBtn.Visible = false;
                UpdateBtn.Visible = false;
                SaveBtn.Visible = true;
                ClearBtn.Visible = true;
            }
        }

        protected void myTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void myTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {

        }

        protected void myTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Editar";
                e.Row.Cells[1].Text = "ID";
                //e.Row.Cells[2].Text = "SerialNumber";
                e.Row.Cells[2].Text = "Modo de falla";
                e.Row.Cells[3].Text = "Localidad(es)";
                e.Row.Cells[4].Text = "Lado";
                e.Row.Cells[5].Text = "Eliminar";
                
            }
        }

        protected void ddlSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSide.SelectedValue == "Seleccione Lado")
            {
                NewBtn.Visible = false;
            }
            else if (ddlSide.SelectedValue == "BOT       ")
            {
                NewBtn.Visible = true;
            }
            else if (ddlSide.SelectedValue == "TOP       ")
            {
                NewBtn.Visible = true;
            }
        }

        protected void ddlSide_TextChanged(object sender, EventArgs e)
        {
            //NewBtn.Visible = true;
            //if (ddlSide.SelectedValue == "Seleccione Lado")
            //{
            //    NewBtn.Visible = false;
            //}
            //else if (ddlSide.SelectedValue == "BOT")
            //{
            //    NewBtn.Visible = true;
            //}
            //else if (ddlSide.SelectedValue == "TOP")
            //{
            //    NewBtn.Visible = true;
            //}
        }

        protected void NewBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //CREATE PROCEDURE[dbo].[AddFailureMode]
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection connection2 = new SqlConnection(connectionString);
                SqlCommand sqlCommand3 = new SqlCommand("AddFailureMode", connection2);
                sqlCommand3.CommandType = CommandType.StoredProcedure;
                SqlCommand sqlCommand4 = sqlCommand3;
                connection2.Open();
                sqlCommand4.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = txtWorkOrder.Text;
                sqlCommand4.Parameters.Add("@Model", SqlDbType.VarChar, 50).Value = dataModel.Text;
                sqlCommand4.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 100).Value = dataQRSN.Text.ToString();
                sqlCommand4.Parameters.Add("@FailureMode", SqlDbType.VarChar, 80).Value = ddlFailureMode.SelectedValue.ToString();
                sqlCommand4.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = inputLocation.Text.ToString();
                sqlCommand4.Parameters.Add("@Side", SqlDbType.VarChar, 3).Value = ddlSide.SelectedValue;
                sqlCommand4.Parameters.Add("@dx_Date", SqlDbType.DateTime, 50).Value = DateTime.Now;
                sqlCommand4.Parameters.Add("@userDx", SqlDbType.VarChar, 30).Value = userlabel.Text.ToLower();
                sqlCommand4.CommandTimeout = 9000;
                SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
                sqlDataReader2.Read();
                int int32_2 = sqlDataReader2.GetInt32(sqlDataReader2.GetOrdinal("rowAffected"));
                connection2.Close();
                if (int32_2 == 1)
                {
                    alert.Visible = true;
                    AlertIcon.Attributes.Add("class", "bi  bi-tools");
                    alert.Attributes.Add("class", " alert alert-warning  alert-dismissible  w-100 text-center fixed-bottom ");
                    alertText.Text = "Modo de falla agregado correctamente ->" + ddlFailureMode.SelectedValue.ToString();
                    BindGridView();
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                }
                else
                {
                    alert.Visible = true;
                    AlertIcon.Attributes.Add("class", "bi bi-exclamation-octagon-fill");
                    alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center fixed-bottom ");
                    alertText.Text = "NO fue posible agregar el modo de falla, inténtelo de nuevo, si el problema persiste contacte a IT";
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                }
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                AlertIcon.Attributes.Add("class", "bi bi-exclamation-octagon-fill");
                alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center fixed-bottom ");
                alertText.Text = "Algo ha salido mal, porfavor, contacte a IT. " + ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
            }
            BindGridView();
            ddlSide.SelectedValue = "Seleccione Lado";
            ddlFailureMode.SelectedValue = "Seleccione modo de falla";
            inputLocation.Text = string.Empty;
            btnReset.Visible = true;
            dataBindInfoWO();
        }

        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            BindGridView();
            ddlSide.SelectedValue = "Seleccione Lado";
            ddlFailureMode.SelectedValue = "Seleccione modo de falla";
            inputLocation.Text = string.Empty;
            btnReset.Visible = true;
            alert.Visible = true;
            AlertIcon.Attributes.Add("class", "bi bi-eraser");
            alert.Attributes.Add("class", " alert alert-warning  alert-dismissible  w-100 text-center fixed-bottom ");
            alertText.Text ="Registro de falla cancelado";
            ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            SaveBtn.Visible = false;
            NewBtn.Visible = false;
            QR.Visible = true;
            divFailure.Visible=false;
            myTable.Visible=false;
            dataQRSN.Text = string.Empty;
            dataQRSN.Visible = false;
            ddlSide.SelectedValue = "Seleccione Lado";
            ddlFailureMode.SelectedValue = "Seleccione modo de falla";
            inputLocation.Text = string.Empty;
            divInfo.Visible = false;
            txtQRMain.Text = string.Empty;
            txtQRMain.Focus();
            SaveBtn.Visible = false;
            ClearBtn.Visible = false;
            btnReset.Visible = false;
            alert.Visible = true;
            AlertIcon.Attributes.Add("class", "bi bi-repeat");
            alert.Attributes.Add("class", " alert alert-warning  alert-dismissible  w-100 text-center fixed-bottom ");
            alertText.Text = "Operación cancelada: Escanee otra unidad QR";
            ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
            dataBindInfoWO();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //CREATE PROCEDURE[dbo].[AddFailureMode]
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection connection2 = new SqlConnection(connectionString);
                SqlCommand sqlCommand3 = new SqlCommand("UpdateFailureMode", connection2);
                sqlCommand3.CommandType = CommandType.StoredProcedure;
                SqlCommand sqlCommand4 = sqlCommand3;
                connection2.Open();
                sqlCommand4.Parameters.Add("@ID", SqlDbType.Int).Value = inputID.Text.ToString();
                sqlCommand4.Parameters.Add("@FailureMode", SqlDbType.VarChar, 80).Value = ddlFailureMode.SelectedValue.ToString();
                sqlCommand4.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = inputLocation.Text.ToString();
                sqlCommand4.Parameters.Add("@Side", SqlDbType.VarChar, 3).Value = ddlSide.SelectedValue;
                sqlCommand4.Parameters.Add("@dx_Date", SqlDbType.DateTime, 50).Value = DateTime.Now;
                sqlCommand4.Parameters.Add("@userDx", SqlDbType.VarChar, 30).Value = userlabel.Text.ToLower();
                sqlCommand4.CommandTimeout = 9000;
                SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
                sqlDataReader2.Read();
                int int32_2 = sqlDataReader2.GetInt32(sqlDataReader2.GetOrdinal("rowUpdated"));
                connection2.Close();
                if (int32_2 == 1)
                {
                    alert.Visible = true;
                    AlertIcon.Attributes.Add("class", "bi  bi-tools");
                    alert.Attributes.Add("class", " alert alert-warning  alert-dismissible  w-100 text-center fixed-bottom ");
                    alertText.Text = "Modificado correctamente:" + inputID.Text+"  Modo de falla ->" + ddlFailureMode.SelectedValue.ToString();
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                }
                else
                {
                    alert.Visible = true;
                    AlertIcon.Attributes.Add("class", "bi bi-exclamation-octagon-fill");
                    alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center fixed-bottom ");
                    alertText.Text = "No fue posible agregar el modo de falla, inténtelo de nuevo, si el problema persiste contacte a IT";
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                }
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                AlertIcon.Attributes.Add("class", "bi bi-exclamation-octagon-fill");
                alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center fixed-bottom ");
                alertText.Text = "Algo ha salido mal, porfavor, contacte a IT. " + ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
            }
            BindGridView();
            ddlSide.SelectedValue = "Seleccione Lado";
            ddlFailureMode.SelectedValue = "Seleccione modo de falla";
            inputLocation.Text = string.Empty;
            btnReset.Visible = true;
            dataBindInfoWO();
        }
    }
}

