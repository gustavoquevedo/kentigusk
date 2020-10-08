using Gusker.Business.Services.Query;

namespace Gusker.Business.Repository
{
    public abstract class BaseRepository : IRepository
    {
        protected IDocumentQueryService DocumentQueryService { get; }

        protected BaseRepository(
            IDocumentQueryService documentQueryService)
        {
            DocumentQueryService = documentQueryService;
        }
    }
}
