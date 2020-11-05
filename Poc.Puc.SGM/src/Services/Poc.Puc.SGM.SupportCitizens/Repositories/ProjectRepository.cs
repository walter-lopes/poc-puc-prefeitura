using Poc.Puc.SGM.SupportCitizens.Domain;

namespace Poc.Puc.SGM.SupportCitizens.Repositories
{
    public class ProjectRepository : BaseRepository<Project>
    {
        public ProjectRepository(IDbContext context, string collection) : base(context, collection)
        {

        }
    }
}
