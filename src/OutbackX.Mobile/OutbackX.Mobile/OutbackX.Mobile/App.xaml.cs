using Microsoft.Extensions.DependencyInjection;
using OutbackX.Mobile.Services;
using OutbackX.Mobile.ViewModels;
using OutbackX.Mobile.Views;
using System;
using Xamarin.Forms;

namespace OutbackX.Mobile
{
    public partial class App : Application
    {

        public App(Action<IServiceCollection> addPlatformServices = null)
        {
            this.InitializeComponent();
            this.SetupServices(addPlatformServices);
            this.MainPage = new AppShell();
        }

        private void SetupServices(Action<IServiceCollection> addPlatformServices)
        {
            var services = new ServiceCollection();
            addPlatformServices?.Invoke(services);

            services.AddTransient<NovoEstabelecimentoViewModel>();
            services.AddTransient<EstabelecimentoDetailViewModel>();
            services.AddTransient<ListEstabelecimentoViewModel>();
            services.AddTransient<NovoUsuarioViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddSingleton<IEstabelecimentoService, EstabelecimentoService>();
            services.AddSingleton<IUsuarioService, UsuarioService>();

            ServiceProvider = services.BuildServiceProvider();
        }

        protected static IServiceProvider ServiceProvider { get; set; }

        public static BaseViewModel GetViewModel<TViewModel>() where TViewModel : BaseViewModel
            => ServiceProvider.GetService<TViewModel>();

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
