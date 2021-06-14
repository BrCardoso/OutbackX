using System;
using System.Collections.Generic;
using System.Text;
using OutbackX.Mobile.Config;
using OutbackX.Mobile.Models;
using SQLite;

namespace OutbackX.Mobile.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        public UsuarioService(IDbPathConfig dbPathConfig) : base(dbPathConfig)
        {

        }

        public bool Login(string email, string senha)
        {
            var resultado = base.FindWithQuery("SELECT * FROM Usuario Where Email=? AND Senha=?", email, senha);

            return resultado != null;
        }

        public Usuario GetByEmail(string email)
        {
            var resultado = base.FindWithQuery("SELECT * FROM Usuario Where Email=?", email);

            return resultado;
        }

        public override Usuario GetById(int id)
        {
            return base.FindWithQuery("SELECT * FROM Usuario Where Id=?", id);
        }
    }
}
