using OutbackX.Mobile.Models;
using OutbackX.Mobile.Services;
using OutbackX.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OutbackX.Mobile.ViewModels
{
    public class ListEstabelecimentoViewModel : BaseViewModel
    {
        private Estabelecimento _selectedItem;

        private readonly IEstabelecimentoService estabelecimentoService;
        public ListEstabelecimentoViewModel(IEstabelecimentoService estabelecimentoService)
        {
            this.estabelecimentoService = estabelecimentoService;
            this.Items = new ObservableCollection<Estabelecimento>();
            this.AddItemCommand = new Command(OnAddItem);
            this.ItemTapped = new Command<Estabelecimento>(OnItemSelected);
            this.LoadItems();

            MessagingCenter.Subscribe(this, "EDIT_ESTAB", (string _) => this.LoadItems());
        }

        public ObservableCollection<Estabelecimento> Items { get; }
        public Command AddItemCommand { get; }
        public Command<Estabelecimento> ItemTapped { get; }

        private void LoadItems()
        {

            IsBusy = true;

            try
            {
                this.Items.Clear();
                this.estabelecimentoService.GetAll()
                    .ToList()
                    .ForEach(item => this.Items.Add(item));

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Estabelecimento SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private void OnAddItem(object obj)
        {
            Shell.Current.GoToAsync(nameof(NewEstabelecimentoPage));
        }

        async void OnItemSelected(Estabelecimento item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(EstabeleceimentoDetalhePage)}?{nameof(EstabelecimentoDetailViewModel.ItemId)}={item.Id}", true);
        }
    }
}