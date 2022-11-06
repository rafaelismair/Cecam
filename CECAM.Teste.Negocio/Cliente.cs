using System;
using System.Collections.Generic;
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

        public void Incluir()
        {
            using (TransactionScope scope = new TransactionScope())
            {

            }
        }
    }
}
