using CECAM.Teste.Tipo.Interface;

namespace CECAM.Teste.Tipo.Entidade
{
    public class ClienteContato : IClienteContato
    {
        public int ID { get; set; }
        public int IDCliente { get; set; }
        public int IDTipoContato { get; set; }
        public string Contato { get; set; }
    }
}
