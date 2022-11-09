using CECAM.Teste.Tipo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CECAM.Teste.Dado
{
    public class Cliente : Base
    {
        public ICliente Incluir(ICliente obj)
        {


            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = Incluir();

                sqlCommand.Parameters.Add("@RazaoSocial", SqlDbType.VarChar).Value = obj.RazaoSocial;

                if (!string.IsNullOrEmpty(obj.NomeFantasia))
                    sqlCommand.Parameters.Add("@NomeFantasia", SqlDbType.VarChar).Value = obj.NomeFantasia;
                else
                    sqlCommand.Parameters.Add("@NomeFantasia", SqlDbType.VarChar).Value = DBNull.Value;

                sqlCommand.Parameters.Add("@CNPJ", SqlDbType.VarChar).Value = obj.CNPJ;
                sqlCommand.Parameters.Add("@ExisteIndicacao", SqlDbType.VarChar).Value = obj.ExisteIndicacao;
                sqlCommand.Parameters.Add("@ExisteContato", SqlDbType.VarChar).Value = obj.ExisteContato;

                using (SqlConnection sqlConnection = new SqlConnection(ConsultarStringConexao()))
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }

               
            }

            return obj;
        }

        public T Consultar<T>() where T : ICliente, new()
        {
            T obj = default(T);

            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "select * from Cliente";

                using (SqlConnection sqlConnection = new SqlConnection(ConsultarStringConexao()))
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    if (dr.Read())
                    {
                        obj = CarregarTipo<T>(dr);
                    }
                }
            }
            return obj;
        }


        private string Incluir()
        {
            string toReturn;

            toReturn = @"INSERT INTO [Cliente]
                                       ([RazaoSocial]
                                       ,[NomeFantasia]
                                       ,[CNPJ]
                                       ,[ExisteIndicacao]
                                       ,[ExisteContato])
                                 VALUES
                                       (@RazaoSocial
                                       , @NomeFantasia
                                       , @CNPJ
                                       , @ExisteIndicacao
                                       , @ExisteContato)";

            return toReturn;
        }

        public DataSet Listar(string filtro)
        {
            DataSet toReturn = null;


            if (string.IsNullOrEmpty(filtro))
                filtro = "NULL";
            else
            {
                filtro = $"'{filtro.Replace(".", "").Replace("/", "")}'";
            }

            #region sql 
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

            #endregion


            var x = new SqlConnection(ConsultarStringConexao());
            x.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, x);
            toReturn = new DataSet();
            da.Fill(toReturn);
            return toReturn;


        }
    }
}
