<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportFG.aspx.cs" Inherits="FinishGoodSMT.ReportFG" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es-mx">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" title="Finish Good SMT - MENU" />
    <link href="./resources/images/inventronics icon.ico" rel="shortcut icon" />
    <link rel="stylesheet" href="Resources/CSS/styles.css" />
    <link rel="stylesheet" href="Resources/CSS/site.css" />
    <link rel="stylesheet" href="Resources/CSS/calendar.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />


    <script src="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>
    <title>Dashboard Finish Good - SMT</title>
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
                        <asp:LinkButton runat="server" CssClass=" btn btn-dark " ID="LinkButton3" PostBackUrl="~/scanwo.aspx" Text="Regresar" title="Menu - Finish good SMT">
    <span><i class="bi bi-chevron-left fs-5"></i> </span>
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnHome" class=" btn btn-dark" title="Inicio -  Homepage" PostBackUrl="~/menu.aspx" Text="Home">
    <span><i class="bi bi-house-fill fs-5"></i> </span>
                        </asp:LinkButton>
                        <asp:LinkButton type="button" ID="logoutBtn" runat="server" class=" btn btn-dark text-danger fs-5" OnClientClick="if (!confirm('¿Está seguro que desea salir del sistema?')) return false;" PostBackUrl="~/login.aspx" title="Exit System">
<span class="btn-label"><i  class="bi bi-box-arrow-right"></i></span> 
                        </asp:LinkButton>
                    </div>
                    <div class="navbar-nav mx-auto">
                        <a class="nav-link text-white fw-bold text-success" href="#" title="">DASHBOARD FINISH GOOD </a>
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



        <section class="container mt-3  mx-auto ">
            <div class=" form-group row">
                <div class="form-group col-md-4">
                    <div class='date' id="datetimepicker6">
                        <asp:Label runat="server" Text="Desde" CssClass="fw-bold"></asp:Label>
                        <asp:TextBox runat="server" ID="fromDate" TextMode="DateTimeLocal" class="form-control" />
                        <%--<span class="input-group-addon">
                                <span class="bi bi-calendar-date"></span>
                            </span>--%>
                    </div>
                </div>
                <div class="form-group col-md-4">
                    <div class=' date' id="datetimepicker7">
                        <asp:Label runat="server" Text="Hasta" CssClass="fw-bold"></asp:Label>
                        <asp:TextBox runat="server" ID="toDate" TextMode="DateTimeLocal" class="form-control" />
                        <%-- <span class="input-group-addon">
                                <span class="bi bi-calendar-date"></span>
                            </span>--%>
                    </div>
                </div>

                <div class="form-group col-md-4">
                    <div class=' date' id="search">

                        <span class="input-group-addon">
                            <span class="bi bi-search"></span>
                        </span>
                        <asp:Button runat="server" ID="TextBox1" OnClick="TextBox1_Click" class="btn btn-primary" Text="Buscar" />
                    </div>
                </div>

            </div>
            <div class="form-group mb-3 ">
                <hr />
                <h4 style="text-align: center;" class="">DATA FILTER</h4>
                <div class="input-group ">
                    <asp:LinkButton ID="CancelBtn" Visible="false" CssClass=" btn btn-danger fw-bold" runat="server" OnClick="CancelBtn_Click" Text="" ToolTip="Cancel query"><i class="bi bi-x-lg"></i> </asp:LinkButton>
                    <asp:LinkButton ID="QueryBtn" Visible="false" CssClass="btn btn-dark fw-bold " OnClick="QueryBtn_Click" runat="server" ToolTip="Click to enable query"><i runat="server" class="fa fa-search-plus"></i></asp:LinkButton>
                    <asp:TextBox ID="filterText" CssClass="form-control filter" Enabled="false" TextMode="Search" AutoPostBack="true" OnTextChanged="filterText_TextChanged" runat="server" class="form-control" placeholder="Search by WorkOrder or Model"></asp:TextBox>
                    <asp:LinkButton ID="SearchBtn" Visible="false" CssClass=" btn btn-dark fw-bold" OnClick="SearchBtn_Click" runat="server" Text="" ToolTip="Search"><i class="bi bi-search"></i></asp:LinkButton>
                    <asp:LinkButton ID="RefreshBtn" Visible="false" CssClass=" btn btn-primary fw-bold" runat="server" OnClick="RefreshBtn_Click" Text="" ToolTip="Refresh table"><i class="bi bi-arrow-clockwise"></i></asp:LinkButton>
                </div>
            </div>
            <script type="text/javascript">
                $(function () {
                    $('#datetimepicker6').datetimepicker();
                    $('#datetimepicker7').datetimepicker({
                        useCurrent: false //Important! See issue #1075
                    });
                    $("#datetimepicker6").on("dp.change", function (e) {
                        $('#datetimepicker7').data("DateTimePicker").minDate(e.date);
                    });
                    $("#datetimepicker7").on("dp.change", function (e) {
                        $('#datetimepicker6').data("DateTimePicker").maxDate(e.date);
                    });
                });
            </script>
            <%--<div id="divInfo" visible="false" class="row row-cols-1 row-cols-md-4 g-2 mt-3" runat="server">
                <div class="col">
                    <div class=" card border-primary g-0">
                        <div class="card-header bg-primary border-0 text-center text-white fw-bold">WORKORDER</div>
                        <div class="card-body ">
                            <div class="input-group mx-auto">
                                <asp:Label ID="Label6" runat="server" CssClass="form-control text-primary fs-5 border-0 fw-bold" Text="M5107-24040008"></asp:Label>
                                <asp:Label ID="Label8" runat="server" CssClass=" fs-6  fw-bold  border-0 bg-white text-center mx-auto input-group-text" Text="1680 PCS" Style=""></asp:Label>

                            </div>
                            <asp:Label ID="Label1" runat="server" CssClass="  fs-6 fw-bold form-control border-0" Text="MX1EUM150S210DG-00000C"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="card border-success ">
                        <div class=" card-header bg-success text-center text-white fw-bold">FINISH GOOD</div>
                        <div class="card-body  ">
                            <div class=" input-group text-end">
                                <asp:Label ID="dataAcumWO" runat="server" CssClass=" text-success text-start fs-3 fw-bold form-control border-0" Text=""></asp:Label>
                                <span class=" fs-4  text-success bi bi-cpu-fill border-0"></span>
                                <br />
                            </div>
                            <asp:Label ID="Label2" runat="server" Text="Acumulado total" CssClass="text-body-secondary fs-6 "></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="card border-warning ">
                        <div class="card-header bg-warning text-center text-white fw-bold ">REPARACIÓN</div>
                        <div class="card-body ">
                            <div class="input-group text-end">
                                <asp:Label ID="dataQtyRepair" runat="server" CssClass="text-start form-control text-warning fs-3 border-0 fw-bold"></asp:Label>
                                <span class=" fs-3  text-warning  border-0"><i class="bi bi-tools"></i></span>

                            </div>
                            <asp:Label ID="Label3" runat="server" Text="Unidades por reparar" CssClass=" fs-6  text-body-secondary "></asp:Label>

                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="card border-danger ">
                        <div class="card-header bg-danger text-center text-white fw-bold ">SCRAP</div>
                        <div class="card-body ">

                            <div class="input-group text-end">
                                <asp:Label CssClass="text-start text-danger fs-3  form-control border-0 fw-bold" runat="server" ID="dataQtyScrap"></asp:Label>
                                <span class=" fs-3  text-danger border-0"><i class="bi bi-trash3-fill "></i></span>

                            </div>
                            <asp:Label CssClass=" fs-6 text-body-secondary " ID="Label7" runat="server" Text="Unidades scrappeadas"></asp:Label>

                        </div>
                    </div>
                </div>
            </div>--%>
            <div class="form-row mt-3">
                <div class="rounded table-responsive ">
                    <asp:GridView runat="server" ID="myTable" OnRowDataBound="myTable_RowDataBound" HeaderStyle-HorizontalAlign="Center" OnPageIndexChanging="myTable_PageIndexChanging" OnSelectedIndexChanged="myTable_SelectedIndexChanged" CssClass="table  table-hover table-bordered " ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" BorderStyle="None">
                        <%--DataSourceID="SqlDataSource3"--%>
                        <HeaderStyle CssClass="table-dark" />

                        <EmptyDataTemplate>
                            <div class="empty-state">
                                <div class="empty-state__content">
                                    <div class="empty-state__icon">
                                        <img src="./Resources/images/skull.png" alt="...">
                                    </div>
                                    <div class="empty-state__message">No records has been added yet.</div>
                                    <div class="empty-state__help">
                                        Add a new record by simpley clicking the below button.
                                    </div>

                                </div>
                            </div>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="WorkOrder" HeaderText="WorkOrder" ReadOnly="True" SortExpression="WorkOrder" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="FG" HeaderText="FinishGood" SortExpression="FinishGood" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-success fw-bold" />
                            <asp:BoundField DataField="MR" HeaderText="Repair" SortExpression="Repair" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-warning fw-bold" />
                            <asp:BoundField DataField="SC" HeaderText="Scrap" SortExpression="Scrap" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-danger fw-bold" />

                        </Columns>
                        <%--<asp:ButtonField ButtonType="<asp:SqlDataSource runat="server" ID="SqlDataSource3"></asp:SqlDataSource>Image" Text="Edit" ImageUrl="./Resources/images/icons/pencil.png" CommandName="Editar" HeaderText="Edit" ControlStyle-CssClass="btn btn-warning btn-sm" ItemStyle-Width="5%" />--%>
                        <%--<asp:ButtonField ButtonType="Image" ImageUrl="./Resources/images/icons/trash.png" Text="Delete" CommandName="ComDelete" HeaderText="Eliminar" ControlStyle-CssClass="btn btn-danger btn-sm" ItemStyle-Width="5%" />--%>
                        <PagerStyle CssClass="GridPager" />
                    </asp:GridView>
                    <%--<asp:SqlDataSource runat="server" ID="SqlDataSource3"></asp:SqlDataSource>--%>
                </div>
                <asp:LinkButton CssClass="btn btn-dark fw-bold" ID="ExportBtn" runat="server" Visible="false">
<span class="bi bi-printer-fill" aria-hidden="true"></span> &nbsp;Exportar
                </asp:LinkButton>
            </div>
        </section>

        <%-- alerta --%>
        <div runat="server" id="alert" visible="false" class="" role="alert">
            <span id="AlertIcon" runat="server" class=" me-2 " role="img"></span>
            <asp:Label runat="server" CssClass="fw-bold " ID="alertText" Text=""></asp:Label>
            <button type="button" class="btn-close " data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>

</body>
</html>
