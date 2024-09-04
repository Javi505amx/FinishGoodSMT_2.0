using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinishGoodSMT
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //x Stored procedure to add MainScrap
            /*x
            string upper = txtQRMain.Text.ToUpper();
            string str1 = upper.Substring(0, 3);
            DateTime now = DateTime.Now;
            int num = 0;
            if (str1 == "MX2")
            {
                txtQtyScrap.Focus();
                Session["user"].ToString().ToLower();
                lblQtyScrap.Visible = true;
                txtQtyScrap.Visible = true;
            }
            else
            {
                lblSerialScan.Visible = true;
                string lower = Session["user"].ToString().ToLower();
                if (Session["area"].ToString() == "Calidad")
                    num = 1;
                else if (Session["area"].ToString() == "SMT" || lower == "ginad" || lower == "danielag")
                    num = 2;
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection connection1 = new SqlConnection(connectionString);
                SqlCommand sqlCommand1 = new SqlCommand("AddMainScrap", connection1);
                sqlCommand1.CommandType = CommandType.StoredProcedure;
                SqlCommand sqlCommand2 = sqlCommand1;
                connection1.Open();
                sqlCommand2.Parameters.Add("@Area", SqlDbType.Int).Value = num;
                sqlCommand2.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 100).Value = upper.ToUpper();
                sqlCommand2.Parameters.Add("@ScrapDate", SqlDbType.DateTime, 50).Value = now;
                sqlCommand2.Parameters.Add("@ScrapUser", SqlDbType.VarChar, 30).Value = lower.ToLower();
                SqlDataReader sqlDataReader1 = sqlCommand2.ExecuteReader();
                sqlDataReader1.Read();
                int int32_1 = sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("rowAffected"));
                connection1.Close();
                switch (int32_1)
                {
                    case -1:
                        string text1 = lblRWO.Text;
                        res.Text = "PIEZA YA REGISTRADA EN SCRAP";
                        lblResult.ForeColor = Color.Red;
                        lblRSN.Text = upper;
                        txtQRMain.Text = "";
                        SqlConnection connection2 = new SqlConnection(connectionString);
                        SqlCommand sqlCommand3 = new SqlCommand("GetAccumulatedWOScrap", connection2);
                        sqlCommand3.CommandType = CommandType.StoredProcedure;
                        SqlCommand sqlCommand4 = sqlCommand3;
                        connection2.Open();
                        sqlCommand4.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = text1;
                        SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
                        sqlDataReader2.Read();
                        int int32_2 = sqlDataReader2.GetInt32(sqlDataReader2.GetOrdinal("Accumulated"));
                        connection2.Close();
                        lblRAT.Text = int32_2.ToString();
                        SqlConnection connection3 = new SqlConnection(connectionString);
                        SqlCommand sqlCommand5 = new SqlCommand("GetAccumulatedDayScrap", connection3);
                        sqlCommand5.CommandType = CommandType.StoredProcedure;
                        SqlCommand sqlCommand6 = sqlCommand5;
                        connection3.Open();
                        sqlCommand6.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = text1;
                        SqlDataReader sqlDataReader3 = sqlCommand6.ExecuteReader();
                        sqlDataReader3.Read();
                        int int32_3 = sqlDataReader3.GetInt32(sqlDataReader3.GetOrdinal("Accumulated"));
                        connection3.Close();
                        lblRAD.Text = int32_3.ToString();
                        break;
                    case 0:
                        string text2 = lblRWO.Text;
                        res.Text = "PIEZA NO ENCONTRADA";
                        lblResult.ForeColor = Color.Red;
                        lblRSN.Text = upper;
                        txtQRMain.Text = "";
                        SqlConnection connection4 = new SqlConnection(connectionString);
                        SqlCommand sqlCommand7 = new SqlCommand("GetAccumulatedWOScrap", connection4);
                        sqlCommand7.CommandType = CommandType.StoredProcedure;
                        SqlCommand sqlCommand8 = sqlCommand7;
                        connection4.Open();
                        sqlCommand8.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = text2;
                        SqlDataReader sqlDataReader4 = sqlCommand8.ExecuteReader();
                        sqlDataReader4.Read();
                        int int32_4 = sqlDataReader4.GetInt32(sqlDataReader4.GetOrdinal("Accumulated"));
                        connection4.Close();
                        lblRAT.Text = int32_4.ToString();
                        SqlConnection connection5 = new SqlConnection(connectionString);
                        SqlCommand sqlCommand9 = new SqlCommand("GetAccumulatedDayScrap", connection5);
                        sqlCommand9.CommandType = CommandType.StoredProcedure;
                        SqlCommand sqlCommand10 = sqlCommand9;
                        connection5.Open();
                        sqlCommand10.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = text2;
                        SqlDataReader sqlDataReader5 = sqlCommand10.ExecuteReader();
                        sqlDataReader5.Read();
                        int int32_5 = sqlDataReader5.GetInt32(sqlDataReader5.GetOrdinal("Accumulated"));
                        connection5.Close();
                        lblRAD.Text = int32_5.ToString();
                        break;
                    case 1:
                        lblResult.Text = "REGISTRO GUARDADO";
                        lblResult.ForeColor = Color.Green;
                        lblRSN.Text = upper;
                        txtQRMain.Text = "";
                        SqlConnection connection6 = new SqlConnection(connectionString);
                        SqlCommand sqlCommand11 = new SqlCommand("GetDetailsScrap", connection6);
                        sqlCommand11.CommandType = CommandType.StoredProcedure;
                        SqlCommand sqlCommand12 = sqlCommand11;
                        connection6.Open();
                        sqlCommand12.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 100).Value = upper;
                        SqlDataReader sqlDataReader6 = sqlCommand12.ExecuteReader();
                        sqlDataReader6.Read();
                        string str2 = sqlDataReader6.GetString(sqlDataReader6.GetOrdinal("WorkOrder"));
                        string str3 = sqlDataReader6.GetString(sqlDataReader6.GetOrdinal("Model"));
                        int int32_6 = sqlDataReader6.GetInt32(sqlDataReader6.GetOrdinal("Quantity"));
                        connection6.Close();
                        lblRWO.Text = str2;
                        lblRQT.Text = int32_6.ToString();
                        lblRSN.Text = upper;
                        lblRM.Text = str3;
                        SqlConnection connection7 = new SqlConnection(connectionString);
                        SqlCommand sqlCommand13 = new SqlCommand("GetAccumulatedWOScrap", connection7);
                        sqlCommand13.CommandType = CommandType.StoredProcedure;
                        SqlCommand sqlCommand14 = sqlCommand13;
                        connection7.Open();
                        sqlCommand14.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str2;
                        SqlDataReader sqlDataReader7 = sqlCommand14.ExecuteReader();
                        sqlDataReader7.Read();
                        int int32_7 = sqlDataReader7.GetInt32(sqlDataReader7.GetOrdinal("Accumulated"));
                        connection7.Close();
                        lblRAT.Text = int32_7.ToString();
                        SqlConnection connection8 = new SqlConnection(connectionString);
                        SqlCommand sqlCommand15 = new SqlCommand("GetAccumulatedDayScrap", connection8);
                        sqlCommand15.CommandType = CommandType.StoredProcedure;
                        SqlCommand sqlCommand16 = sqlCommand15;
                        connection8.Open();
                        sqlCommand16.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str2;
                        SqlDataReader sqlDataReader8 = sqlCommand16.ExecuteReader();
                        sqlDataReader8.Read();
                        int int32_8 = sqlDataReader8.GetInt32(sqlDataReader8.GetOrdinal("Accumulated"));
                        connection8.Close();
                        lblRAD.Text = int32_8.ToString();
                        break;
                }
            }*/


            /*!
               string QRSerial = txtQRMain.Text.ToUpper();
            char delimiter = '-';
            string[] ActualModel = QRSerial.Split('-');
            string model = dataModel.Text.ToString();
            string MX = QRSerial.Substring(0, 3);
            DateTime Now = DateTime.Now;
            string user = Session["user"].ToString().ToLower();
            if (txtQRMain.Text.Contains(model)) 
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection connection1 = new SqlConnection(connectionString);
                SqlCommand sqlCommand1 = new SqlCommand("AddScrapFG", connection1);
                sqlCommand1.CommandType = CommandType.StoredProcedure;
                SqlCommand sqlCommand2 = sqlCommand1;
                connection1.Open();
                sqlCommand2.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = txtWorkOrder.Text.ToUpper();
                sqlCommand2.Parameters.Add("@Model", SqlDbType.VarChar, 30).Value = dataModel.Text;
                sqlCommand2.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 100).Value = QRSerial;
                sqlCommand2.Parameters.Add("@UserScan", SqlDbType.VarChar, 30).Value = userlabel.Text.ToLower();
                sqlCommand2.Parameters.Add("@ScanDate", SqlDbType.DateTime, 50).Value = Now;
                SqlDataReader sqlDataReader1 = sqlCommand2.ExecuteReader();
                sqlDataReader1.Read();
                int result = sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("rowAffected"));
                connection1.Close();
                if (result == 1)
                {
                    res.Text = "REGISTRO GUARDADO";
                    //res.Text = ActualModel[1].ToString();
                    res.ForeColor = System.Drawing.Color.Green;
                    dataQRSN.Text = QRSerial;
                    txtQRMain.Text = "";
                    SqlConnection connection7 = new SqlConnection(connectionString);
                    SqlCommand sqlCommand13 = new SqlCommand("GetAccumulatedWOScrap", connection7);
                    sqlCommand13.CommandType = CommandType.StoredProcedure;
                    SqlCommand sqlCommand14 = sqlCommand13;
                    connection7.Open();
                    sqlCommand14.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = txtWorkOrder.Text;
                    SqlDataReader sqlDataReader7 = sqlCommand14.ExecuteReader();
                    sqlDataReader7.Read();
                    int AcumWO = sqlDataReader7.GetInt32(sqlDataReader7.GetOrdinal("Accumulated"));
                    connection7.Close();
                    dataAcumWO.Text = AcumWO.ToString();
                    SqlConnection connection8 = new SqlConnection(connectionString);
                    SqlCommand sqlCommand15 = new SqlCommand("GetAccumulatedDayScrap", connection8);
                    sqlCommand15.CommandType = CommandType.StoredProcedure;
                    SqlCommand sqlCommand16 = sqlCommand15;
                    connection8.Open();
                    sqlCommand16.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = txtWorkOrder.Text;
                    SqlDataReader sqlDataReader8 = sqlCommand16.ExecuteReader();
                    sqlDataReader8.Read();
                    int AcumDIA = sqlDataReader8.GetInt32(sqlDataReader8.GetOrdinal("Accumulated"));
                    connection8.Close();
                    dataAcumDia.Text = AcumDIA.ToString();
                }
            }
            else
            {
                res.Text = "REGISTRO SIN GUARDAR";
                res.ForeColor = System.Drawing.Color.Green;
            } 
             */
        }

        protected void CREATE_Click(object sender, EventArgs e)
        {

        }

        protected void SaveChanges_Click(object sender, EventArgs e)
        {

        }

        protected void SAVE_Click(object sender, EventArgs e)
        {

        }

        protected void CancelUser_Click(object sender, EventArgs e)
        {

        }

        protected void myTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}