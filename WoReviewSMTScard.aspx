<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WoReviewSMTScard.aspx.cs" Inherits="FinishGoodSMT.WoReviewSMTScard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Resources/Images/inventronics icon.ico" rel="icon" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="Resources/CSS/Styles.css" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.9.0.min.js"></script>
    <script src="Resources/JS/script.js"></script>
    
    <title>Consulta WO</title>
</head>
<body class="body-menu">
    <form id="form1" runat="server">
        <div class="header-menu">
            <div class="nav-logo">
                <asp:Image ImageUrl="~/Resources/Images/inv.png" runat="server" Height="50px" Width="150px" />
            </div>
            <h1>CONSULTA WO SCARD</h1>
        </div>
        <div class="form-material">
            <asp:Label ID="lblWO" runat="server" Text="INGRESAR WORK ORDER" Font-Size="150%" Font-Bold="true"></asp:Label><br />
            <asp:TextBox ID="txtWO" runat="server" ForeColor="#0079bc" AutoPostBack="true" Font-Size="150%" Style="text-transform: uppercase" AutoCompleteType="Disabled" OnTextChanged="txtWO_TextChanged"></asp:TextBox><br />
        </div>
        <div class="form-control ">
            <div class="scrolling-table-container ">
                <asp:GridView ID="GridView1" HeaderStyle-CssClass="bg-secondary text-white" ShowHeaderWhenEmpty="true" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover table-condensed small-top-margin" AllowSorting="True">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" ></asp:BoundField>
                        <asp:BoundField DataField="WorkOrder" HeaderText="WorkOrder"></asp:BoundField>
                        <asp:BoundField DataField="Model" HeaderText="Model" ></asp:BoundField>
                        <asp:BoundField DataField="Pieces" HeaderText="Pieces" ></asp:BoundField>
                        <asp:BoundField DataField="UserScan" HeaderText="UserScan" ></asp:BoundField>
                        <asp:BoundField DataField="ScanDate" HeaderText="ScanDate" ></asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div class="text-center">Sin registros</div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
        <div class="container6">
            <div id="labels" class="labels">
                <asp:Label ID="data1" runat="server" Text="Total WO:" Visible="false"></asp:Label><br />
                <asp:Label ID="data2" runat="server" Text="Ingresadas:" Visible="false"></asp:Label><br />
                <asp:Label ID="data3" runat="server" Text="Scrap:" Visible="false"></asp:Label><br />
                <asp:Label ID="data4" runat="server" Text="Diagnosticadas:" Visible="false"></asp:Label><br />
                <asp:Label ID="data5" runat="server" Text="Reparadas:" Visible="false"></asp:Label>
            </div>
            <div id="labelr" class="labelr">
                &nbsp;&nbsp;<asp:Label ID="lblTotalWO" runat="server" Text="" Visible="false"></asp:Label><br />
                &nbsp;&nbsp;<asp:Label ID="lblIng" runat="server" Text="" Visible="false"></asp:Label><br />
                &nbsp;&nbsp;<asp:Label ID="lblScrap" runat="server" Text="" Visible="false"></asp:Label><br />
                &nbsp;&nbsp;<asp:Label ID="lblDiag" runat="server" Text="" Visible="false"></asp:Label><br />
                &nbsp;&nbsp;<asp:Label ID="lblRepa" runat="server" Text="" Visible="false"></asp:Label><br />
            </div>
        </div>
        <div id="nav-user" class="mx-auto" style="width: 1100px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="userlbl" runat="server" Text="Usuario:"></asp:Label>
            <asp:Label ID="userlabel" runat="server" Text=""></asp:Label>
        </div>
        <asp:LinkButton CssClass="btnLogout" runat="server" PostBackUrl="~/Menu.aspx">
                <span class="fas fa-backspace" aria-hidden="true"></span> &nbsp;Menú
        </asp:LinkButton>
        <asp:LinkButton CssClass="btnLogout2" runat="server" PostBackUrl="~/Login.aspx">
                <span class="fas fa-sign-out-alt" aria-hidden="true"></span> &nbsp;
        </asp:LinkButton>
        <asp:LinkButton ID="btn_export" CssClass="btnLogout3" runat="server" OnClick="btn_export_Click">
                <span class="fas fa-sign-out-alt" aria-hidden="true"></span> &nbsp;Exportar
        </asp:LinkButton>
    </form>
</body>
</html>
