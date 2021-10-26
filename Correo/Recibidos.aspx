<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Recibidos.aspx.cs" Inherits="Correo.Recibidos" %>
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
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:ButtonField ButtonType="Image" ImageUrl="~/delete-16.png" Text="ELIMINAR" CommandName="BTeliminar" />
                <asp:CheckBoxField HeaderText="SELECT" Text="SELECT" ValidateRequestMode="Enabled" />
                <asp:ButtonField ButtonType="Image" ImageUrl="~/outline-star-16.png" Text="Favoritos" CommandName="BTfavoritos" />
                <asp:ButtonField ButtonType="Image" CommandName="BTver" ImageUrl="~/eye-16 (1).png" Text="VER" />
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
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    </div>
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" style="display: none;" aria-hidden="true">
  
      <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Nuevo correo</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        </div>
          <div class="mb-3">
            <label for="recipient-name" class="col-form-label">Destinatario:</label>
			  <asp:TextBox ID="TextBoxdestinatario" class="form-control" runat="server"></asp:TextBox>
          </div>
			 <div class="mb-3">
            <label for="recipient-name" class="col-form-label">Asunto:</label>
				  <asp:TextBox ID="TextBoxasunto" class="form-control" runat="server"></asp:TextBox>
          </div>
          <div class="mb-3">
            <label for="message-text" class="col-form-label">Mensaje:</label>
            <asp:TextBox ID="TextBoxmensaje" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
          </div>
      
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
          <asp:Button ID="ButtonEnviar" CssClass="btn btn-primary" runat="server" Text="Enviar" />
      </div>
    </div>
  </div>
          </div>
</asp:Content>
