using OutbackX.Mobile.Models;
using OutbackX.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OutbackX.Mobile.ViewModels
{
    public class NovoEstabelecimentoViewModel : BaseViewModel
    {
        private string unidade;
        private string endereco;
        private int numero;
        private string complemento;
        private string bairro;
        private string cidade;
        private string estado;
        private string cep;
        private readonly IEstabelecimentoService estabelecimentoService;

        public NovoEstabelecimentoViewModel(IEstabelecimentoService estabelecimentoService)
        {
            this.SaveCommand = new Command(this.OnSave, this.ValidateSave);
            this.CancelCommand = new Command(this.OnCancel);
            this.PropertyChanged += (_, __) => this.SaveCommand.ChangeCanExecute();

            this.estabelecimentoService = estabelecimentoService;
        }

        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(this.Unidade)
                && !string.IsNullOrWhiteSpace(Endereco)
                && (this.numero > 0)
                && !string.IsNullOrWhiteSpace(Bairro)
                && !string.IsNullOrWhiteSpace(Cidade)
                && !string.IsNullOrWhiteSpace(Estado)
                && !string.IsNullOrWhiteSpace(CEP);
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
            get => cep;
            set => SetProperty(ref cep, value);
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
            var newEstab = new Estabelecimento()
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

            this.estabelecimentoService.Insert(newEstab);

            MessagingCenter.Send(string.Empty, "NEW_ESTAB");
            await Shell.Current.GoToAsync("..");
        }
    }
}
