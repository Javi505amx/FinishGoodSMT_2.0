<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="FinishGoodSMT.Menu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" title="Finish Good SMT - MENU" />
    <link href="./resources/images/inventronics icon.ico" rel="shortcut icon" />
    <link rel="stylesheet" href="Resources/CSS/styles.css" />
    <link rel="stylesheet" href="Resources/CSS/site.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <title>Finish Good SMT - MENU</title>
</head>
<body class="bg-body-secondary">
    <form runat="server">
        <nav class="navbar sticky-top navbar-expand-lg  navbar-dark bg-dark">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">
                    <img id="logo" class="navbar-brand" src="./resources/images/inv.png" title="Go back to Home" /></a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse mx-auto px-0" id="navbarSupportedContent">
                    <div class="btn-group ">
                        <asp:LinkButton runat="server" class="btn btn-dark " ID="LinkButton3" Text="Regresar" title="Click para regresar">
                        <span><i class="bi bi-chevron-left fs-5"></i> </span>
                        </asp:LinkButton>
                        <asp:LinkButton type="button" ID="logoutBtn" runat="server" class=" btn btn-dark text-danger fs-5" OnClientClick="if (!confirm('¿Está seguro que desea salir del sistema?')) return false;" PostBackUrl="~/login.aspx" title="Exit System">
                    <span class="btn-label"><i  class="bi bi-box-arrow-right"></i></span> 
                        </asp:LinkButton>
                    </div>
                    <div class="navbar-nav mx-auto">
                        <a class="nav-link text-white fw-bold" href="#" title="">MENU</a>

                    </div>
                    <div id="form3" runat="server" class="d-flex " role="search">
                        <div class="btn-group ">
                            <asp:LinkButton runat="server" ID="userBtn" class="btn btn-dark"><i class="bi bi-person-circle" ></i></asp:LinkButton>
                            <asp:Label runat="server" ID="userlabel" class=" btn  btn-dark"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </nav>
        <div class="container mt-5 ">
            <asp:LinkButton ID="btnScanWo" CssClass="btn btn-success btn-lg  rounded-5 d-flex align-items-center justify-content-center mb-2 " runat="server" Visible="true" PostBackUrl="~/ScanWo.aspx">
                   <span class="bg-light ms-2 d-flex rounded-5 align-items-center justify-content-center mx-1"> <i class="bi bi-cpu text-success align-items-center"></i></span>Finish good
            </asp:LinkButton>
            <asp:LinkButton ID="btnConsultaMain" CssClass="btn btn-secondary btn-lg   rounded-5 d-flex align-items-center justify-content-center mb-2  " runat="server" Visible="true" PostBackUrl="~/Reports.aspx">
                   <span class="bg-light ms-2 d-flex rounded-5 align-items-center justify-content-center mx-1"><i class="bi bi-search text-secondary"></i></span>Reportes
            </asp:LinkButton>
            <%--            <asp:LinkButton ID="btnConsultaScard" CssClass="btn btn-secondary btn-lg rounded-5 d-flex align-items-center justify-content-center " runat="server" Visible="true" PostBackUrl="~/WoReviewSMTScard.aspx">
                  <span class="bg-light ms-2 d-flex rounded-5 align-items-center justify-content-center mx-1"><i class="bi bi-card-checklist text-secondary"></i></span>Consulta de WO(Scard)
                </asp:LinkButton>--%>
            <%--<div class="headlines m-0 " ><p>Reparación y  scrap</p></div>--%>
            <asp:LinkButton ID="btnreparacion" CssClass="btn btn-warning btn-lg   rounded-5 d-flex align-items-center justify-content-center  text-white mb-2 " runat="server" Visible="true" PostBackUrl="~/MainRepair.aspx">
                    <span class="bg-light ms-2 d-flex rounded-5 align-items-center justify-content-center mx-1"><i class="bi bi-tools text-warning"></i></span>Reparación
            </asp:LinkButton>
            <asp:LinkButton ID="btnscrapsalida" CssClass="btn btn-primary btn-lg  rounded-5 d-flex align-items-center justify-content-center mb-2  " runat="server" Visible="true" PostBackUrl="~/RepairValidation.aspx">
                   <span class="bg-light ms-2 d-flex rounded-5 align-items-center justify-content-center mx-1"> <i class="bi bi-check2-circle text-primary mx-auto"></i></span>Validar reparación
            </asp:LinkButton>
            <asp:LinkButton ID="btnScrap" CssClass="btn btn-danger btn-lg   rounded-5 d-flex align-items-center justify-content-center  mb-2  " runat="server" Visible="true" PostBackUrl="~/ScanWoScrap.aspx">
                   <span class="bg-light ms-2 d-flex rounded-5 align-items-center justify-content-center mx-1"> <i class="bi bi-trash3-fill text-danger "></i></span>SCRAP
            </asp:LinkButton>
        </div>
        
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
