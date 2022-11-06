﻿using CECAM.Teste.Tipo.Interface;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CECAM.Teste.Dado
{
    public class Cliente : Base
    {
        public ICliente Incluir (ICliente obj)
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
                sqlCommand.Parameters.Add("@ExisteContato", SqlDbType.VarChar).Value = obj.ExisteContato ;

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

            toReturn =  @"INSERT INTO [Cliente]
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

            return toReturn + this.ComandoRetornaIdentity();
        }



    }
}
