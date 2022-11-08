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


            string sql = @"declare @filtro varchar(100) = NULL;

SELECT C.id,
       C.razaosocial,
       C.nomefantasia,
       Substring(C.cnpj, 1, 2) + '.'
       + Substring(C.cnpj, 3, 3) + '.'
       + Substring(C.cnpj, 6, 3) + '/'
       + Substring(C.cnpj, 9, 4) + '-'
       + Substring(C.cnpj, 13, 2) AS cnpj,
       C.existeindicacao,
       C.existecontato,
       CASE
         WHEN C.existecontato = 0 THEN NULL
         ELSE(SELECT ' ' + TP.descricao + ': ' + CC.contato
               FROM   clientecontato CC
                      INNER JOIN tipocontato TP
                              ON TP.id = CC.idtipocliente
               WHERE  CC.idcliente = C.id
               FOR xml path(''))
       END AS contatos,
       CASE
         WHEN C.existeindicacao = 0 THEN NULL
         ELSE(SELECT CAux.razaosocial
               FROM   clienteindicacao CI
                      INNER JOIN cliente CAux
                              ON CI.idclienteindicacao = CAux.id
               WHERE  CI.idcliente = C.id)
       END AS indicacao
FROM   cliente AS C
where(@filtro is not null AND(c.CNPJ like '%' + @filtro + '%' OR c.RazaoSocial like '%' + @filtro + '%')
or @filtro is null and ID is not null)";

            string constr = "Server=RIF\\SQLEXPRESS;Database=CECAM;Trusted_Connection=True;";
            var x = new SqlConnection(constr);
            x.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, x);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDados.DataSource = ds;
            grdDados.DataBind();

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
             
            string constr = "Server=RIF\\SQLEXPRESS;Database=CECAM;Trusted_Connection=True;";
            var x = new SqlConnection(constr);
            x.Open();

            string filtro = "NULL";

            if (!string.IsNullOrEmpty(txt1.Text))
                filtro = "'" + txt1.Text.Replace('.', ' ').Replace('/', ' ') + "'";

            string sql = $@"declare @filtro varchar(100) = {filtro};

SELECT C.id,
       C.razaosocial,
       C.nomefantasia,
       Substring(C.cnpj, 1, 2) + '.'
       + Substring(C.cnpj, 3, 3) + '.'
       + Substring(C.cnpj, 6, 3) + '/'
       + Substring(C.cnpj, 9, 4) + '-'
       + Substring(C.cnpj, 13, 2) AS cnpj,
       C.existeindicacao,
       C.existecontato,
       CASE
         WHEN C.existecontato = 0 THEN NULL
         ELSE(SELECT ' ' + TP.descricao + ': ' + CC.contato
               FROM   clientecontato CC
                      INNER JOIN tipocontato TP
                              ON TP.id = CC.idtipocliente
               WHERE  CC.idcliente = C.id
               FOR xml path(''))
       END AS contatos,
       CASE
         WHEN C.existeindicacao = 0 THEN NULL
         ELSE(SELECT CAux.razaosocial
               FROM   clienteindicacao CI
                      INNER JOIN cliente CAux
                              ON CI.idclienteindicacao = CAux.id
               WHERE  CI.idcliente = C.id)
       END AS indicacao
FROM   cliente AS C
where(@filtro is not null AND(c.CNPJ like '%' + @filtro + '%' OR c.RazaoSocial like '%' + @filtro + '%')
or @filtro is null and ID is not null)";

            SqlDataAdapter da = new SqlDataAdapter(sql, x);  
        
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDados.DataSource = ds;
            grdDados.DataBind();
        }
    }
}