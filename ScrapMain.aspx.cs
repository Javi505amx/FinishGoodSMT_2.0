using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FinishGoodSMT
{
    public partial class ScrapMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //userlbl.Visible = true;
            userlabel.Text = Session["user"].ToString();
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string str = Session["workOrder"].ToString();
            txtWorkOrder.Text = Session["workOrder"].ToString();
            dataModel.Text = Session["modelWO"].ToString();
            dataQtyWO.Text = Session["qty"].ToString();
            //SqlConnection connection1 = new SqlConnection(connectionString);
            //SqlCommand sqlCommand1 = new SqlCommand("GetAccumulatedFG", connection1);
            //sqlCommand1.CommandType = CommandType.StoredProcedure;
            //SqlCommand sqlCommand2 = sqlCommand1;
            //connection1.Open();
            //sqlCommand2.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str;
            //sqlCommand2.CommandTimeout = 9000;
            //SqlDataReader sqlDataReader1 = sqlCommand2.ExecuteReader();
            //sqlDataReader1.Read();
            //int int32_1 = sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("Accumulated"));
            //connection1.Close();
            //dataAcumWO.Text = int32_1.ToString();
            //SqlConnection connection2 = new SqlConnection(connectionString);
            //SqlCommand sqlCommand3 = new SqlCommand("GetAccumulatedDayFG", connection2);
            //sqlCommand3.CommandType = CommandType.StoredProcedure;
            //SqlCommand sqlCommand4 = sqlCommand3;
            //connection2.Open();
            //sqlCommand4.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str;
            //sqlCommand4.CommandTimeout = 9000;
            //SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
            //sqlDataReader2.Read();
            //int int32_2 = sqlDataReader2.GetInt32(sqlDataReader2.GetOrdinal("Accumulated"));
            //connection2.Close();
            //dataAcumDia.Text = int32_2.ToString();
            //SqlConnection connection3 = new SqlConnection(connectionString);
            //SqlCommand sqlCommand5 = new SqlCommand("GetTotalMain", connection3);
            //sqlCommand5.CommandType = CommandType.StoredProcedure;
            //SqlCommand sqlCommand6 = sqlCommand5;
            //connection3.Open();
            //sqlCommand6.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str;
            //sqlCommand6.CommandTimeout = 9000;
            //SqlDataReader sqlDataReader3 = sqlCommand6.ExecuteReader();
            //sqlDataReader3.Read();
            //int int32_3 = sqlDataReader3.GetInt32(sqlDataReader3.GetOrdinal("Repair"));
            //connection3.Close();
            //dataQtyRepair.Text = int32_3.ToString();
            //SqlConnection connection4 = new SqlConnection(connectionString);
            //SqlCommand sqlCommand7 = new SqlCommand("GetAccumulatedWOScrap", connection4);
            //sqlCommand7.CommandType = CommandType.StoredProcedure;
            //SqlCommand sqlCommand8 = sqlCommand7;
            //connection4.Open();
            //sqlCommand8.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str;
            //SqlDataReader sqlDataReader4 = sqlCommand8.ExecuteReader();
            //sqlDataReader4.Read();
            //int int32_4 = sqlDataReader4.GetInt32(sqlDataReader4.GetOrdinal("Accumulated"));
            //connection4.Close();
            //dataQtyScrap.Text = int32_4.ToString();
            //txtQRMain.Focus();
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

        protected void txtQRMain_TextChanged(object sender, EventArgs e) 
        {
            //string QRSerial = txtQRMain.Text.ToString();
            //string WO = txtWorkOrder.Text.ToString();
            //string user = userlabel.Text.ToLower();
            //string data = txtQRMain.Text.ToString();
            //string str3 = data.Substring(0, 4);
            //DateTime Now = DateTime.Now;
            //data.Substring(4, 3);
            //string[] strArray = data.Split('-');
            //string upper = strArray[0].ToUpper();
            //string str4 = strArray[1].ToUpper();
            //string s1 = upper.Substring(8);
            //if (strArray.Length > 2)
            //    str4 = str4 + "-" + strArray[2].ToUpper();
            //string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            //SqlConnection connection1 = new SqlConnection(connectionString);
            //SqlCommand sqlCommand1 = new SqlCommand("GetDetailsWorkOrder", connection1);
            //sqlCommand1.CommandType = CommandType.StoredProcedure;
            //SqlCommand sqlCommand2 = sqlCommand1;
            //connection1.Open();
            //sqlCommand2.Parameters.Add("@Main", SqlDbType.VarChar, 50).Value = str4;
            //sqlCommand2.Parameters.Add("@YearWeek", SqlDbType.VarChar, 50).Value = str3;
            //sqlCommand2.CommandTimeout = 9000;
            //SqlDataReader sqlDataReader1 = sqlCommand2.ExecuteReader();
            //sqlDataReader1.Read();
            //try
            //{
            //    string str5 = sqlDataReader1.GetString(sqlDataReader1.GetOrdinal("WorkOrder"));
            //    string s2 = sqlDataReader1.GetString(sqlDataReader1.GetOrdinal("InitialSN"));
            //    string s3 = sqlDataReader1.GetString(sqlDataReader1.GetOrdinal("FinalSN"));
            //    string str6 = sqlDataReader1.GetString(sqlDataReader1.GetOrdinal("YearWeek"));
            //    int int32_1 = sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("Quantity"));
            //    connection1.Close();
            //    txtWorkOrder.Text = str5;
            //    dataQtyWO.Text = int32_1.ToString();
            //    dataQRSN.Text = data;
            //    dataModel.Text = str4;
            //    if (str3 == str6 && int.Parse(s1) >= int.Parse(s2) && int.Parse(s1) <= int.Parse(s3) && WO == str5)
            //    {
            //       // string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            //        SqlConnection connectionx = new SqlConnection(connectionString);
            //        SqlCommand sqlCommandx = new SqlCommand("AddScrapFG", connectionx);
            //        sqlCommand1.CommandType = CommandType.StoredProcedure;
            //        SqlCommand sqlCommandy = sqlCommandx;
            //        connection1.Open();
            //        sqlCommand2.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = txtWorkOrder.Text.ToUpper();
            //        sqlCommand2.Parameters.Add("@Model", SqlDbType.VarChar, 30).Value = dataModel.Text;
            //        sqlCommand2.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 100).Value = QRSerial;
            //        sqlCommand2.Parameters.Add("@UserScan", SqlDbType.VarChar, 30).Value = userlabel.Text.ToLower();
            //        sqlCommand2.Parameters.Add("@ScanDate", SqlDbType.DateTime, 50).Value = Now;
            //        SqlDataReader sqlDataReadery = sqlCommand2.ExecuteReader();
            //        sqlDataReadery.Read();
            //        int result = sqlDataReadery.GetInt32(sqlDataReader1.GetOrdinal("rowAffected"));
            //        connection1.Close();
            //        if (result == 1)
            //        {
            //            res.Text = "REGISTRO GUARDADO";
            //            //res.Text = ActualModel[1].ToString();
            //            res.ForeColor = System.Drawing.Color.Green;
            //            dataQRSN.Text = QRSerial;
            //            txtQRMain.Text = "";
            //            SqlConnection connection7 = new SqlConnection(connectionString);
            //            SqlCommand sqlCommand13 = new SqlCommand("GetAccumulatedWOScrap", connection7);
            //            sqlCommand13.CommandType = CommandType.StoredProcedure;
            //            SqlCommand sqlCommand14 = sqlCommand13;
            //            connection7.Open();
            //            sqlCommand14.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = txtWorkOrder.Text;
            //            SqlDataReader sqlDataReader7 = sqlCommand14.ExecuteReader();
            //            sqlDataReader7.Read();
            //            int AcumWO = sqlDataReader7.GetInt32(sqlDataReader7.GetOrdinal("Accumulated"));
            //            connection7.Close();
            //            dataAcumWO.Text = AcumWO.ToString();
            //            SqlConnection connection8 = new SqlConnection(connectionString);
            //            SqlCommand sqlCommand15 = new SqlCommand("GetAccumulatedDayScrap", connection8);
            //            sqlCommand15.CommandType = CommandType.StoredProcedure;
            //            SqlCommand sqlCommand16 = sqlCommand15;
            //            connection8.Open();
            //            sqlCommand16.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = txtWorkOrder.Text;
            //            SqlDataReader sqlDataReader8 = sqlCommand16.ExecuteReader();
            //            sqlDataReader8.Read();
            //            int AcumDIA = sqlDataReader8.GetInt32(sqlDataReader8.GetOrdinal("Accumulated"));
            //            connection8.Close();
            //            dataAcumDia.Text = AcumDIA.ToString();
            //        }
            //        //TODO HAcer else aqui para validacion de pieza en scrap
            //    }


            // }
            //catch (Exception ex)
            //{ 
            //}
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
            try
            {
                string str5 = sqlDataReader1.GetString(sqlDataReader1.GetOrdinal("WorkOrder"));
                string s2 = sqlDataReader1.GetString(sqlDataReader1.GetOrdinal("InitialSN"));
                string s3 = sqlDataReader1.GetString(sqlDataReader1.GetOrdinal("FinalSN"));
                string str6 = sqlDataReader1.GetString(sqlDataReader1.GetOrdinal("YearWeek"));
                int int32_1 = sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("Quantity"));
                connection1.Close();
                txtWorkOrder.Text = str5;
                dataQtyWO.Text = int32_1.ToString();
                dataQRSN.Text = text;
                dataModel.Text = str4;
                if (str3 == str6 && int.Parse(s1) >= int.Parse(s2) && int.Parse(s1) <= int.Parse(s3) && str1 == str5)
                {
                    SqlConnection connection2 = new SqlConnection(connectionString);
                    SqlCommand sqlCommand3 = new SqlCommand("AddScrapFG", connection2);
                    sqlCommand3.CommandType = CommandType.StoredProcedure;
                    SqlCommand sqlCommand4 = sqlCommand3;
                    connection2.Open();
                    sqlCommand2.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = txtWorkOrder.Text.ToUpper();
                    sqlCommand2.Parameters.Add("@Model", SqlDbType.VarChar, 30).Value = dataModel.Text;
                    sqlCommand2.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 100).Value = text;
                    sqlCommand2.Parameters.Add("@UserScan", SqlDbType.VarChar, 30).Value = userlabel.Text.ToLower();
                    sqlCommand2.Parameters.Add("@ScanDate", SqlDbType.DateTime, 50).Value = DateTime.Now;
                    sqlCommand4.CommandTimeout = 9000;
                    SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
                    sqlDataReader2.Read();
                    int int32_2 = sqlDataReader2.GetInt32(sqlDataReader2.GetOrdinal("rowAffected"));
                    connection2.Close();
                    switch (int32_2)
                    {
                        case 0:
                            SqlConnection connection3 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand5 = new SqlCommand("GetAccumulatedFG", connection3);
                            sqlCommand5.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand6 = sqlCommand5;
                            connection3.Open();
                            sqlCommand6.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand6.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader3 = sqlCommand6.ExecuteReader();
                            sqlDataReader3.Read();
                            int int32_3 = sqlDataReader3.GetInt32(sqlDataReader3.GetOrdinal("Accumulated"));
                            connection3.Close();
                            dataAcumWO.Text = int32_3.ToString();
                            SqlConnection connection4 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand7 = new SqlCommand("GetAccumulatedDayFG", connection4);
                            sqlCommand7.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand8 = sqlCommand7;
                            connection4.Open();
                            sqlCommand8.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand8.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader4 = sqlCommand8.ExecuteReader();
                            sqlDataReader4.Read();
                            int int32_4 = sqlDataReader4.GetInt32(sqlDataReader4.GetOrdinal("Accumulated"));
                            connection4.Close();
                            dataAcumDia.Text = int32_4.ToString();
                            SqlConnection connection5 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand9 = new SqlCommand("GetTotalMainFG", connection5);
                            sqlCommand9.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand10 = sqlCommand9;
                            connection5.Open();
                            sqlCommand10.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand10.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader5 = sqlCommand10.ExecuteReader();
                            sqlDataReader5.Read();
                            int int32_5 = sqlDataReader5.GetInt32(sqlDataReader5.GetOrdinal("Repair"));
                            connection5.Close();
                            dataQtyRepair.Text = int32_5.ToString();
                            SqlConnection connection6 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand11 = new SqlCommand("GetAccumulatedWOScrap", connection6);
                            sqlCommand11.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand12 = sqlCommand11;
                            connection6.Open();
                            sqlCommand12.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            SqlDataReader sqlDataReader6 = sqlCommand12.ExecuteReader();
                            sqlDataReader6.Read();
                            int int32_6 = sqlDataReader6.GetInt32(sqlDataReader6.GetOrdinal("Accumulated"));
                            connection6.Close();
                            dataQtyScrap.Text = int32_6.ToString();
                            res.Text = "QR DUPLICADO";
                            res.ForeColor = System.Drawing.Color.Red;
                            break;
                        case 1:
                            res.Text = "REGISTRO GUARDADO";
                            //res.Text = ActualModel[1].ToString();
                            res.ForeColor = System.Drawing.Color.Green;
                            dataQRSN.Text = text;
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
                            break;
                        case 2:
                            SqlConnection connection12 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand23 = new SqlCommand("GetAccumulatedFG", connection12);
                            sqlCommand23.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand24 = sqlCommand23;
                            connection12.Open();
                            sqlCommand24.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand24.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader12 = sqlCommand24.ExecuteReader();
                            sqlDataReader12.Read();
                            int int32_11 = sqlDataReader12.GetInt32(sqlDataReader12.GetOrdinal("Accumulated"));
                            connection12.Close();
                            dataAcumWO.Text = int32_11.ToString();
                            SqlConnection connection13 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand25 = new SqlCommand("GetAccumulatedDayFG", connection13);
                            sqlCommand25.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand26 = sqlCommand25;
                            connection13.Open();
                            sqlCommand26.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand26.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader13 = sqlCommand26.ExecuteReader();
                            sqlDataReader13.Read();
                            int int32_12 = sqlDataReader13.GetInt32(sqlDataReader13.GetOrdinal("Accumulated"));
                            connection13.Close();
                            dataAcumDia.Text = int32_12.ToString();
                            SqlConnection connection14 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand27 = new SqlCommand("GetTotalMain", connection14);
                            sqlCommand27.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand28 = sqlCommand27;
                            connection14.Open();
                            sqlCommand28.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand28.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader14 = sqlCommand28.ExecuteReader();
                            sqlDataReader14.Read();
                            int int32_13 = sqlDataReader14.GetInt32(sqlDataReader14.GetOrdinal("Repair"));
                            connection14.Close();
                            dataQtyRepair.Text = int32_13.ToString();
                            SqlConnection connection15 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand29 = new SqlCommand("GetAccumulatedWOScrap", connection15);
                            sqlCommand29.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand30 = sqlCommand29;
                            connection15.Open();
                            sqlCommand30.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            SqlDataReader sqlDataReader15 = sqlCommand30.ExecuteReader();
                            sqlDataReader15.Read();
                            int int32_14 = sqlDataReader15.GetInt32(sqlDataReader15.GetOrdinal("Accumulated"));
                            connection15.Close();
                            dataQtyScrap.Text = int32_14.ToString();
                            res.Text = "PIEZA EN REPARACIÓN";
                            res.ForeColor = System.Drawing.Color.Red;
                            break;
                        case 3:
                            SqlConnection connection16 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand31 = new SqlCommand("GetAccumulatedFG", connection16);
                            sqlCommand31.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand32 = sqlCommand31;
                            connection16.Open();
                            sqlCommand32.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand32.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader16 = sqlCommand32.ExecuteReader();
                            sqlDataReader16.Read();
                            int int32_15 = sqlDataReader16.GetInt32(sqlDataReader16.GetOrdinal("Accumulated"));
                            connection16.Close();
                            dataAcumWO.Text = int32_15.ToString();
                            SqlConnection connection17 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand33 = new SqlCommand("GetAccumulatedDayFG", connection17);
                            sqlCommand33.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand34 = sqlCommand33;
                            connection17.Open();
                            sqlCommand34.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand34.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader17 = sqlCommand34.ExecuteReader();
                            sqlDataReader17.Read();
                            int int32_16 = sqlDataReader17.GetInt32(sqlDataReader17.GetOrdinal("Accumulated"));
                            connection17.Close();
                            dataAcumDia.Text = int32_16.ToString();
                            SqlConnection connection18 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand35 = new SqlCommand("GetTotalMain", connection18);
                            sqlCommand35.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand36 = sqlCommand35;
                            connection18.Open();
                            sqlCommand36.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand36.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader18 = sqlCommand36.ExecuteReader();
                            sqlDataReader18.Read();
                            int int32_17 = sqlDataReader18.GetInt32(sqlDataReader18.GetOrdinal("Repair"));
                            connection18.Close();
                            dataQtyRepair.Text = int32_17.ToString();
                            SqlConnection connection19 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand37 = new SqlCommand("GetAccumulatedWOScrap", connection19);
                            sqlCommand37.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand38 = sqlCommand37;
                            connection19.Open();
                            sqlCommand38.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            SqlDataReader sqlDataReader19 = sqlCommand38.ExecuteReader();
                            sqlDataReader19.Read();
                            int int32_18 = sqlDataReader19.GetInt32(sqlDataReader19.GetOrdinal("Accumulated"));
                            connection19.Close();
                            dataQtyScrap.Text = int32_18.ToString();
                            res.Text = "PIEZA SCRAP";
                            res.ForeColor = System.Drawing.Color.Red;
                            break;
                    }

                }
                else if (str3 == str6 && int.Parse(s1) >= int.Parse(s2) && int.Parse(s1) <= int.Parse(s3) && str1 != str5)
                {
                    SqlConnection connection20 = new SqlConnection(connectionString);
                    SqlCommand sqlCommand39 = new SqlCommand("GetAccumulatedFG", connection20);
                    sqlCommand39.CommandType = CommandType.StoredProcedure;
                    SqlCommand sqlCommand40 = sqlCommand39;
                    connection20.Open();
                    sqlCommand40.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str1;
                    sqlCommand40.CommandTimeout = 9000;
                    SqlDataReader sqlDataReader20 = sqlCommand40.ExecuteReader();
                    sqlDataReader20.Read();
                    int int32_19 = sqlDataReader20.GetInt32(sqlDataReader20.GetOrdinal("Accumulated"));
                    connection20.Close();
                    dataAcumWO.Text = int32_19.ToString();
                    SqlConnection connection21 = new SqlConnection(connectionString);
                    SqlCommand sqlCommand41 = new SqlCommand("GetAccumulatedDayFG", connection21);
                    sqlCommand41.CommandType = CommandType.StoredProcedure;
                    SqlCommand sqlCommand42 = sqlCommand41;
                    connection21.Open();
                    sqlCommand42.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str1;
                    sqlCommand42.CommandTimeout = 9000;
                    SqlDataReader sqlDataReader21 = sqlCommand42.ExecuteReader();
                    sqlDataReader21.Read();
                    int int32_20 = sqlDataReader21.GetInt32(sqlDataReader21.GetOrdinal("Accumulated"));
                    connection21.Close();
                    dataAcumDia.Text = int32_20.ToString();
                    SqlConnection connection22 = new SqlConnection(connectionString);
                    SqlCommand sqlCommand43 = new SqlCommand("GetTotalMain", connection22);
                    sqlCommand43.CommandType = CommandType.StoredProcedure;
                    SqlCommand sqlCommand44 = sqlCommand43;
                    connection22.Open();
                    sqlCommand44.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str1;
                    sqlCommand44.CommandTimeout = 9000;
                    SqlDataReader sqlDataReader22 = sqlCommand44.ExecuteReader();
                    sqlDataReader22.Read();
                    int int32_21 = sqlDataReader22.GetInt32(sqlDataReader22.GetOrdinal("Repair"));
                    connection22.Close();
                    dataQtyRepair.Text = int32_21.ToString();
                    SqlConnection connection23 = new SqlConnection(connectionString);
                    SqlCommand sqlCommand45 = new SqlCommand("GetAccumulatedWOScrap", connection23);
                    sqlCommand45.CommandType = CommandType.StoredProcedure;
                    SqlCommand sqlCommand46 = sqlCommand45;
                    connection23.Open();
                    sqlCommand46.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str1;
                    SqlDataReader sqlDataReader23 = sqlCommand46.ExecuteReader();
                    sqlDataReader23.Read();
                    int int32_22 = sqlDataReader23.GetInt32(sqlDataReader23.GetOrdinal("Accumulated"));
                    connection23.Close();
                    dataQtyScrap.Text = int32_22.ToString();
                    res.Text = "QR NO COINCIDE CON LA WORK ORDER ESCANEADA";
                    res.ForeColor = System.Drawing.Color.Red;
                }
                else if (int.Parse(s1) > int.Parse(s3))
                {
                    res.Text = "QR NO ENCONTRADO. CONTACTE AL DEPTO DE IT.";
                    res.ForeColor = System.Drawing.Color.Red;
                    txtQRMain.Text = "";
                    txtQRMain.Focus();
                }
            }
            catch (Exception ex)
            {
                res.Text = "QR NO ENCONTRADO. CONTACTE AL DEPTO DE IT.";
                res.ForeColor = System.Drawing.Color.Red;
                txtQRMain.Text = "";
                txtQRMain.Focus();
            }
            txtQRMain.Text = "";
            txtQRMain.Focus();
        }









    }

       
    
}