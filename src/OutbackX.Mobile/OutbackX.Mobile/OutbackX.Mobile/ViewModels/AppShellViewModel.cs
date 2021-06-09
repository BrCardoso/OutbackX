using System;
using System.Collections.Generic;
using System.Text;
using OutbackX.Mobile.Models;

namespace OutbackX.Mobile.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        private readonly Usuario usuario;
        public AppShellViewModel(Usuario usuario)
        {
            this.usuario = usuario;
        }

        public bool IsAdmin => this.usuario.TipoUsuario == TipoUsuario.Admin;
    }
}
