<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainRepair.aspx.cs" EnableEventValidation="true" Inherits="FinishGoodSMT.MainRepair" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" title="Finish Good SMT - SCAN WO" />
    <link href="./resources/images/inventronics icon.ico" rel="shortcut icon" />
    <link rel="stylesheet" href="Resources/CSS/styles.css" />
    <link rel="stylesheet" href="Resources/CSS/site.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <title>Reparación Main - SMT</title>
</head>
<body class="">
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
                        <asp:LinkButton runat="server" class="btn btn-dark " ID="LinkButton3" PostBackUrl="~/Menu.aspx" Text="Regresar" title="Menu - Finish good SMT">
                <span><i class="bi bi-chevron-left fs-5"></i> </span>
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnFG" class=" btn btn-dark border border-0" PostBackUrl="~/scanwo.aspx" OnClientClick="if (!confirm('¿Está seguro que desea ir a FINISH GOOD?')) return false;" Text="Módulo FINISH GOOD" ToolTip="Módulo FINISH GOOD">
<span><i class="bi bi-cpu-fill fs-4  text-success fw-bold"></i> </span>
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnRepirValidation" class=" btn btn-dark border border-0" PostBackUrl="~/RepairValidation.aspx" OnClientClick="if (!confirm('¿Está seguro que desea ir a VALIDACION DE REPARACIONES?')) return false;" Text="Módulo validacion reparacion" ToolTip="Módulo validacion reparacion">
<span><i class="bi bi-check2-circle fs-4  text-primary fw-bold"></i> </span>
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnScrap" class=" btn btn-dark border border-0" OnClientClick="if (!confirm('¿Está seguro que desea ir al módulo de SCRAP?')) return false;" PostBackUrl="~/ScanWoScrap.aspx" Text="Módulo Scrap" ToolTip="Módulo Scrap">
<span><i class="bi bi-trash3-fill   text-danger fw-bold"></i> </span>
                        </asp:LinkButton>
                        <asp:LinkButton type="button" ID="logoutBtn" runat="server" class=" btn btn-dark text-danger fs-5" OnClientClick="if (!confirm('¿Está seguro que desea salir del sistema?')) return false;" PostBackUrl="~/login.aspx" title="Exit System">
            <span class="btn-label"><i  class="bi bi-box-arrow-right"></i></span> 
                        </asp:LinkButton>
                    </div>
                    <div class="navbar-nav mx-auto">
                        <a class="nav-link text-warning fw-bold" href="#" title="">REGISTRO DE FALLAS</a>
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

        <section class="container mt-3  mx-auto " runat="server" id="divInfo" visible="false">
            <div class="row row-cols-1 row-cols-md-3 g-4 ">
                <div class="col">
                    <div class="card border-primary ">
                        <div class="card-header bg-primary text-center text-white fw-bold">WORKORDER</div>
                        <div class="card-body text-center">
                            <asp:Label ID="txtWorkOrder" runat="server" CssClass=" text-primary fs-6 fw-bold mt-0"></asp:Label><br />
                            <asp:Label CssClass="fs-6" ID="dataModel" runat="server"></asp:Label><br />
                            <asp:Label CssClass="fs-6" runat="server" ID="dataQtyWO"></asp:Label>
                            <asp:Label CssClass="fs-6" runat="server" ID="dataPieces"></asp:Label>
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
                            <asp:Label ID="dataQtyRepair" runat="server" CssClass=" text-warning fs-4 fw-bold"></asp:Label><br />
                            <asp:Label CssClass=" fs-4 fw-bold " ID="Label7" runat="server" Text="Scrap: "></asp:Label>
                            <asp:Label CssClass="text-danger fs-4 fw-bold" runat="server" ID="dataQtyScrap"></asp:Label><br />
                            <asp:Label CssClass="fs-6 visually-hidden" runat="server" ID="Label1" Text="adsfvsd"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <div class="container ">
            <div class="row g-0">
                <div class="card  mt-2 p-0" runat="server">
                    <div class="card-header  text-center bg-dark text-white fw-bold fs-4  " runat="server" visible="true">REGISTRAR REPARACIÓN</div>
                    <div class="card-body  text-center m-0 p-0" runat="server">
                        <div class="input-field rounded-4 text-center mt-5" id="QR" runat="server" visible="true">
                            <span class="bi bi-qr-code text-warning p-2"></span>
                            <asp:TextBox ID="txtQRMain" runat="server" type="text" AutoPostBack="true" CssClass="form-control fs-2 text-center" placeholder="Escanee QR" OnTextChanged="txtQRMain_TextChanged" AutoCompleteType="Disabled"></asp:TextBox>
                            <asp:LinkButton CssClass="text-warning" ID="LinkButton1" runat="server" Visible="true" OnClick="btnReset_Click"><span class="bi bi-arrow-repeat"></span></asp:LinkButton>
                        </div>
                        <div class="form-group row mt-4  px-2 text-start  " id="divFailure" runat="server" visible="false">
                            <div class="form-group col-md-0">
                                <asp:Label runat="server" CssClass="fw-bold" Visible="false">ID</asp:Label>
                                <asp:TextBox runat="server" AutoCompleteType="Disabled" class="form-control" ID="inputID" Visible="false"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6">
                                <asp:Label CssClass="fw-bold " runat="server">Modo de Falla</asp:Label>
                                <asp:DropDownList runat="server" ID="ddlFailureMode" class="form-select">
                                    <asp:ListItem>Seleccione modo de falla</asp:ListItem>
                                    <asp:ListItem Value="SMT01 - Corto de soldadura" Text="SMT01 - Corto de soldadura"></asp:ListItem>
                                    <asp:ListItem Value="SMT02 - Bolas de soldadura " Text="SMT02 - Bolas de soldadura "></asp:ListItem>
                                    <asp:ListItem Value="SMT03 - Soldadura Fria" Text="SMT03 - Soldadura Fria"></asp:ListItem>
                                    <asp:ListItem Value="SMT04 - Picos de SoldaduraOP" Text="SMT04 - Picos de Soldadura"></asp:ListItem>
                                    <asp:ListItem Value="SMT05 - Pin sin soldar " Text="SMT05 - Pin sin soldar "></asp:ListItem>
                                    <asp:ListItem Value="SMT06 - Componente Desplazado" Text="SMT06 - Componente Desplazado"></asp:ListItem>
                                    <asp:ListItem Value="SMT07 - Insuficiencia de Soldadura" Text="SMT07 - Insuficiencia de Soldadura"></asp:ListItem>
                                    <asp:ListItem Value="SMT08 - Exceso de soldadura" Text="SMT08 - Exceso de soldadura"></asp:ListItem>
                                    <asp:ListItem Value="SMT09 - Efecto Lapida" Text="SMT09 - Efecto Lapida"></asp:ListItem>
                                    <asp:ListItem Value="SMT10 - Componente Invertido" Text="SMT10 - Componente Invertido"></asp:ListItem>
                                    <asp:ListItem Value="SMT11 - Componentes faltantes " Text="SMT11 - Componentes faltantes "></asp:ListItem>
                                    <asp:ListItem Value="SMT12 - Componente Equivocado" Text="SMT12 - Componente Equivocado"></asp:ListItem>
                                    <asp:ListItem Value="SMT13 - Componente extra" Text="SMT13 - Componente extra"></asp:ListItem>
                                    <asp:ListItem Value="SMT14 - Componente dañado" Text="SMT14 - Componente dañado"></asp:ListItem>
                                    <asp:ListItem Value="SMT15 - Componente quemado" Text="SMT15 - Componente quemado"></asp:ListItem>
                                    <asp:ListItem Value="SMT16 - Tarjeta dañada" Text="SMT16 - Tarjeta dañada"></asp:ListItem>
                                    <asp:ListItem Value="SMT17 - Tarjeta quemada" Text="SMT17 - Tarjeta quemada"></asp:ListItem>
                                    <asp:ListItem Value="SMT18 - Tarjeta Barrida" Text="SMT18 - Tarjeta Barrida"></asp:ListItem>
                                    <asp:ListItem Value="SMT19 - Efecto almohada" Text="SMT19 - Efecto almohada"></asp:ListItem>
                                    <asp:ListItem Value="SMT20 - Componente mal colocado" Text="SMT20 - Componente mal colocado"></asp:ListItem>
                                    <asp:ListItem Value="SMT21 - Conector elevado" Text="SMT21 - Conector elevado"></asp:ListItem>
                                    <asp:ListItem Value="SMT22 - Componente arrancado" Text="SMT22 - Componente arrancado"></asp:ListItem>
                                    <asp:ListItem Value="SMT23 - Conector faltante" Text="SMT23 - Conector faltante"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator CssClass="text-danger fw-bold mx-2" InitialValue="Seleccione modo de falla" Font-Size="Small" SetFocusOnError="true" ErrorMessage="Seleccione un modo de falla" ValidationGroup="fields" ControlToValidate="ddlFailureMode" runat="server" />
                            </div>
                            <div class="form-group col-md-3">
                                <asp:Label runat="server" CssClass="fw-bold  ">Localidad(es)</asp:Label>
                                <asp:TextBox runat="server" AutoCompleteType="Disabled" class="form-control" ID="inputLocation" Style="text-transform: uppercase;"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-3">
                                <asp:Label runat="server" CssClass="fw-bold  " for="ddlSide">Lado </asp:Label>
                                <asp:DropDownList runat="server" ID="ddlSide" class="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlSide_SelectedIndexChanged" OnTextChanged="ddlSide_TextChanged">
                                    <asp:ListItem>Seleccione Lado</asp:ListItem>
                                    <asp:ListItem Value="BOT       " Text="BOT "></asp:ListItem>
                                    <asp:ListItem Value="TOP       " Text="TOP "></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator CssClass="text-danger fw-bold mx-2 " Font-Size="Small" InitialValue="Seleccione Lado" SetFocusOnError="true" ErrorMessage="Selecciona lado" ValidationGroup="fields" ControlToValidate="ddlSide" runat="server" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="form-group mt-0 p-3 text-center">
                        <asp:LinkButton ID="NewBtn" ValidationGroup="fields" runat="server" OnClick="NewBtn_Click" CssClass=" btn btn-primary " Visible="false"><i class="bi bi-plus-circle"></i> Agregar Falla</asp:LinkButton>
                        <asp:LinkButton ID="SaveBtn" ValidationGroup="fields" runat="server" CssClass=" btn btn-success" ToolTip="Finalizar" Visible="false" OnClick="SaveBtn_Click"><i class="bi bi-floppy2-fill"></i> Guardar cambios</asp:LinkButton>
                        <asp:LinkButton ID="UpdateBtn" runat="server" CssClass="  btn btn-success " Visible="false"><i class="bi bi-floppy2-fill"></i> Guardar</asp:LinkButton>
                        <asp:LinkButton ID="ClearBtn" runat="server" CssClass=" btn btn-danger " Visible="false" OnClick="ClearBtn_Click"><span runat="server"   class="bi bi-input-cursor-text"></span> Cancelar </asp:LinkButton>
                        <asp:LinkButton CssClass="btn btn-dark fw-bold" ID="btnReset" runat="server" Visible="false" OnClick="btnReset_Click" OnClientClick="if (!confirm('¿Está segur@ de que desea buscar otra unidad?')) return false;"><span class="bi bi-arrow-repeat fw-bold"></span>  Buscar otra unidad? </asp:LinkButton>
                    </div>
                    <div class="form-row mt-2 p-2">
                        <div class="rounded table-responsive ">
                            <asp:GridView runat="server" ID="myTable" OnRowDataBound="myTable_RowDataBound" OnRowCommand="myTable_RowCommand" HeaderStyle-HorizontalAlign="Center" OnPageIndexChanging="myTable_PageIndexChanging" OnSelectedIndexChanged="myTable_SelectedIndexChanged" CssClass="table  table-hover table-bordered " ShowHeaderWhenEmpty="false" AutoGenerateColumns="false" DataKeyNames="WorkOrder" AllowPaging="false" BorderStyle="None" Visible="false">
                                <HeaderStyle CssClass="table-secondary" />
                                <EmptyDataTemplate>
                                    <div class="empty-state">
                                        <div class="empty-state__content">
                                            <div class="empty-state__icon">
                                                <%--<img src="./Resources/images/skull.png" alt="...">--%>
                                            </div>
                                            <div class="empty-state__message">Aún no se han agregado fallas...</div>
                                            <div class="empty-state__help">
                                            </div>
                                        </div>
                                    </div>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:ButtonField ButtonType="Image" Text="Editar" ImageUrl="./Resources/images/icons/pencil.png" CommandName="Editar" HeaderText="Edit" ControlStyle-CssClass="btn btn-warning btn-sm" ItemStyle-Width="2%" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="true" ItemStyle-Width="3%" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="FailureMode" HeaderText="FailureMode" ItemStyle-Width="15%" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                    <asp:BoundField DataField="Location" HeaderText="Location" ItemStyle-Width="6%" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                    <asp:BoundField DataField="Side" HeaderText="Side" ItemStyle-Width="4%" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                    <asp:ButtonField ButtonType="Image" ImageUrl="./Resources/images/icons/trash.png" Text="" CommandName="ComDelete" HeaderText="Eliminar" ControlStyle-CssClass="btn btn-danger btn-sm" ItemStyle-Width="2%" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" />
                                </Columns>
                                <PagerStyle CssClass="GridPager" />
                            </asp:GridView>
                        </div>
                        <asp:LinkButton CssClass="btn btn-dark fw-bold" ID="ExportBtn" runat="server" Visible="false" OnClick="ExportBtn_Click">
        <span class="bi bi-printer-fill" aria-hidden="true"></span> &nbsp;Exportar
                        </asp:LinkButton>
                    </div>
                    <div class="card-footer bg-ouline-dark text-center mt-2 ">
                        <asp:Label ID="dataQRSN" runat="server" Text="" CssClass="fs-5 text-primary" Style="text-transform: uppercase;"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <%-- alerta --%>
        <div runat="server" id="alert" visible="false" class="" role="alert">
            <span id="AlertIcon" runat="server" class=" fs-5 me-2" role="img"></span>
            <asp:Label runat="server" CssClass="fw-bold fs-5" ID="alertText" Text="">
            </asp:Label>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
