using System;
using System.Diagnostics;
using OutbackX.Mobile.Models;
using OutbackX.Mobile.Services;
using OutbackX.Mobile.Views;
using Xamarin.Forms;

namespace OutbackX.Mobile.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class EstabelecimentoDetailViewModel : BaseViewModel
    {
        private int itemId;
        private string unidade;
        private string endereco;
        private int numero;
        private string complemento;
        private string bairro;
        private string cidade;
        private string estado;
        private string cCEP;
        private readonly IEstabelecimentoService estabelecimentoService;
        private Command deleteCommand;
        private Command editCommand;

        public EstabelecimentoDetailViewModel(IEstabelecimentoService estabelecimentoService)
        {
            this.estabelecimentoService = estabelecimentoService;
        }

        public int Id { get; set; }
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
        public int ItemId
        {
            get => itemId;
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public Command EditCommand => this.editCommand = this.editCommand ?? new Command(async () =>
        {
            await Shell.Current.GoToAsync($"{nameof(NewEstabelecimentoPage)}?ItemId={this.Id}", true);
        });

        public Command DeleteCommand => this.deleteCommand = this.deleteCommand ?? new Command(async () =>
        {
            var resp = await Application.Current.MainPage.DisplayAlert("Excluir?", "Deseja relamente excluir esse Estabelecimento?", "Sim", "Não");
            if (resp)
            {
                var item = this.estabelecimentoService.GetById(this.Id);
                this.estabelecimentoService.Delete(item);
                MessagingCenter.Send(string.Empty, "EDIT_ESTAB");
                await Shell.Current.GoToAsync("..");
            }
        });

        private void LoadItemId(int itemId)
        {
            try
            {
                var item = this.estabelecimentoService.GetById(itemId);
                Id = item.Id;
                Unidade = item.Unidade;
                Endereco = item.Endereco;
                Numero = item.Numero;
                Complemento = item.Complemento;
                Bairro = item.Bairro;
                Cidade = item.Cidade;
                Estado = item.Estado;
                CEP = item.CEP;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
