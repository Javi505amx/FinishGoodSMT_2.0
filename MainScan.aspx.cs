using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace FinishGoodSMT
{
    public partial class MainScan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userlabel.Text = Session["user"].ToString();
            txtWorkOrder.Text = Session["workOrder"].ToString();
            dataModel.Text = Session["modelWO"].ToString();
            dataQtyWO.Text = Session["qty"].ToString() + " PCS";
            dataBindInfoWO();
            txtQRMain.Focus();

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }

        protected void txtQRMain_TextChanged(object sender, EventArgs e)
        {
            try
            {
            string str1 = Session["workOrder"].ToString();
            string str2 = Session["userLogin"].ToString();
            string text = txtQRMain.Text;
            string str3 = text.Substring(0, 4);
            text.Substring(4, 3);
            string[] strArray = text.Split('-');
            string upper = strArray[0].ToUpper();
            string str4 = strArray[1].ToUpper();
            string s1 = upper.Substring(8);
            if (strArray.Length > 2)
                str4 = str4 + "-" + strArray[2].ToUpper();
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand sqlCommand1 = new SqlCommand("GetDetailsWorkOrder", connection1);
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand2 = sqlCommand1;
            connection1.Open();
            sqlCommand2.Parameters.Add("@Main", SqlDbType.VarChar, 50).Value = str4;
            sqlCommand2.Parameters.Add("@YearWeek", SqlDbType.VarChar, 50).Value = str3;
            sqlCommand2.CommandTimeout = 9000;
            SqlDataReader sqlDataReader1 = sqlCommand2.ExecuteReader();
            sqlDataReader1.Read();
                string str5 = sqlDataReader1.GetString(sqlDataReader1.GetOrdinal("WorkOrder"));
                string s2 = sqlDataReader1.GetString(sqlDataReader1.GetOrdinal("InitialSN"));
                string s3 = sqlDataReader1.GetString(sqlDataReader1.GetOrdinal("FinalSN"));
                string str6 = sqlDataReader1.GetString(sqlDataReader1.GetOrdinal("YearWeek"));
                int int32_1 = sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("Quantity"));
                connection1.Close();
                txtWorkOrder.Text = str5;
                dataQtyWO.Text = int32_1.ToString()+ " PCS";
                dataQRSN.Text =  "Último QR scanneado: " + text;
                dataModel.Text = str4;
                if (str3 == str6 && int.Parse(s1) >= int.Parse(s2) && int.Parse(s1) <= int.Parse(s3) && str1 == str5)
                {
                    SqlConnection connection2 = new SqlConnection(connectionString);
                    SqlCommand sqlCommand3 = new SqlCommand("AddScanQRMainFGTEST", connection2);
                    sqlCommand3.CommandType = CommandType.StoredProcedure;
                    SqlCommand sqlCommand4 = sqlCommand3;
                    connection2.Open();
                    sqlCommand4.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                    sqlCommand4.Parameters.Add("@Model", SqlDbType.VarChar, 50).Value = str4;
                    sqlCommand4.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 50).Value = text.ToUpper();
                    sqlCommand4.Parameters.Add("@ScanDate", SqlDbType.DateTime, 50).Value = DateTime.Now;
                    sqlCommand4.Parameters.Add("@UserScan", SqlDbType.VarChar, 30).Value = userlabel.Text.ToLower();
                    sqlCommand4.CommandTimeout = 9000;
                    SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
                    sqlDataReader2.Read();
                    int int32_2 = sqlDataReader2.GetInt32(sqlDataReader2.GetOrdinal("rowAffected"));
                    connection2.Close();
                    switch (int32_2)
                    {
                        case 0:
                            
                            alert.Visible = true;
                            AlertIcon.Attributes.Add("class", " fs-3 bi bi-exclamation-triangle-fill");
                            alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center  ");
                            alertText.Text = "QR DUPLICADO: No fue posible registrar, ya se encuentra registrada como FINISH GOOD";
                            ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",1500)</script>");
                           
                            break;
                        case 1:
                           
                            alert.Visible = true;
                            AlertIcon.Attributes.Add("class", " fs-3 bi bi-check-circle-fill");
                            alert.Attributes.Add("class", " alert alert-success  alert-dismissible  w-100 text-center fixed-bottom ");
                            alertText.Text = "REGISTRO GUARDADO";
                            ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",1500)</script>");
                            break;
                        case 2:
                            
                            alert.Visible = true;
                            AlertIcon.Attributes.Add("class", " fs-3 bi bi-tools");
                            alert.Attributes.Add("class", " alert alert-warning  alert-dismissible  w-100 text-center fixed-bottom ");
                            alertText.Text = "Unidad con reparaciones pendientes, inténtelo de nuevo o verifique los modos de falla registrados";
                            ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",1500)</script>");
                            break;
                        case 3:
                            alert.Visible = true;
                            AlertIcon.Attributes.Add("class", " fs-3 bi bi-trash3-fill");
                            alert.Attributes.Add("class", " alert alert-danger  alert-dismissible w-100 text-center fixed-bottom ");
                            alertText.Text = "Unidad se encuentra dada de alta como SCRAP, no fue posible registrar";
                            ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",1500)</script>");
                            break;
                        default:

                            alert.Visible = true;
                            AlertIcon.Attributes.Add("class", " fs-3 bi bi-bug-fill");
                            alert.Attributes.Add("class", " alert alert-danger  alert-dismissible w-100 text-center fixed-bottom ");
                            alertText.Text = "Stored procedure_ex_ERROR: default operation has executed: SP_AddScanQRMainFGTEST";
                            ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",2500)</script>");
                            break;
                       
                    }
                    
                }
                else if (str3 == str6 && int.Parse(s1) >= int.Parse(s2) && int.Parse(s1) <= int.Parse(s3) && str1 != str5)
                {
                    alert.Visible = true;
                    AlertIcon.Attributes.Add("class", " fs-3 bi bi-database-fill-slash");
                    alert.Attributes.Add("class", " alert alert-warning  alert-dismissible  w-100 text-center fixed-bottom ");
                    alertText.Text = "QR no corresponde a la WO: " + txtWorkOrder.Text + ", verifíquelo o intente de nuevo, si el problema persiste  avísele a su superior o contacte al departamento de IT ";
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",2500)</script>");
                    txtQRMain.Text = "";
                    txtQRMain.Focus();
                }
                else if (int.Parse(s1) > int.Parse(s3))
                {
                    alert.Visible = true;
                    AlertIcon.Attributes.Add("class", "fs-3 bi bi-database-fill-slash");
                    alert.Attributes.Add("class", " alert alert-danger  alert-dismissible   text-center fixed-bottom");
                    alertText.Text = "ERROR: El QR no ha sido encontrado, verifíquelo o intente de nuevo, si el problema persiste  avísele a su superior o contacte al departamento de IT ";
                    ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",2500)</script>");
                    txtQRMain.Text = "";
                    txtQRMain.Focus();
                }
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                AlertIcon.Attributes.Add("class", "fs-3 bi bi-database-x");
                alert.Attributes.Add("class", " alert alert-danger  alert-dismissible w-100 text-center fixed-bottom ");
                alertText.Text = "Oooops... algo salió mal. Reporte este error a IT:  " + ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
                txtQRMain.Text = "";
                txtQRMain.Focus();
            }
            dataBindInfoWO();

            txtQRMain.Text = "";
            txtQRMain.Focus();
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

    }
}