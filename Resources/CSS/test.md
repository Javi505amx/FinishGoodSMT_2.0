  //string userScan = Session["userLogin"].ToString();
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
  sqlCommand.Parameters.Add("@Main", SqlDbType.VarChar, 50).Value = model;
  sqlCommand.Parameters.Add("@YearWeek", SqlDbType.VarChar, 4).Value = yearWeek;

  sqlCommand.CommandTimeout = 9000;
  SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
  sqlDataReader.Read();
  if (sqlDataReader.HasRows)
  {
      workOrder = sqlDataReader.GetString(sqlDataReader.GetOrdinal("WorkOrder"));
      initialSN = sqlDataReader.GetString(sqlDataReader.GetOrdinal("InitialSN"));
      finalSN = sqlDataReader.GetString(sqlDataReader.GetOrdinal("FinalSN"));
      ywWO = sqlDataReader.GetString(sqlDataReader.GetOrdinal("YearWeek"));
      qty = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Quantity"));
      sqlConnection.Close();
      txtWorkOrder.Text = workOrder;
      dataPieces.Text = qty.ToString() + " PCS";
      dataQRSN.Text = dataScan;
      dataModel.Text = model;
     
      if ((yearWeek == ywWO) && ((Int32.Parse(consec) >= Int32.Parse(initialSN)) && (Int32.Parse(consec) <= Int32.Parse(finalSN))))
      {
          divInfo.Visible = true;
          divFailure.Visible = true;
          QR.Visible = false;
          txtQRMain.Text = string.Empty;
          myTable.Visible = true;
          BindGridView();
          dataBindInfoWO();
          alert.Visible = true;
          AlertIcon.Attributes.Add("class", "bi bi-check-fill");
          alert.Attributes.Add("class", " alert alert-success  alert-dismissible  w-100 text-center fixed-bottom ");
          alertText.Text = "Unidad encontrada: " + dataQRSN.Text;
          ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
      }
      else
      {
          alert.Visible = true;
          AlertIcon.Attributes.Add("class", "bi bi-exclamation-octagon-fill");
          alert.Attributes.Add("class", " alert alert-danger  alert-dismissible  w-100 text-center fixed-bottom ");
          alertText.Text = "QR no ha sido encontrado, inténtelo nuevamente, si el problema persiste contacte a IT";
          ClientScript.RegisterStartupScript(GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + alert.ClientID + "').style.display='none'\",4000)</script>");
          txtQRMain.Focus();
      }
  }
  else
  {
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

  }