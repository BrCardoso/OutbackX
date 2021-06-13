using System;
using System.Collections.Generic;
using System.Text;
using OutbackX.Mobile.Models;

namespace OutbackX.Mobile.Services
{
    public interface IEstabelecimentoService : IService<Estabelecimento>
    {
        void AtualizarCapacidade(int id, Ocupacao ocupacao);
        IEnumerable<Estabelecimento> Search(string searchValue);
    }
}
