<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="Lista.aspx.cs" Inherits="CECAM.Teste.UI.Lista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>  
            <asp:TextBox runat="server" ID="txt1" placeholder="Nome ou CNPJ "></asp:TextBox>  
            <asp:Button ID="btn1" runat="server" Text="Submit" OnClick="btn1_Click" />  
        </div>  
  <br />
        <div>
            <asp:GridView ID="grdDados" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="razaosocial" HeaderText="Razão social" />
                    <asp:BoundField DataField="contatos" HeaderText="Contatos" />
                    <asp:BoundField DataField="cnpj" HeaderText="CNPJ" />
                    <asp:BoundField DataField="indicacao" HeaderText="Indicação" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
