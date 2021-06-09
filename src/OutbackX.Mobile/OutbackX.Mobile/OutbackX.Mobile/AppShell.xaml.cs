using OutbackX.Mobile.Models;
using OutbackX.Mobile.ViewModels;
using OutbackX.Mobile.Views;
using Xamarin.Forms;

namespace OutbackX.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell(Usuario usuario)
        {
            this.InitializeComponent();

            this.BindingContext = new AppShellViewModel(usuario);
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
