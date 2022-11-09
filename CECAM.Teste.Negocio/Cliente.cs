using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Transactions;

namespace CECAM.Teste.Negocio
{
    public class Cliente
    {
        Dado.Cliente _dadoCliente = null;

        private Dado.Cliente DadoCliente
        {
            get
            {
                if (_dadoCliente == null)
                    _dadoCliente = new Dado.Cliente();
                return _dadoCliente;
            }

        }

        public void Incluir(Tipo.Interface.ICliente cliente, 
            Tipo.Interface.IClienteContato clienteContato,
            Tipo.Interface.IClienteIndicacao clienteIndicacao)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                if (!Util.ValidarCNPJ.IsCnpj(cliente.CNPJ))
                {
                    throw new Exception("CNPJ Inválido");
                }


                DadoCliente.Incluir(cliente);

            }
        }

        public DataSet Listar(string filtro = null)
        {
            return this.DadoCliente.Listar(filtro);
        }
    }
}
