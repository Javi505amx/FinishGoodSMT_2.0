<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScanWoRepair.aspx.cs" Inherits="FinishGoodSMT.ScanWoRepair" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" title="Finish Good SMT - SCAN WO REPAIR" />
    <link href="./resources/images/inventronics icon.ico" rel="shortcut icon" />
    <link rel="stylesheet" href="Resources/CSS/styles.css" />
    <link rel="stylesheet" href="Resources/CSS/site.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <title>Workorder  - Reparación SMT</title>
</head>
<body>
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
                        <asp:LinkButton runat="server" class="btn btn-dark " ID="LinkButton3" PostBackUrl="~/menu.aspx" Text="Regresar" title="Menu - Finish good SMT">
                <span><i class="bi bi-chevron-left fs-5"></i> </span>
                        </asp:LinkButton>
                        <%--                        <asp:LinkButton runat="server" ID="btnHome" class=" btn btn-dark" title="Inicio -  Homepage" PostBackUrl="~/login.aspx" Text="Home">
                <span><i class="bi bi-house-fill fs-5"></i> </span>
                        </asp:LinkButton>--%>
                        <%--<asp:LinkButton runat="server" ID="LinkButton1" class="btn btn-dark"><i class="bi bi-person-circle fs-5" ></i></asp:LinkButton>--%>
                        <asp:LinkButton type="button" ID="logoutBtn" runat="server" class=" btn btn-dark text-danger fs-5" OnClientClick="if (!confirm('¿Está seguro que desea salir del sistema?')) return false;" PostBackUrl="~/login.aspx" title="Exit System">
            <span class="btn-label"><i  class="bi bi-box-arrow-right"></i></span> 
                        </asp:LinkButton>

                    </div>
                    <div class="navbar-nav mx-auto">
                        <a class="nav-link text-warning fw-bold" href="#" title="">INGRESAR WORKORDER</a>

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


        <div class="container-fluid ">

            <div class="form-group row  py-2 position-absolute top-50 start-50 translate-middle w-75">
                <div class="input-field rounded-4  col-md-12 mx-auto text-center txtWorkOrderRepair">
                    <span class="bi bi-tools p-2 text-warning"></span>

                    <%--<asp:Label ID="lblWorkOrder" for="txtWorkOrder" runat="server" Text="INGRESAR WORKORDER" CssClass="form-label fs-1"></asp:Label>--%>
                    <asp:TextBox ID="txtWorkOrderRepair" runat="server" type="text" AutoPostBack="true" CssClass="form-control-lg fs-1 text-center text-warning" placeholder="Escanee workorder" OnTextChanged="txtWorkOrderRepair_TextChanged" AutoCompleteType="Disabled"></asp:TextBox>

                </div>
            </div>

        </div>
    <%-- alerta --%>
    <div runat="server" id="alert" visible="false" class="" role="alert">
        <span id="AlertIcon" runat="server" class=" me-2" role="img"></span>
        <asp:Label runat="server" CssClass="fw-bold fs-4" ID="alertText" Text="">

        </asp:Label>
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>
    </form>
</body>
</html>
