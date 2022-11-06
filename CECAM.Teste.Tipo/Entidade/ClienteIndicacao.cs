using CECAM.Teste.Tipo.Interface;


namespace CECAM.Teste.Tipo.Entidade
{
    public class ClienteIndicacao : IClienteIndicacao
    {
        public int ID { get; set; }
        public int IDCliente { get; set; }
        public int IDClienteIndicacao { get; set; }
    }
}
