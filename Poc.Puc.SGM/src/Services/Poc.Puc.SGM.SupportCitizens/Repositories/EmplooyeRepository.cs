using Poc.Puc.SGM.SupportCitizens.Domain;

namespace Poc.Puc.SGM.SupportCitizens.Repositories
{
    public class EmplooyeRepository : BaseRepository<Funcionario>
    {
        public EmplooyeRepository(IDbContext context, string collection) : base(context, collection)
        {
        }
    }
}
