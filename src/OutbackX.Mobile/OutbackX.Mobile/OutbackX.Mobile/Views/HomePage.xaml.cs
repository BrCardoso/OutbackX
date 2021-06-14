using OutbackX.Mobile.ViewModels;
using Xamarin.Forms;

namespace OutbackX.Mobile.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            this.InitializeComponent();
            this.BindingContext = App.GetViewModel<HomeViewModel>();
        }
    }
}