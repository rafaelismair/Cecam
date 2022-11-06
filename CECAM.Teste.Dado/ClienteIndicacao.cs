using CECAM.Teste.Tipo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECAM.Teste.Dado
{
    public class ClienteIndicacao : Base
    {
        public IClienteIndicacao Incluir(IClienteIndicacao obj)
        {


            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = Incluir();

                sqlCommand.Parameters.Add("@IDCliente", SqlDbType.VarChar).Value = obj.IDCliente;
                sqlCommand.Parameters.Add("@IDClienteIndicacao", SqlDbType.VarChar).Value = obj.IDClienteIndicacao;
           
                using (SqlConnection sqlConnection = new SqlConnection(ConsultarStringConexao()))
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }

                obj.ID = Convert.ToInt32(sqlCommand.Parameters["@ID"].Value);

            }

            return obj;
        }

        public T Consultar<T>() where T : ITipoContato, new()
        {
            T obj = default(T);

            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "select * from ClienteIndicacao";

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

            toReturn = @"INSERT INTO [ClienteIndicacao]
                               ([IDCliente]
                               ,[IDClienteIndicacao])
                         VALUES
                               (@IDCliente
                               ,@IDClienteIndicacao);";

            return toReturn + this.ComandoRetornaIdentity();
        }

    }
}
