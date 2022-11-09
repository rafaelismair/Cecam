<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Incluir.aspx.cs" Inherits="CECAM.Teste.UI.Incluir" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title></title>  
</head>  
<body>  
    <form id="form1" runat="server">  
    <div>  
         <p id="panel1">  
            <table>  
                <tr>  
                    <td>Razão social:</td>  
                    <td>  
                        <asp:TextBox ID="txtRazaoSocial" ValidationGroup="frmIncluir"
                            MaxLength="100" runat="server"></asp:TextBox>  
                    </td>  
                    <td>  
                        <asp:RequiredFieldValidator ID="reqRazaoSocial" ControlToValidate="txtRazaoSocial" 
                            ValidationGroup="frmIncluir" runat="server" 
                            ErrorMessage="*"></asp:RequiredFieldValidator>  
                    </td>  
                </tr>  
                <tr>  
                    <td>Nome fantasia:</td>  
                    <td>  
                        <asp:TextBox ID="txtNomeFantasia" runat="server" MaxLength="100" ValidationGroup="frmIncluir"></asp:TextBox>  
                    </td>  
                    <td>  
                        <asp:RequiredFieldValidator ID="reqNomeFantasia" ControlToValidate="txtNomeFantasia" ValidationGroup="frmIncluir" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>  
                     </td>  
                </tr>  
                <tr>  
                    <td>CNPJ:</td>  
                   <td>  
                        <asp:TextBox ID="txtCnpj" runat="server" MaxLength="14" ValidationGroup="frmIncluir"></asp:TextBox>  
                    </td>  
                    <td>  
                        <asp:RequiredFieldValidator ID="reqCNPJ" ControlToValidate="txtCnpj" ValidationGroup="frmIncluir" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>  
                     </td>  
                </tr>  
                <tr>  
                   <td>Existe Indicação:</td>  
                   <td>  
                        <input type="checkbox" id="checkIndicacao" disabled="disabled" name="checkIndicacao" value = "0"> 
                    </td>  
                    
                </tr> 
                <tr>  
                   <td>Existe Contato:</td>  
                   <td>  
                        <input type="checkbox" id="checkContato" disabled="disabled" name="checkContato" value = "0">
                    </td>  
                    
                </tr> 
                <tr>  
                    <td colspan="2" align="right">  
                        <asp:Button ID="btnSubmit" runat="server" Text="Incluir" ValidationGroup="frmIncluir" OnClick="btnadd_Click" />  
                    </td>  
                </tr>  
            </table>  
         </p>  
        
    </div>  
    </form>  
</body>  
</html> 