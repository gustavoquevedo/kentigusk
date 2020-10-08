using Gusker.Business.Dto.DefaultPage;
using System;
using System.Collections.Generic;

namespace Gusker.Business.Repository.DefaultPage
{
    public interface IDefaultPageRepository : IRepository
    {
        DefaultPageDto GetPage(Guid guid);
        IEnumerable<DefaultPageDto> GetPages();
    }
}