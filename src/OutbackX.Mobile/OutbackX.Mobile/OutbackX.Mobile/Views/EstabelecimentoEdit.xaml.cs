﻿using OutbackX.Mobile.Models;
using OutbackX.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OutbackX.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EstabelecimentoEdit : ContentPage
    {
        public EstabelecimentoEdit(Estabelecimento selectedItem)
        {
            this.InitializeComponent();
            var viewModel  = App.GetViewModel<EstabelecimentoEditViewModel>();
            viewModel.Item = selectedItem;
            this.BindingContext = viewModel;
        }
    }
}