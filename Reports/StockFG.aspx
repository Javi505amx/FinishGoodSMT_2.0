<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockFG.aspx.cs" Inherits="FinishGoodSMT.Reports.WO_Tracking" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" title="Finish Good SMT - MENU" />
    <link href="../resources/images/inventronics icon.ico" rel="shortcut icon" />
    <link rel="stylesheet" href="../Resources/CSS/styles.css" />
    <link rel="stylesheet" href="../Resources/CSS/site.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <title>Finish Good - SMT WO STOCK</title>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar sticky-top navbar-expand-lg  navbar-dark bg-dark">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">
                    <img id="logo" class="navbar-brand" src="../resources/images/inv.png" title="Go back to Home" /></a>
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
                        <a class="nav-link text-white fw-bold text-success" href="#" title="">FINISH GOOD  WO STOCK</a>
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
                <div class="input-group mb-3">
                    <span class="input-group-text fw-bold">Desde</span>
                    <asp:TextBox runat="server" ID="fromDate" TextMode="DateTimeLocal" class="form-control" />
                    <span class="input-group-text fw-bold">Hasta</span>
                    <asp:TextBox runat="server" ID="toDate" TextMode="DateTimeLocal" class="form-control text-center" />
                    <asp:LinkButton runat="server" ID="btnBuscar" OnClick="btnBuscar_Click" class="btn btn-primary"><i class="bi bi-search"></i> Buscar</asp:LinkButton>
                </div>
            </div>
            <div class="form-group mb-3 ">
                <hr />
                <h4 style="text-align: center;" class="">DATA FILTER</h4>
                <div class="input-group ">
                    <asp:LinkButton ID="CancelBtn" Visible="false" CssClass=" btn btn-danger fw-bold" runat="server" OnClick="CancelBtn_Click" Text="" ToolTip="Cancel query"><i class="bi bi-x-lg"></i> </asp:LinkButton>
                    <asp:LinkButton ID="QueryBtn" Visible="true" CssClass="btn btn-dark fw-bold " OnClick="QueryBtn_Click" runat="server" ToolTip="Click to enable query"><i runat="server" class="bi bi-search"></i></asp:LinkButton>
                    <asp:TextBox ID="filterText" CssClass="form-control filter" Enabled="false" TextMode="Search" AutoPostBack="true" OnTextChanged="filterText_TextChanged" runat="server" class="form-control" placeholder="Search by WorkOrder or Model"></asp:TextBox>
                    <asp:LinkButton ID="SearchBtn" Visible="false" CssClass=" btn btn-dark fw-bold" OnClick="SearchBtn_Click" runat="server" Text="" ToolTip="Search"><i class="bi bi-search"></i></asp:LinkButton>
                    <asp:LinkButton ID="RefreshBtn" Visible="true" CssClass=" btn btn-primary fw-bold" runat="server" OnClick="RefreshBtn_Click" Text="" ToolTip="Refresh table"><i class="bi bi-arrow-clockwise"></i></asp:LinkButton>
                </div>
            </div>
            <div class="form-row mt-3">
                <div class="rounded table-responsive ">
                    <asp:GridView runat="server" ID="myTable" OnRowDataBound="myTable_RowDataBound" HeaderStyle-BackColor="#ebebeb" HeaderStyle-HorizontalAlign="Center" OnPageIndexChanging="myTable_PageIndexChanging" OnSelectedIndexChanged="myTable_SelectedIndexChanged" CssClass="table   " ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" AllowPaging="true" BorderStyle="None">
                        <%--DataSourceID="SqlDataSource3"--%>
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" CssClass="table-secondary" />
                        <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <EmptyDataTemplate>
                            <span class="placeholder col-6"></span>
                            <span class="placeholder w-75"></span>
                            <span class="placeholder" style="width: 25%;"></span>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="WorkOrder" HeaderText="WorkOrder" ReadOnly="True" SortExpression="WorkOrder" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="FG" HeaderText="FinishGood" SortExpression="FinishGood" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-success fw-bold" />
                            <asp:BoundField DataField="SC" HeaderText="Scrap" SortExpression="Scrap" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-danger fw-bold" />

                        </Columns>
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                    </asp:GridView>
                </div>
                <asp:LinkButton CssClass="btn btn-dark fw-bold" ID="ExportBtn" runat="server" Visible="true">
                        <span class="bi bi-printer-fill" aria-hidden="true"></span> &nbsp;Exportar
                </asp:LinkButton>
            </div>
            <%-- alerta --%>
            <div runat="server" id="alert" visible="false" class="d-flex align-items-center" role="alert">
                <span id="AlertIcon" runat="server" class=" flex-shrink-0 me-2 " role="img"></span>
                <asp:Label runat="server" CssClass="fw-bold " ID="alertText" Text=""></asp:Label>
                <button type="button" class="btn-close " data-bs-dismiss="alert" aria-label="Close"></button>
            </div>
        </section>
    </form>

</body>
</html>
