<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainScrap.aspx.cs" Inherits="FinishGoodSMT.MainScrap" %>

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
    <title>MAIN SCRAP - Finish Good SMT</title>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar sticky-top navbar-expand-lg  navbar-dark bg-dark">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">
                    <img id="logo" class="navbar-brand" src="./resources/images/inv.png" style="width: 150px" title="Go back to Home" /></a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse mx-auto px-0" id="navbarSupportedContent">
                    <div class="btn-group ">
                       <%-- <asp:LinkButton runat="server" class="btn btn-dark " ID="LinkButton3" PostBackUrl="~/Menu.aspx" Text="Regresar" title="Menu - Finish good SMT">
    <span><i class="bi bi-chevron-left fs-5 text-white"></i> </span>
                        </asp:LinkButton>--%>
                        <asp:LinkButton runat="server" ID="btnHome" class=" btn btn-dark " title="Inicio -  Homepage" PostBackUrl="~/menu.aspx" Text="Home">
    <span><i class="bi bi-house-fill fs-5 text-white"></i> </span>
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnFG" class=" btn btn-dark border border-0" PostBackUrl="~/scanWO.aspx" OnClientClick="if (!confirm('¿Está seguro que desea ir a FINISH GOOD?')) return false;" Text="Módulo reparacion" ToolTip="Módulo reparacion">
<span><i class="bi bi-cpu-fill fs-4  text-success fw-bold"></i> </span>
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnReparacion" class=" btn btn-dark border border-0" PostBackUrl="~/mainRepair.aspx" OnClientClick="if (!confirm('¿Está seguro que desea ir a REPARACION?')) return false;" Text="Módulo reparacion" ToolTip="Módulo reparacion">
<span><i class="bi bi-tools fs-4  text-warning fw-bold"></i> </span>
                        </asp:LinkButton>
                        <%--<asp:LinkButton runat="server" ID="LinkButton1" class="btn btn-dark"><i class="bi bi-person-circle fs-5" ></i></asp:LinkButton>--%>
                        <asp:LinkButton type="button" ID="logoutBtn" runat="server" class=" btn btn-dark text-danger fs-5" OnClientClick="if (!confirm('¿Está seguro que desea salir del sistema?')) return false;" PostBackUrl="~/login.aspx" title="Exit System">
<span class="btn-label"><i  class="bi bi-box-arrow-right"></i></span> 
                        </asp:LinkButton>
                    </div>
                    <div class="navbar-nav mx-auto">
                        <a class="nav-link text-danger fw-bold" href="#" title="">SCRAP MAIN</a>
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
        <section class="container mt-3 mx-auto" runat="server" id="divInfo" visible="false">
            <div class="row row-cols-1 row-cols-md-3 g-4 ">
                <div class="col">
                    <div class="card border-primary ">
                        <%--<img src="./resources/images/FG.png" class="card-img-top" alt="..." />--%>
                        <div class="card-header bg-primary text-center text-white fw-bold">WORKORDER</div>
                        <div class="card-body text-center">
                            <%--<asp:Label ID="Label4" runat="server" Text="WO: " CssClass=" text-dark fs-3 fw-bold"></asp:Label>--%>
                            <asp:Label ID="txtWorkOrder" runat="server" CssClass=" text-primary fs-6 fw-bold mt-0"></asp:Label><br />
                            <asp:Label CssClass="fs-6" ID="dataModel" runat="server"></asp:Label><br />
                            <asp:Label CssClass="fs-6" runat="server" ID="dataQtyWO"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="card border-success ">
                        <%--<img src="./resources/images/FG.png" class="card-img-top" alt="..." />--%>
                        <div class="card-header bg-success text-center text-white fw-bold ">FINISH GOOD</div>
                        <div class="card-body  text-center ">
                            <%--<asp:Label ID="Label4" runat="server" Text="acumulado  " CssClass=" text-body-secondary text-center"></asp:Label><br />--%>
                            <asp:Label ID="Label5" runat="server" Text="Total:  " CssClass=" fs-4 fw-bold"></asp:Label>
                            <asp:Label ID="dataAcumWO" runat="server" CssClass=" text-success fs-4 fw-bold"></asp:Label><br />
                            <asp:Label CssClass="fs-4 fw-bold " ID="Label7" runat="server" Text="Día: "></asp:Label>
                            <asp:Label CssClass="text-primary fs-4 fw-bold" runat="server" ID="dataAcumDia"></asp:Label><br />
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="card border-danger ">
                        <%--<img src="./resources/images/FG.png" class="card-img-top" alt="..." />--%>
                        <div class="card-header bg-danger text-center text-white fw-bold ">BACK LOG</div>
                        <div class="card-body mb-0 text-center">
                            <asp:Label ID="Label9" runat="server" Text="Reparación: " CssClass=" fs-4 fw-bold"></asp:Label>
                            <asp:Label ID="dataQtyRepair" runat="server" CssClass=" text-warning fs-4 fw-bold"></asp:Label><br />
                            <asp:Label CssClass=" fs-4 fw-bold " ID="Label10" runat="server" Text="Scrap: "></asp:Label>
                            <asp:Label CssClass="text-danger fs-4 fw-bold" runat="server" ID="dataQtyScrap"></asp:Label><br />
                            <%--<asp:Label CssClass="fs-4 fw-bold" runat="server" Text-="Scrap Dia:" ID="labelscrap"></asp:Label><br />
                            <asp:Label CssClass="fs-4 text-danger fw-bold" runat="server" ID="dataAcumDiaScrap" Text="adsfvsd"></asp:Label>--%>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <div class="container ">
            <div class="row g-0">
                <div class="card border-danger mt-5">
                    <div class="card-header bg-danger text-center text-white fw-bold fs-4 " runat="server" visible="true">REGISTRAR SCRAP</div>
                    <div class="card-body  text-center m-0 p-0" runat="server">
                        <div class="input-field rounded-4 text-center mt-4" id="QR" runat="server" visible="true">
                            <span class="bi bi-trash3-fill p-2 text-danger"></span>
                            <asp:TextBox ID="txtQRMain" runat="server" type="text" AutoPostBack="true" CssClass="form-control fs-2 text-center" placeholder="Escanee QR" OnTextChanged="txtQRMain_TextChanged" AutoCompleteType="Disabled"></asp:TextBox>
                            <asp:LinkButton CssClass="text-danger" ID="LinkButton1" runat="server" Visible="true" OnClick="btnReset_Click"><span class="bi bi-arrow-repeat p-2"></span></asp:LinkButton>
                        </div>
                        <div class="row g-4 mx-2" runat="server" id="divScrap" visible="false">
                        <label class="text-start text-body-secondary "> Ingrese la siguiente información requerida para mandar la unidad a scrap</label>
                            <div class="col-md-4 form-floating">
                                <asp:DropDownList runat="server" ID="ddlScrap" class="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlScrap_SelectedIndexChanged" OnTextChanged="ddlScrap_TextChanged">
                                    <asp:ListItem>Seleccione una opcion</asp:ListItem>
                                    <asp:ListItem Value="BOT    " Text="BOT "></asp:ListItem>
                                    <asp:ListItem Value="TOP    " Text="TOP "></asp:ListItem>
                                    <asp:ListItem Value="Completa   " Text="Completa "></asp:ListItem>
                                    <asp:ListItem Value="Depanelizado   " Text="Depanelizado "></asp:ListItem>
                                    <asp:ListItem Value="Depanelizado - BOT   " Text="Depanelizado - BOT "></asp:ListItem>
                                    <asp:ListItem Value="Depanelizado - TOP   " Text="Depanelizado - TOP "></asp:ListItem>
                                </asp:DropDownList>
                                <label for="floatingSelect" class="text-danger mx-2">Detalle de SCRAP</label>
                                <asp:RequiredFieldValidator CssClass="text-danger fw-bold mx-2" InitialValue="Seleccione una opcion" Font-Size="Small" SetFocusOnError="true" ErrorMessage="Seleccione una opción" ValidationGroup="fields" ControlToValidate="ddlScrap" runat="server" />
                            </div>
                            <div class=" col-md-8 form-floating ">
                                <asp:TextBox runat="server" class="form-control" AutoCompleteType="Disabled" placeholder="Agregue comentarios u observaciones aquí..." ID="comments"></asp:TextBox>
                                <label runat="server" class="mx-2" for="comments">Si es necesario agregue comentarios</label>
                            </div>
                        </div>
                        <%--<div class="form-group col-md-3">
                                <asp:Label runat="server" CssClass="fw-bold  " for="ddlSide">Lado </asp:Label>
                                <asp:DropDownList runat="server" ID="ddlSide" class="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlSide_SelectedIndexChanged" OnTextChanged="ddlSide_TextChanged">
                                    <asp:ListItem>Seleccione Lado</asp:ListItem>
                                    <asp:ListItem Value="BOT       " Text="BOT "></asp:ListItem>
                                    <asp:ListItem Value="TOP       " Text="TOP "></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator CssClass="text-danger fw-bold mx-2 " Font-Size="Small" InitialValue="Seleccione Lado" SetFocusOnError="true" ErrorMessage="Selecciona lado" ValidationGroup="fields" ControlToValidate="ddlSide" runat="server" />
                            </div>--%>
                    </div>
                    <div class="form-group mt-0 p-3 text-center">
                        <%--<asp:LinkButton ID="NewBtn" ValidationGroup="fields" runat="server" OnClick="NewBtn_Click" CssClass=" btn btn-primary " Visible="false"><i class="bi bi-plus-circle"></i> Agregar Falla</asp:LinkButton>--%>
                        <%--<asp:LinkButton ID="SaveBtn" ValidationGroup="fields" runat="server" CssClass=" btn btn-success" ToolTip="Finalizar" Visible="false" OnClick="SaveBtn_Click"><i class="bi bi-floppy2-fill"></i> Guardar cambios</asp:LinkButton>--%>
                        <asp:LinkButton ID="ScrapBtn" runat="server" CssClass=" btn btn-danger " Visible="false" OnClick="ScrapBtn_Click"><span runat="server"   class="bi bi-trash3-fill"></span> INGRESAR A SCRAP </asp:LinkButton>
                        <%--<asp:LinkButton ID="CancelBtn" runat="server" CssClass="  btn btn-warning " Visible="true" OnClick="CancelBtn_Click"><i class="bi bi-input-cursor-text"></i> Cancelar</asp:LinkButton>--%>
                        <asp:LinkButton CssClass="btn btn-dark fw-bold" ID="btnReset2" runat="server" Visible="false" OnClick="btnReset_Click" OnClientClick="if (!confirm('¿Está segur@ de que desea buscar otra unidad?')) return false;"><span class="bi bi-arrow-repeat fw-bold"></span>  Buscar otra unidad? </asp:LinkButton>
                    </div>
                </div>
                <div class="card-footer bg-outline-dark text-center mt-2 ">
                    <asp:Label ID="dataQRSN" runat="server" Text="" CssClass="fs-5 text-primary" Style="text-transform: uppercase;"></asp:Label>
                </div>
            </div>
        </div>
        </div>
        <%-- alerta --%>
        <div runat="server" id="alert" visible="false" class="" role="alert">
            <span id="AlertIcon" runat="server" class=" me-2" role="img"></span>
            <asp:Label runat="server" CssClass="fw-bold " ID="alertText" Text="">

            </asp:Label>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </form>
    <div id="res2" visible="true" runat="server">
        <asp:Label Text="" ID="res" Visible="true" CssClass="font-weight-bold" runat="server"></asp:Label><br />
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
