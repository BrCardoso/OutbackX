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
    public partial class NewEstabelecimentoPage : ContentPage
    {
        public NewEstabelecimentoPage()
        {
            this.InitializeComponent();
            BindingContext = App.GetViewModel<NovoEstabelecimentoViewModel>();
        }
    }
}