using CECAM.Teste.Tipo.Interface;


namespace CECAM.Teste.Tipo.Entidade
{
    public class Cliente : ICliente
    {
        public int ID { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public bool ExisteIndicacao { get; set; }
        public bool ExisteContato { get; set; }
    }
}
