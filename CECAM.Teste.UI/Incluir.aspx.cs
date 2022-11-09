using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CECAM.Teste.UI
{
    public partial class Incluir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {

            Tipo.Entidade.Cliente incluir = new Tipo.Entidade.Cliente();

            incluir.CNPJ = txtCnpj.Text;
            incluir.ExisteContato = false;
            incluir.ExisteIndicacao = false;
            incluir.RazaoSocial = txtRazaoSocial.Text;
            incluir.NomeFantasia = txtNomeFantasia.Text;

            Negocio.Cliente obj = new Negocio.Cliente();
            try
            {
                obj.Incluir(incluir, null, null);
                lblmsg.Text = "Registro Cadastrado com sucesso!";
            }
            catch(Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
           
        }

    }
}