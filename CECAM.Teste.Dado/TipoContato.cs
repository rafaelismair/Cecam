using CECAM.Teste.Tipo.Interface;
using System.Data;
using System.Data.SqlClient;

namespace CECAM.Teste.Dado
{
    public class TipoContato : Base
    {
        public T Consultar<T>() where T : ITipoContato, new()
        {
            T obj = default(T);

            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "select * from TipoContato";

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
    }
}
