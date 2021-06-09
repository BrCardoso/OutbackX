using OutbackX.Mobile.Models;
using OutbackX.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OutbackX.Mobile.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Estabelecimento Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}