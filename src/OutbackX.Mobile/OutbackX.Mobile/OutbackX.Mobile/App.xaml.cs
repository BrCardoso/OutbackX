using OutbackX.Mobile.Services;
using OutbackX.Mobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OutbackX.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            this.InitializeComponent();
            DependencyService.Register<IUsuarioService, UsuarioService>();
            this.MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
