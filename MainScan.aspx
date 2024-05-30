<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainScan.aspx.cs" Inherits="FinishGoodSMT.MainScan" EnableSessionState="True" %>

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
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <title>Main - Finish Good SMT</title>
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
                        <asp:LinkButton runat="server" class="btn btn-dark border border-0 " ID="LinkButton3" PostBackUrl="~/scanwo.aspx" Text="Regresar" title="Escanear WO - Finish good SMT">
        <span><i class="bi bi-chevron-left fs-4"></i> </span>
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnHome" class=" btn btn-dark border border-0" title="Menu -  Homepage" PostBackUrl="~/menu.aspx" Text="Home">
        <span><i class="bi bi-house-fill fs-4"></i> </span>
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnReparacion" class=" btn btn-dark border border-0" PostBackUrl="~/mainRepair.aspx" OnClientClick="if (!confirm('¿Está seguro que desea ir a REPARACION?')) return false;" Text="Módulo reparacion" ToolTip="Módulo reparacion">
        <span><i class="bi bi-tools fs-4  text-warning fw-bold"></i> </span>
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnRepirValidation" class=" btn btn-dark border border-0" PostBackUrl="~/RepairValidation.aspx" OnClientClick="if (!confirm('¿Está seguro que desea ir a VALIDACION DE REPARACIONES?')) return false;" Text="Módulo reparacion" ToolTip="Módulo validacion reparacion">
<span><i class="bi bi-check2-circle fs-4  text-primary fw-bold"></i> </span>
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnScrap" class=" btn btn-dark border border-0" OnClientClick="if (!confirm('¿Está seguro que desea ir al módulo de SCRAP?')) return false;" PostBackUrl="~/MainScrap.aspx" Text="Módulo Scrap" ToolTip="Módulo Scrap">
        <span><i class="bi bi-trash3-fill   text-danger fw-bold"></i> </span>
                        </asp:LinkButton>
                        <asp:LinkButton type="button" ID="logoutBtn" runat="server" class=" btn btn-dark " OnClientClick="if (!confirm('¿Está seguro que desea salir del sistema?')) return false;" PostBackUrl="~/login.aspx" title="Exit System">
    <span "><i  class="bi bi-box-arrow-right text-danger fs-4"></i></span> 
                        </asp:LinkButton>
                    </div>
                    <div class="navbar-nav mx-auto">
                        <a class="nav-link text-white fw-bold text-success" href="#" title="">FINISH GOOD MAIN</a>
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
        <section class="container mt-3  mx-auto">
            <div class="row row-cols-1 row-cols-md-3 g-4 ">
                <div class="col">
                    <div class="card border-primary ">
                        <div class="card-header bg-primary text-center text-white fw-bold">WORKORDER</div>
                        <div class="card-body text-center">
                            <asp:Label ID="txtWorkOrder" runat="server" CssClass=" text-primary fs-6 fw-bold mt-0"></asp:Label><br />
                            <asp:Label CssClass="fs-6" ID="dataModel" runat="server"></asp:Label><br />
                            <asp:Label CssClass="fs-6" runat="server" ID="dataQtyWO"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="card border-success ">
                        <div class="card-header bg-success text-center text-white fw-bold ">FINISH GOOD</div>
                        <div class="card-body  text-center ">
                            <asp:Label ID="Label2" runat="server" Text="Total:  " CssClass=" fs-4 fw-bold"></asp:Label>
                            <asp:Label ID="dataAcumWO" runat="server" CssClass=" text-success fs-4 fw-bold"></asp:Label><br />
                            <asp:Label CssClass="fs-4 fw-bold " ID="Label5" runat="server" Text="Día: "></asp:Label>
                            <asp:Label CssClass="text-primary fs-4 fw-bold" runat="server" ID="dataAcumDia"></asp:Label><br />
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="card border-danger ">
                        <div class="card-header bg-danger text-center text-white fw-bold ">BACK LOG</div>
                        <div class="card-body mb-0 text-center">
                            <asp:Label ID="Label3" runat="server" Text="Reparación: " CssClass=" fs-4 fw-bold"></asp:Label>
                            <asp:Label ID="dataQtyRepair" runat="server" CssClass="  text-warning  fs-4  fw-bold"></asp:Label><br />
                            <asp:Label CssClass=" fs-4 fw-bold " ID="Label7" runat="server" Text="Scrap: "></asp:Label>
                            <asp:Label CssClass="text-danger fs-4 fw-bold" runat="server" ID="dataQtyScrap"></asp:Label><br />

                        </div>
                    </div>
                </div>
            </div>
        </section>
        <div class="container ">
            <div class="row g-0">
                <div class="card border-dark mt-5">
                    <div class="card-header bg-dark text-center text-white fw-bold fs-4 " runat="server" visible="true">REGISTRAR UNIDAD</div>
                    <div class="card-body  text-center m-0 p-0" runat="server">
                        <div class="input-field rounded-4 text-center mt-0" id="QR">
                            <span class="bi bi-qr-code p-2"></span>
                            <asp:TextBox ID="txtQRMain" runat="server" type="text" AutoPostBack="true" CssClass="form-control fs-2 text-center" placeholder="Escanee QR" OnTextChanged="txtQRMain_TextChanged" AutoCompleteType="Disabled"></asp:TextBox>
                            <asp:LinkButton CssClass="text-dark " ID="btnReset" runat="server" Visible="true" OnClick="btnReset_Click"><span class="bi bi-arrow-repeat p-2"></span></asp:LinkButton>
                        </div>
                    </div>
                    <div class="card-footer bg-ouline-dark text-center mt-2 ">
                        <asp:Label ID="dataQRSN" runat="server" Text="" CssClass="fs-5 text-primary" Style="text-transform: uppercase;"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <%-- alerta --%>
        <div runat="server" id="alert" visible="false" class="" role="alert">
            <span id="AlertIcon" runat="server" class=" me-2 " role="img"></span>
            <asp:Label runat="server" CssClass="fw-bold fs-4" ID="alertText" Text="">
            </asp:Label>
            <button type="button" class="btn-close fs-3" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </form>
</body>
</html>
