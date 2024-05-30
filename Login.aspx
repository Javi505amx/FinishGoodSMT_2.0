<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FinishGoodSMT.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" data-bs-theme="">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Resources/Images/inventronics icon.ico" rel="icon" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="Resources/CSS/login-media.css" />
    <link rel="stylesheet" href="Resources/CSS/login.css" />
    <script src="Resources/JS/script.js"></script>
    <title>Finish Good SMT</title>

</head>
<body>
    <form runat="server" >
        <div class="container-fluid d-flex align-items-center align-content-center bg-body-tertiary ">
                    <div  class=" container text-center p-5 mt-0 rounded w-50 bg-body-tertiary">
                        <%-- alerta --%>
                        <div runat="server" id="alert" visible="false" class="" role="alert">
                            <span id="AlertIcon" runat="server" class=" me-2" role="img"></span>
                            <asp:Label runat="server" CssClass="fw-bold" ID="alertText" Text=""></asp:Label>
                            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                        </div>

                        <img class="me-2" id="logo" src="Resources/images/inv.png" />
                        <h2 class=" text-center  fw-bold mt-0 mb-2 ">FINISH GOOD</h2>
                        <div class="form-group py-2 mb-4 ">
                            <div class="input-field ">
                                <span class="bi bi-person-circle p-2"></span>
                                <asp:Label ID="lblUser" Text="Usuario"  Font-Bold="true" CssClass="text-white" runat="server" Visible="false"></asp:Label>
                                <asp:TextBox ID="txtUsuario" CssClass="text-center form-control bg-body-tertiary" runat="server" type="text" Visible="true" placeholder="Usuario" AutoCompleteType="Disabled" ToolTip="Escanear Usuario" OnTextChanged="txtUsuario_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group py-0">
                            <div class="input-field">
                                <span class="bi bi-lock-fill p-2"></span>

                                <%--<asp:Label id="lblPassword"  Font-Bold="true" CssClass="text-white" Text="Contraseña"  runat="server"></asp:Label>--%>
                                <asp:TextBox ID="txtPassword" type="password" CssClass="text-center form-control bg-body-tertiary" runat="server" placeholder="Contraseña" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox><br />
                            </div>
                        </div>
                        <asp:Label ID="labelwrong" CssClass="text-danger" runat="server" Visible="true"  > </asp:Label>
                        <asp:Button ID="Button1" CssClass="btn btn-primary w-100 mt-4" Text="Iniciar Sesión" runat="server" OnClick="Button1_Click" />
                    </div>
        </div>
    </form>
     <footer class=" text-center text-lg-start fixed-bottom">
     <!-- Copyright -->
     <div class="text-center p-3 bg-body-tertiary">
         <a class="text-body fw-medium text-decoration-none" href="#"><%:DateTime.Now.Year%>  &copy; Diseñado para MMC Inventronics</a>
     </div>
     <!-- Copyright -->
 </footer>


</body>
</html>
