using System;
using System.Collections.Generic;
using System.Text;
using OutbackX.Mobile.Models;

namespace OutbackX.Mobile.Services
{
    public interface IUsuarioService : IService<Usuario>
    {
        bool Login(string email, string senha);
        Usuario GetByEmail(string email);
    }
}
