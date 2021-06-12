using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutbackX.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OutbackX.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListEstabelecimentoPage : ContentPage
    {
        public ListEstabelecimentoPage()
        {
            this.InitializeComponent();
            this.BindingContext = App.GetViewModel<ListEstabelecimentoViewModel>();
        }
    }
}