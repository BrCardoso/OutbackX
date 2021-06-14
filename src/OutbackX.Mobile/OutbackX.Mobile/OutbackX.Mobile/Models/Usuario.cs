using System.ComponentModel;
using SQLite;

namespace OutbackX.Mobile.Models
{
    public enum TipoUsuario
    {
        [Description("Adiministrador")]
        Admin,

        [Description("Comum")]
        Comum
    }

    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
