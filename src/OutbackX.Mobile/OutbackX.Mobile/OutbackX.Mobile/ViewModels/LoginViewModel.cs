using OutbackX.Mobile.Services;
using OutbackX.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OutbackX.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string email;
        private string senha;
        private readonly IUsuarioService usuarioService;

        public LoginViewModel()
        {
            this.usuarioService = DependencyService.Get<IUsuarioService>();
            this.LoginCommand = new Command(this.OnLoginClicked);
            this.CreateAccountCommand = new Command(this.OnCreateCommandClicked);
        }

        public string Email
        {
            get => this.email;
            set => this.SetProperty(ref this.email, value);
        }

        public string Senha
        {
            get => this.senha;
            set => this.SetProperty(ref this.senha, value);
        }

        public Command LoginCommand { get; }
        public Command CreateAccountCommand { get; }

        private async void OnCreateCommandClicked()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NovoUsuarioPage());
        }

        private void OnLoginClicked(object obj)
        {
            if (this.usuarioService.Login(this.email, this.senha))
            {
                var usuario = this.usuarioService.GetByEmail(this.email);
                Application.Current.MainPage = new AppShell(usuario);
            }
            else
            {
                this.Message = "Email e/ou senha inválidos";
            }
        }
    }
}
