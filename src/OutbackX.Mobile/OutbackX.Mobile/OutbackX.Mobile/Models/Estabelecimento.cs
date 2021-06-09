using SQLite;

namespace OutbackX.Mobile.Models
{
    public class Estabelecimento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Unidade { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
    }
}