using CMS.DocumentEngine.Types.Gusker;
using Gusker.Business.Dto.Navigation;
using Gusker.Business.Services.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gusker.Business.Repository.Navigation
{
    public class NavigationRepository : BaseRepository, INavigationRepository
    {
        private const string TopNavigationCodeName = "Top";
        private const string MainNavigationCodeName = "Main";

        private readonly string[] _menuItemColumns =
        {
            "Label", "LinkUrl", "OpenInNewTab", "NodeParentID", "NodeOrder"
        };

        private Func<NavigationMenuItemSecondLevel, LinkDto> menuItemSecondLevelDtoSelect => item => new LinkDto()
        {
            Text = item.Label,
            Url = item.LinkUrl.ToLower(),
            OpenInNewTab = item.OpenInNewTab
        };

        public NavigationRepository(
            IDocumentQueryService documentQueryService
            ) : base(documentQueryService)
        {
        }

        /// <summary>
        /// One-level navigation menu
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LinkDto> GetTopNavigation()
        {
            var menu = new List<LinkDto>();

            var section = DocumentQueryService
                .GetDocuments<NavigationMenuSection>()
                .WhereEquals("MenuName", TopNavigationCodeName)
                .FirstOrDefault();

            if (section != null)
            {
                var links = DocumentQueryService
                    .GetDocuments<NavigationMenuItemFirstLevel>()
                    .AddColumns(_menuItemColumns)
                    .OrderBy("NodeOrder")
                    .Where(item1st => item1st.Parent.NodeGUID == section.NodeGUID);

                menu.AddRange(
                    links.Select(item => new LinkDto
                    {
                        Text = item.Label,
                        Url = item.LinkUrl,
                        OpenInNewTab = item.OpenInNewTab
                    }).ToList());
            }
            return menu;
        }

        /// <summary>
        /// Two-level navigation menu
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LinkMenuDto> GetMainNavigation()
        {
            var section = DocumentQueryService
                .GetDocuments<NavigationMenuSection>()
                .WhereEquals("MenuName", MainNavigationCodeName)
                .FirstOrDefault();

            var firstLevel = DocumentQueryService
                .GetDocuments<NavigationMenuItemFirstLevel>()
                .AddColumns(_menuItemColumns)
                .OrderBy("NodeOrder")
                .Where(item1st => item1st.Parent.NodeGUID == section.NodeGUID)
                .ToList();

            var secondLevel = DocumentQueryService
                .GetDocuments<NavigationMenuItemSecondLevel>()
                .AddColumns(_menuItemColumns)
                .OrderBy("NodeOrder")
                .ToList();

            return firstLevel.Select(item1st => new LinkMenuDto
            {
                Parent = new LinkDto
                {
                    Text = item1st.Label,
                    Url = item1st.LinkUrl.ToLower(),
                    OpenInNewTab = item1st.OpenInNewTab
                },
                MenuItems = secondLevel
                    .Where(item2nd => item2nd.Parent.NodeGUID == item1st.NodeGUID)
                    .Select(menuItemSecondLevelDtoSelect)
            });
        }
    }
}
