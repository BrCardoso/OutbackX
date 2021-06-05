using OutbackX.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace OutbackX.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}