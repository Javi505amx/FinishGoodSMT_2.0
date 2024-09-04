<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="FinishGoodSMT.Reports.Stock" EnableEventValidation="false" %>

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
    <title>Stock SMT-  WO REPORT</title>
    <style type="text/css">
        /* Estilo para fijar el encabezado del GridView */
        .gridview-header {
            position: sticky;
            top: 0.0001px;
            z-index: 1; /* Color de fondo del encabezado */
            background-color: aquamarine !important;
        }

        /* Asegura que el GridView tenga un ancho fijo */
        .gridview-container {
            width: 100%;
            overflow-x: auto;
        }
    </style>



</head>
<body class="">
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


        <div class="container mt-3  mx-auto">
            <div class="row row-cols-lg-auto gy-3 gx-1 align-items-center mb-2">
                <div class="col-12">
                    <label for="txtStartWO" class="form-label fw-bold visually-hidden ">Start WorkOrder</label>
                    <div class="input-group">
                        <div class="input-group-text fw-bold">FROM</div>
                        <asp:TextBox ID="txtStartWO" runat="server" placeholder="Start Workorder" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-12">

                    <label for="txtEndWO" class="fw-bold form-label visually-hidden">&nbsp;&nbsp;End WorkOrder</label>
                    <div class="input-group">
                        <div class="input-group-text fw-bold">&nbsp;&nbsp; &nbsp;&nbsp;TO</div>
                        <asp:TextBox ID="txtEndWO" runat="server" CssClass="form-control" placeholder="End Workorder"></asp:TextBox>
                    </div>
                </div>
                <div class="col-6">
                    <asp:LinkButton CssClass="btn  btn-primary fw-bold form-control" ID="LinkButton1" runat="server" Visible="true" OnClick="RefreshBtn_Click">
<span class="bi bi-arrow-clockwise" aria-hidden="true"></span> &nbsp;Refresh
                    </asp:LinkButton>
                </div>
                <div class=" col-6">
                    <asp:LinkButton CssClass="btn btn-dark fw-bold form-control" ID="btnFilterData" runat="server" Visible="true" OnClick="btnFilter_Click">
    <span class="bi bi-search" aria-hidden="true"></span> &nbsp;Search
                    </asp:LinkButton>
                    <%-- <asp:Button ID="btnFilter" runat="server" Text="Filter data" OnClick="btnFilter_Click" CssClass=" bi bi-search btn  btn-dark p-2" />--%>
                    <%--  <asp:LinkButton CssClass="btn btn-primary fw-bold form-label" ID="LinkButton1" runat="server" Visible="true" OnClick="btnFilter_Click">
<span class="bi bi-search" aria-hidden="true"></span> &nbsp;Refresh
                    </asp:LinkButton>--%>
                </div>
            </div>
            <div class="rounded table table-responsive gridview-container caption-top  " style="height: 70vh; overflow-y: scroll;">
                <figure>Click on blue headers to sort(ASC, DESC)</figure>
                <asp:GridView runat="server" ID="GridView1" AllowSorting="true" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound" HeaderStyle-HorizontalAlign="Center" BorderStyle="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="table  table-hover table-striped table-responsive" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" AllowPaging="false" ShowFooter="True">
                    <%--DataSourceID="SqlDataSource3"--%>
                    <SortedAscendingCellStyle CssClass="text-danger" />
                    <HeaderStyle CssClass="table-dark" />
                    <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" CssClass="fs-6 text-body-tertiary" />
                    <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" CssClass=" fs-6 fw-bold bg-dark text-primary" ForeColor="CadetBlue" />
                    <EmptyDataTemplate>
                        <span class="placeholder col-6"></span>
                        <span class="placeholder w-75"></span>
                        <span class="placeholder" style="width: 25%;"></span>
                    </EmptyDataTemplate>
                    <Columns>
                        <%-- <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CommandArgument='<%# Eval("WorkOrder") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="WorkOrder" SortExpression="WorkOrder" AccessibleHeaderText="filter" ItemStyle-CssClass="text-body-secondary fw-bold">
                            <FooterTemplate>
                                <asp:Label ID="lblTotalWorkOrderCount" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <%# string.Format("{0:N0}", Eval("WorkOrder")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Modelo" SortExpression="Model" ItemStyle-CssClass="text-body-secondary fw-bold">
                            <FooterTemplate>
                                <asp:Label ID="lblTotalModelCount" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <%# string.Format("{0:N0}", Eval("Model")) %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Quantity">
                            <FooterTemplate>
                                <asp:Label ID="lblTotalQuantityOrdered" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <span class="text-body-secondary fw-bold">
                                    <%# string.Format("{0:N0}", Eval("QuantityOrdered")) %>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Finish Good" HeaderStyle-CssClass="  text-success">
                            <FooterTemplate>
                                <asp:Label ID="lblTotalQuantityProduced" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <span class='<%# Eval("QuantityProducedClass") %>'>
                                    <%# string.Format("{0:N0}", Eval("QuantityProduced")) %>
                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Repair" HeaderStyle-CssClass=" text-warning">
                            <FooterTemplate>
                                <asp:Label ID="lblTotalQuantityRepaired" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <span class='<%# Eval("QuantityRepairedClass") %>'>
                                    <%# string.Format("{0:N0}", Eval("QuantityRepaired")) %>
                </span>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Scrap" HeaderStyle-CssClass="text-danger">
                            <FooterTemplate>
                                <asp:Label ID="lblTotalQuantityScrap" runat="server"> </asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <span class='<%# Eval("QuantityScrapClass") %>'>
                                    <%# string.Format("{0:N0}", Eval("QuantityScrap")) %>
                </span>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="FPY">
                            <FooterTemplate>
                                <asp:Label ID="lblTotalEfficiencyRate" runat="server" CssClass="font-bold"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <span class='<%# Eval("EfficiencyRateClass") %> badge  w-100 h-100'>
                                    <%--badge rounded-pill--%>
                                    <%# string.Format("{0:0.00}%", Eval("EfficiencyRate")) %>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total">
                            <FooterTemplate>
                                <asp:Label ID="lblTotalTotalCount" runat="server" CssClass="fw-bold"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <span class='<%# Eval("TotalCountClass") %>'>
                                    <%# string.Format("{0:N0}", Eval("TotalCount")) %>
                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Difference">
                            <FooterTemplate>
                                <asp:Label ID="lblTotalDifference" runat="server" CssClass="fw-bold "></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <span class='<%# Eval("DifferenceClass") %>'>
                                    <%--<%# string.Format("{0:N0}", Eval("Difference")) %>--%>
                                    <%# Eval("Difference") != null && Convert.ToDouble(Eval("Difference")) > 0 ? 
            "+" + Eval("Difference", "{0:N0}") : 
            Eval("Difference", "{0:N0}") %>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status WO" SortExpression="WorkOrderStatus">
                            <FooterTemplate>
                                <asp:Label ID="lblTotalWorkOrderStatus" runat="server" CssClass="font-bold"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <span class='<%# Eval("StatusClass") %> badge'><%# Eval("WorkOrderStatus") %></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:LinkButton CssClass="btn btn-dark fw-bold" ID="ExportBtn" OnClick="ExportBtn_Click" runat="server" Visible="true">
               <span class="bi bi-filetype-xlsx" aria-hidden="true"></span> &nbsp;Exportar
            </asp:LinkButton>
        </div>




        <%--  <div class="modal fade" id="editModal" tabindex="-1" role="dialog" aria-labelledby="editModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="editModalLabel">Edit Work Order</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblWorkOrder" runat="server" Text=""></asp:Label>
                        <asp:TextBox ID="txtModel" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtQuantityOrdered" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtQuantityProduced" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtQuantityRepaired" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtQuantityScrap" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtEfficiencyRate" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtTotalCount" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtDifference" runat="server"></asp:TextBox>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" OnClick="btnSaveChanges_Click" />
                    </div>
                </div>
            </div>
        </div>--%>
    </form>
</body>
</html>
