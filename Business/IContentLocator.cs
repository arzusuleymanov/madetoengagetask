using System.Collections.Generic;
using EPiServer.Core;
using MadeToEngageTasks.Models.Pages;

namespace MadeToEngageTasks.Business
{
    public interface IContentLocator
    {
        IEnumerable<PageData> FindPagesByPageType(PageReference pageLink, bool recursive, int pageTypeId);
        IEnumerable<T> GetAll<T>(ContentReference rootLink) where T : PageData;
        IEnumerable<ContactPage> GetContactPages();
        IEnumerable<EventPage> GetEventPages(ContentReference parent);
    }
}