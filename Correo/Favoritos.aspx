﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Correo.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

  <style type="text/css">
        .auto-style5 {
            height: auto;
            width: auto;
            margin-left: 150px;
            margin-right: 25px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="auto-style5">
        <asp:GridView ID="GridDestacados" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"  OnRowDataBound="GridDestacados_RowDataBound" OnRowCommand="GridDestacados_RowCommand" AutoGenerateColumns="False">
          <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="codigo" HeaderText="Codigo" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="HeaderChk"    runat="server"    />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="selector" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField ButtonType="Image" ImageUrl="~/delete-16.png" Text="ELIMINAR" CommandName="BTeliminar" />
                <asp:ButtonField ButtonType="Image" ImageUrl="~/estrella.png" Text="Favoritos" CommandName="BTfavoritos" />
                <asp:BoundField DataField="emisor" HeaderText="Emisor" />
                <asp:BoundField DataField="asunto" HeaderText="Asunto" />
                <asp:ButtonField CommandName="BTver" DataTextField="cuerpo" HeaderText="Mensaje" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />


        </asp:GridView> 
        </div>
</asp:Content>
