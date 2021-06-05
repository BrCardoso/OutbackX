using OutbackX.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OutbackX.Mobile.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string unidade;
        private string endereco;
        private int numero;
        private string complemento;
        private string bairro;
        private string cidade;
        private string estado;
        private string cCEP;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(Unidade)
                && !String.IsNullOrWhiteSpace(Endereco)
                && (numero > 0)
                && !String.IsNullOrWhiteSpace(Bairro)
                && !String.IsNullOrWhiteSpace(Cidade)
                && !String.IsNullOrWhiteSpace(Estado)
                && !String.IsNullOrWhiteSpace(CEP);
        }

        public string Unidade
        {
            get => unidade;
            set => SetProperty(ref unidade, value);
        }
        public string Endereco
        {
            get => endereco;
            set => SetProperty(ref endereco, value);
        }
        public int Numero
        {
            get => numero;
            set => SetProperty(ref numero, value);
        }
        public string Complemento
        {
            get => complemento;
            set => SetProperty(ref complemento, value);
        }
        public string Bairro
        {
            get => bairro;
            set => SetProperty(ref bairro, value);
        }
        public string Cidade
        {
            get => cidade;
            set => SetProperty(ref cidade, value);
        }
        public string Estado
        {
            get => estado;
            set => SetProperty(ref estado, value);
        }
        public string CEP
        {
            get => cCEP;
            set => SetProperty(ref cCEP, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Unidade = Unidade,
                Endereco = Endereco,
                Numero = Numero,
                Complemento = Complemento,
                Bairro = Bairro,
                Cidade = Cidade,
                Estado = Estado,
                CEP = CEP
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
