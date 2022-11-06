using CECAM.Teste.Tipo.Interface;

namespace CECAM.Teste.Tipo.Entidade
{
    public class TipoContato : ITipoContato
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
    }
}
