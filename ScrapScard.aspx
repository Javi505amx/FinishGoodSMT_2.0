<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScrapScard.aspx.cs" Inherits="FinishGoodSMT.ScrapScard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" title="Finish Good SMT - SCRAP SCARD" />
    <link href="./resources/images/inventronics icon.ico" rel="shortcut icon" />
    <link rel="stylesheet" href="Resources/CSS/styles.css" />
    <link rel="stylesheet" href="Resources/CSS/site.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <title>SCARD SCRAP - Finish Good SMT</title>
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
                        <a class="nav-link text-danger fw-bold" href="#" title="">SCRAP SCARD</a>

                    </div>
                    <div id="form3" runat="server" class="d-flex " role="search">
                        <div class="btn-group ">
                            <asp:LinkButton runat="server" ID="userBtn" class="btn btn-dark"><i class="bi bi-person-circle" ></i></asp:LinkButton>
                            <asp:Label runat="server" ID="userlabel"  CssClass=" btn  btn-dark"></asp:Label>
                            <%--<asp:Label runat="server"  ID="userlabel" Font-Size="Smaller" Text="Javier " title="User"></asp:Label>--%>
                        </div>
                    </div>
                </div>
            </div>
        </nav>



        <section class="container mt-3  mx-auto">
            <div class="row row-cols-1 row-cols-md-3 g-4 ">
                <div class="col">
                    <div class="card border-primary ">
                        <%--<img src="./resources/images/FG.png" class="card-img-top" alt="..." />--%>
                        <div class="card-header bg-primary text-center text-white fw-bold">WORKORDER</div>
                        <div class="card-body text-center">
                            <%--<asp:Label ID="Label4" runat="server" Text="WO: " CssClass=" text-dark fs-3 fw-bold"></asp:Label>--%>
                            <asp:Label ID="txtWorkOrder" runat="server" CssClass=" text-primary fs-6 fw-bold mt-0"></asp:Label><br />
                            <asp:Label CssClass="fs-6" ID="dataModel" runat="server"></asp:Label><br />
                            <asp:Label CssClass="fs-6" runat="server" ID="dataQtyWO"></asp:Label><br />
                            <%--<asp:Label CssClass="fs-6" runat="server" Text="Panel: " ID="Label1"></asp:Label>--%>
                            <asp:Label CssClass="fs-6" runat="server" ID="dataPieces" Visible="false"></asp:Label>

                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="card border-success ">
                        <%--<img src="./resources/images/FG.png" class="card-img-top" alt="..." />--%>
                        <div class="card-header bg-success text-center text-white fw-bold ">FINISH GOOD</div>
                        <div class="card-body  text-center ">
                            <%--<asp:Label ID="Label4" runat="server" Text="acumulado  " CssClass=" text-body-secondary text-center"></asp:Label><br />--%>
                            <asp:Label ID="Label6" runat="server" Text="Total:  " CssClass=" fs-4 fw-bold"></asp:Label>
                            <asp:Label ID="dataAcumWO" runat="server" CssClass=" text-success fs-4 fw-bold"></asp:Label><br />
                            <asp:Label CssClass="fs-4 fw-bold " ID="Label8" runat="server" Text="Día: "></asp:Label>
                            <asp:Label CssClass="text-primary fs-4 fw-bold" runat="server" ID="dataAcumDia"></asp:Label><br />
                            <%--<asp:Label runat="server" ID="dataAcumWO"></asp:Label>--%>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="card border-danger ">
                        <%--<img src="./resources/images/FG.png" class="card-img-top" alt="..." />--%>
                        <div class="card-header bg-danger text-center text-white fw-bold ">BACK LOG</div>
                        <div class="card-body mb-0 text-center">
                            <asp:Label ID="Label10" runat="server" Text="Reparación: " CssClass=" fs-4 fw-bold"></asp:Label>
                            <asp:Label ID="dataQtyRepair" runat="server" CssClass=" text-warning fs-4 fw-bold"></asp:Label><br />
                            <asp:Label CssClass=" fs-4 fw-bold " ID="Label12" runat="server" Text="Scrap: "></asp:Label>
                            <asp:Label CssClass="text-danger fs-4 fw-bold" runat="server" ID="dataQtyScrap"></asp:Label><br />
                            <%--<asp:Label CssClass="fs-6 " runat="server" ID="" Text=""></asp:Label>--%>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <div class="container ">
            <div class="row g-0">

                <div class="card border-dark mt-5">

                    <div class="card-header bg-dark text-center text-danger fw-bold fs-4 " runat="server" visible="true">REGISTRAR SCRAP POR PANEL</div>

                    <div class="card-body  text-center m-0 p-0" runat="server">
                        <%--<asp:TextBox ID="txtQRMain" CssClass="txtboxes" runat="server" ForeColor="#0079bc" AutoPostBack="true" Style="text-transform: uppercase" AutoCompleteType="Disabled" OnTextChanged="txtQRMain_TextChanged"></asp:TextBox>--%><br />
                        <%--<asp:Label ID="labelModel" CssClass="text-primary fs-4" runat="server" Font-Bold="true"></asp:Label>--%>
                        <asp:Label runat="server" ID="labelModel" CssClass="text-primary fs-4 fw-bold"></asp:Label><br />
                        <div class="input-field rounded-4 text-center mt-0" id="QR">
                            <span class="bi bi bi-123 p-2"></span>
                            <asp:TextBox ID="txtQty" runat="server" TextMode="Number" AutoPostBack="true" CssClass="form-control fs-2 text-center" placeholder="" OnTextChanged="txtQty_TextChanged1" AutoCompleteType="Disabled" CausesValidation="true"></asp:TextBox><br />

                            <%--<asp:LinkButton CssClass="btnReset" ID="LinkButton1" runat="server" Visible="false" OnClick="btnReset_Click"><span class="bi bi-arrow-repeat p-2"></span></asp:LinkButton>--%>
                        </div>
                        <asp:Label runat="server" ID="errorQty" Font-Size="Large" CssClass="text-danger mx-auto text-center" Text="La cantidad ingresada excede la cantidad por panel." Visible="false"></asp:Label><br />
                        <asp:RangeValidator ID="validator" ControlToValidate="txtQty" ErrorMessage="La cantidad ingresada excede la cantidad por panel" CssClass="text-danger" Font-Size="Large" runat="server"></asp:RangeValidator>


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
    <div id="res2" visible="true" runat="server">
        <asp:Label Text="" ID="res" Visible="true" CssClass="font-weight-bold" runat="server"></asp:Label><br />
    </div>
</body>
</html>
