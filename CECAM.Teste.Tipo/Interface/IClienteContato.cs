

namespace CECAM.Teste.Tipo.Interface
{
    public interface IClienteContato
    {
        int ID { get; set; }

        int IDCliente { get; set; }

        int IDTipoContato { get; set; }

        string Contato { get; set; }

    }
}
