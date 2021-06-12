using OutbackX.Mobile.Config;
using OutbackX.Mobile.Models;

namespace OutbackX.Mobile.Services
{
    public class EstabelecimentoService : BaseService<Estabelecimento>, IEstabelecimentoService
    {
        public EstabelecimentoService(IDbPathConfig dbPathConfig) : base(dbPathConfig)
        {
        }

        public override Estabelecimento GetById(int id)
        {
            return FindWithQuery("SELECT * FROM Estabelecimento Where Id=?", id);
        }

        public void AtualizarCapacidade(int id, Capacidade capacidadeAtual)
        {
            var estab = this.GetById(id);
            estab.CapacidadeAtual = capacidadeAtual;
            this.Update(estab);
        }
    }
}
