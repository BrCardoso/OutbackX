using OutbackX.Mobile.Models;
using OutbackX.Mobile.ViewModels;
using OutbackX.Mobile.Views;
using Xamarin.Forms;

namespace OutbackX.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            this.InitializeComponent();

            this.BindingContext = new AppShellViewModel();
            Routing.RegisterRoute(nameof(ListEstabelecimentoPage), typeof(ListEstabelecimentoPage));
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewEstabelecimentoPage), typeof(NewEstabelecimentoPage));
        }

    }
}
