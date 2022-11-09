using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CECAM.Teste.UI
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Negocio.Cliente obj = new Negocio.Cliente();
            grdDados.DataSource = obj.Listar();
            grdDados.DataBind();
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            Negocio.Cliente obj = new Negocio.Cliente();
            grdDados.DataSource = obj.Listar(txt1.Text);
            grdDados.DataBind();
        }
    }
}