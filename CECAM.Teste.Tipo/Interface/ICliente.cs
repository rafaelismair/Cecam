
namespace CECAM.Teste.Tipo.Interface
{
    public interface ICliente
    {
        int ID { get; set; }
        string RazaoSocial { get; set; }
        string NomeFantasia { get; set; }
        string CNPJ { get; set; }
        bool ExisteIndicacao { get; set; }
        bool ExisteContato { get; set; }

    }
}
