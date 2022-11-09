using System;
using System.Data.SqlClient;
using System.Reflection;


namespace CECAM.Teste.Dado
{
    public class Base
    {
        private String _stringConexao = null;
        private string _comandoRetornaIdentity = null;

        protected string ConsultarStringConexao()
        {

            if (this._stringConexao == null)
            {
                _stringConexao = "Server=RIF\\SQLEXPRESS;Database=CECAM;Trusted_Connection=True;";
            }
            return _stringConexao;
        }

        protected static T CarregarTipo<T>(SqlDataReader dr)
        {

            T objItem = (T)Activator.CreateInstance(typeof(T));

            for (int i = 0; i <= dr.FieldCount - 1; i++)
            {
                PropertyInfo item = objItem.GetType().GetProperty(dr.GetName(i));

                if ((item != null))
                {
                    object value = null;

                    if (object.ReferenceEquals(dr[i], DBNull.Value))
                    {

                        switch (Type.GetTypeCode(item.PropertyType))
                        {
                            case TypeCode.Int16:
                                value = 0;
                                break;
                            case TypeCode.Int32:
                                value = 0;
                                break;
                            case TypeCode.Int64:
                                value = 0;
                                break;
                            case TypeCode.DateTime:
                                value = DateTime.MinValue;
                                break;
                            case TypeCode.String:
                                value = String.Empty;
                                break;
                            case TypeCode.Char:
                                value = System.Convert.ToChar(value.ToString()[0]);
                                break;

                            default:
                                value = null;
                                break;
                        }
                    }
                    else
                    {
                        value = dr[item.Name];
                    }

                    item.SetValue(objItem, value, null);

                }


            }

            return objItem;
        }

        protected string ComandoRetornaIdentity()
        {
            if (this._comandoRetornaIdentity == null)
            {
                _comandoRetornaIdentity = " SELECT SCOPE_IDENTITY();";
            }
            return _comandoRetornaIdentity;
        }


    }
}
