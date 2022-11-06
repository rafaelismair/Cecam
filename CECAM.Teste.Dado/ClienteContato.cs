using CECAM.Teste.Tipo.Interface;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CECAM.Teste.Dado
{
    public class ClienteContato : Base
    {
        public IClienteContato Incluir(IClienteContato obj)
        {


            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = Incluir();

                sqlCommand.Parameters.Add("@IDCliente", SqlDbType.VarChar).Value = obj.IDCliente;
                sqlCommand.Parameters.Add("@IDTipoCliente", SqlDbType.VarChar).Value = obj.IDTipoContato;
                sqlCommand.Parameters.Add("@Contato", SqlDbType.VarChar).Value = obj.Contato;

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

        public T Consultar<T>() where T : IClienteContato, new()
        {
            T obj = default(T);

            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "select * from ClienteContato";

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

            toReturn = @"INSERT INTO [ClienteContato]
                               ([IDCliente]
                               ,[IDTipoCliente]
                               ,[Contato])
                         VALUES
                                (@IDCliente
                               ,@IDTipoCliente
                               ,@Contato);";

            return toReturn + this.ComandoRetornaIdentity();
        }
    }
}
