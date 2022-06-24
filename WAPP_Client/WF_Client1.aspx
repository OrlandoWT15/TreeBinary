
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WF_Client1.aspx.cs" Inherits="WAPP_Client.WF_Client1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minium-scale=1.0"/>
    <title>INE</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css" integrity="sha384-zCbKRCUGaJDkqS1kPbPd7TveP5iyJE0EjAuZQTgFLD2ylzuqKfdKlfG/eSrtxUkn" crossorigin="anonymous"/>


    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

</head>
<body>
        <div class="container-fluid">
            <form id="form1" runat="server">
                <div>
                    <div class="container-fluid">
                        <div class="row m-2 p-0">
                            <!--Apartado de acción de la aplicación-->
                            <div class="col-sm-4 p-1" style="background-color:dimgray">
                                <!--Sección de agregar INE-->
                                <section class="p-1 shadow-sm" style="background-color:slategray; ">
                                    <div class="form-inline p-1" style="background-color:#865858;">
                                        <asp:Label ID="lblInsert" runat="server" Text="agregar ine" CssClass="text-uppercase text-sm-left"></asp:Label>
                                        <asp:ImageButton ID="ibtnInsert" runat="server" style="width:25px; height:25px; margin-left:auto; display:block;" OnClick="ibtnInsert_Click"/>
                                    </div>
                                    <div class="p-1" style="background-color:lightgray;">
                                        <div>
                                            <asp:Label ID="lblCurp" runat="server" Text="curp" CssClass="text-uppercase text-sm-left m-2"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtCurp" runat="server" CssClass="form-control w-75"></asp:TextBox>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblNombre" runat="server" Text="nombre" CssClass="text-uppercase text-sm-left m-2"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control w-75"></asp:TextBox>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblDomicilio" runat="server" Text="domicilio" CssClass="text-uppercase text-sm-left m-2"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtDomicilio" runat="server" CssClass="form-control w-75"></asp:TextBox>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblEstado" runat="server" Text="estado" CssClass="text-uppercase text-sm-left m-2"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtEstado" runat="server" CssClass="form-control w-75"></asp:TextBox>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblMunicipio" runat="server" Text="municipio" CssClass="text-uppercase text-sm-left m-2"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtMunicipio" runat="server" CssClass="form-control w-75"></asp:TextBox>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblSeccion" runat="server" Text="seccion" CssClass="text-uppercase text-sm-left m-2"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtSeccion" runat="server" CssClass="form-control w-75"></asp:TextBox>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblVigencia" runat="server" Text="vigencia" CssClass="text-uppercase text-sm-left m-2"></asp:Label>
                                        </div>
                                        <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                                            <asp:TextBox ID="txtVigencia" runat="server" CssClass="form-control w-75" Enabled="False"></asp:TextBox>
                                            <asp:ImageButton ID="imgCalendario" runat="server" Visible="True" ImageUrl="~/Resource/285670_calendar_icon.png" Width="40px" Height="40px" OnClick="imgCalendario_Click"/>
                                            <asp:Calendar ID="clVigencia" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" OnSelectionChanged="clVigencia_SelectionChanged" Width="330px">
                                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                                                <DayStyle BackColor="#CCCCCC" />
                                                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                                                <OtherMonthDayStyle ForeColor="#999999" />
                                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                                <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                                                <TodayDayStyle BackColor="#999999" ForeColor="White" />
                                            </asp:Calendar>
                                        </div>
                                    </div>
                                </section>
                                <!--Sección de Busqueda-->
                                <section class="p-1 shadow-sm" style="background-color:slategray;">
                                    <div class="form-inline p-1" style="background-color:#865858;">
                                        <asp:Label ID="lblSearch" runat="server" Text="buscar ine" CssClass="text-uppercase text-sm-left"></asp:Label>
                                        <asp:ImageButton ID="ibtnSearch" runat="server" style="width:25px; height:25px; margin-left:auto; display:block;" OnClick="ibtnSearch_Click" />
                                    </div>
                                    <div class="p-1" style="background-color:lightgray;">
                                        <div>
                                            <asp:Label ID="lblbuscar" runat="server" Text="Buscar" CssClass="text-uppercase text-sm-left m-2"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblBCurp" runat="server" Text="Introdusca la CURP" CssClass="text-uppercase text-sm-left m-2"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control w-75" AutoPostBack="True" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                </section>
                                <!--Sección de Eliminar-->
                                <section class="p-1 shadow-sm" style="background-color:slategray;">
                                    <div class="form-inline p-1" style="background-color:#865858;">
                                        <asp:Label ID="lbldelete" runat="server" Text="eliminar una ine" CssClass="text-uppercase text-sm-left"></asp:Label>
                                        <asp:ImageButton ID="ibtnDelete" runat="server"  style="width:25px; height:25px; margin-left:auto; display:block;" OnClick="ibtnDelete_Click"/>
                                    </div>
                                    <div class="p-1" style="background-color:lightgray;">
                                        <div>
                                            <asp:Label ID="lbldiposte" runat="server" Text="Eliminar" CssClass="text-uppercase text-sm-left m-2"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Label ID="lbleliminar" runat="server" Text="Introduce una CURP" CssClass="text-uppercase text-sm-left m-2"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtDelete" runat="server" CssClass="form-control w-75" AutoPostBack="True" OnTextChanged="txtDelete_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                </section>
                            </div>
                            <!--Apartado de graficación-->
                            <div class="col-sm-4 p-2 " style="background-color:lightgray"> 
                                <div>
                                    <asp:ListBox ID="lbsArea" runat="server"  Height="400px" CssClass="form-control w-75" OnSelectedIndexChanged="lbsArea_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                                </div>
                                <div>
                                    <asp:ListBox ID="lbsArea2" runat="server" Height="350px" CssClass="form-control w-75"></asp:ListBox>
                                </div>
                            </div>
                            <div class="col-sm-4 p-2 " style="background-color:lightgray">
                               <asp:Image ID="imgGraphs" runat="server" ImageUrl="~/Resource/no-disponible.jpg" Width="500" Height="750" CssClass="float-lg-right" />
                            </div>                        
                        </div>
                        <div class="row">
                            <!--Apartado de acciones-->
                            <div class="col-12">
                                <div class="m-4 p-2 form-inline rounded-lg" style="background-color:lightgray;">
                                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-outline-success" OnClick="btnAgregar_Click" />
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-outline-info m-1" OnClick="btnBuscar_Click"/>
                                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger m-1" OnClick="btnEliminar_Click" />
                                    <asp:Button ID="btnInorder" runat="server" Text="In-Orden"  CssClass="btn btn-outline-secondary m-1" OnClick="btnInorder_Click"/>
                                    <asp:Button ID="btnPreorder" runat="server" Text="Pre-Orden"  CssClass="btn btn-outline-secondary m-1" OnClick="btnPreorder_Click"/>
                                    <asp:Button ID="btnPostOrden" runat="server" Text="Post-Orden"  CssClass="btn btn-outline-secondary m-1" OnClick="btnPostOrden_Click"/>
                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-outline-dark m-1" OnClick="btnGuardar_Click" />
                                    <asp:Button ID="btnRecuperar" runat="server" Text="Recupera" CssClass="btn btn-outline-dark m-1" OnClick="btnRecuperar_Click"/>
                                </div>
                            </div>
                            
                        </div>
                        <div class="row m-2 p-0">
                            <asp:GridView ID="gvXML" runat="server"
                                CssClass="table table-striped"
                                AlternatingRowStyle-BackColor="DarkGray"
                                ></asp:GridView>
                        </div>
                    </div>
                </div>
            </form>
        </div>
   

<script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/js/bootstrap.min.js" integrity="sha384-VHvPCCyXqtD5DqJeNxl2dtTyhF78xXNXdkwX1CZeRusQfRKp+tA7hAShOK/B/fQ2" crossorigin="anonymous"></script>
</body>
</html>
