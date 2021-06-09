using OutbackX.Mobile.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OutbackX.Mobile.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
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
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = new Estabelecimento();
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
