<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScrapMain.aspx.cs" Inherits="FinishGoodSMT.ScrapMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" title="Finish Good SMT - SCRAP" />
    <link href="./resources/images/inventronics icon.ico" rel="shortcut icon" />
    <link rel="stylesheet" href="Resources/CSS/styles.css" />
    <link rel="stylesheet" href="Resources/CSS/site.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <title>MAIN SCRAP - Finish Good SMT</title>
</head>
<body >
    <form id="form1" runat="server">
           <nav class="navbar sticky-top navbar-expand-lg  navbar-dark bg-dark">
        <div class="container-fluid">
            <a class="navbar-brand" href="#">
                <img id="logo" class="navbar-brand" src="./resources/images/inv.png" title="Go back to Home" /></a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse mx-auto px-0" id="navbarSupportedContent">
                <div class="btn-group ">
                    <asp:LinkButton runat="server" class="btn btn-dark " ID="LinkButton3" PostBackUrl="~/scanwo.aspx" Text="Regresar" title="Menu - Finish good SMT">
    <span><i class="bi bi-chevron-left fs-5"></i> </span>
                    </asp:LinkButton>
                    <asp:LinkButton runat="server" ID="btnHome" class=" btn btn-dark" title="Inicio -  Homepage" PostBackUrl="~/menu.aspx" Text="Home">
    <span><i class="bi bi-house-fill fs-5"></i> </span>
                    </asp:LinkButton>
                    <%--<asp:LinkButton runat="server" ID="LinkButton1" class="btn btn-dark"><i class="bi bi-person-circle fs-5" ></i></asp:LinkButton>--%>
                    <asp:LinkButton type="button" ID="logoutBtn" runat="server" class=" btn btn-dark text-danger fs-5" OnClientClick="if (!confirm('¿Está seguro que desea salir del sistema?')) return false;" PostBackUrl="~/login.aspx" title="Exit System">
<span class="btn-label"><i  class="bi bi-box-arrow-right"></i></span> 
                    </asp:LinkButton>

                </div>
                <div class="navbar-nav mx-auto">
                    <a class="nav-link text-white fw-bold" href="#" title="">FINISH GOOD MAIN</a>

                </div>
                <div id="form3" runat="server" class="d-flex " role="search">
                    <div class="btn-group ">
                        <asp:LinkButton runat="server" ID="userBtn" class="btn btn-dark"><i class="bi bi-person-circle" ></i></asp:LinkButton>
                        <asp:Label runat="server" ID="userlabel" class=" btn  btn-dark"></asp:Label>
                        <%--<asp:Label runat="server"  ID="userlabel" Font-Size="Smaller" Text="Javier " title="User"></asp:Label>--%>
                    </div>
                </div>
            </div>
        </div>
    </nav>
        <div class="form-material">
            <div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblWO" CssClass="lbldata" runat="server" Text="Work Order" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                <br />
                <asp:Label ID="lblQr" CssClass="lbldata" runat="server" Text="ESCANEAR QR Main" Font-Bold="true"  ></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblSN" Visible="true" CssClass="lbldata" runat="server" Text="QR SCAN:"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblModel" Visible="true" CssClass="lbldata" runat="server" Text="Modelo:"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblQtyWO" CssClass="lbldata" runat="server" Text="Cantidad WO:" Visible="true"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblAcumWO" CssClass="lbldata" runat="server" Text="Acum WO SCRAP:" Visible="true" ForeColor="Red"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblAcumDia" CssClass="lbldata" runat="server" Text="Acum DIA SCRAP:" Visible="true" ForeColor="Red"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                <!--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblQtyRepair" CssClass="lbldata" runat="server" Text="en Reparacion:" Visible="true"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblQtyScrap" CssClass="lbldata" runat="server" Text="Unidades Scrap:" Visible="true"></asp:Label>&nbsp;&nbsp;&nbsp;<br />-->
            </div>
            <div id="modQty">
                <asp:Label ID="txtWorkOrder" CssClass="lbldata4" Font-Bold="true" runat="server" ForeColor="#0079bc"></asp:Label><br />
                <br />
                <asp:TextBox ID="txtQRMain" CssClass="txtboxes" runat="server" ForeColor="#0079bc" AutoPostBack="true" Style="text-transform: uppercase" AutoCompleteType="Disabled" OnTextChanged="txtQRMain_TextChanged"></asp:TextBox><br />
                <br />
                <asp:Label ID="dataQRSN" CssClass="lbldata4" ForeColor="#0079bc" runat="server" Text="" Font-Bold="true" Style="text-transform:uppercase;"></asp:Label><br />
                <asp:Label ID="dataModel" CssClass="lbldata4" ForeColor="#0079bc" runat="server" Text="" Font-Bold="true"></asp:Label><br />
                <asp:Label ID="dataQtyWO" CssClass="lbldata4" ForeColor="#0079bc" runat="server" Text="" Font-Bold="true"></asp:Label><br />
                <asp:Label ID="dataAcumWO" CssClass="lbldata4" ForeColor="#0079bc" runat="server" Text="" Font-Bold="true"></asp:Label><br />
                <asp:Label ID="dataAcumDia" CssClass="lbldata4" ForeColor="#0079bc" runat="server" Text="" Font-Bold="true"></asp:Label><br />
                <!--<asp:Label ID="dataQtyRepair" CssClass="lbldata4" ForeColor="gold" runat="server" Text="" Font-Bold="true"></asp:Label><br />
                <asp:Label ID="dataQtyScrap" CssClass="lbldata4" ForeColor="red" runat="server" Text="" Font-Bold="true"></asp:Label><br />-->
            </div>
        </div>
    </form>
    <div id="res2" visible="true" runat="server">
        <asp:Label Text="" ID="res" Visible="true" CssClass="font-weight-bold" runat="server"></asp:Label><br />
    </div>
</body>
</html>
