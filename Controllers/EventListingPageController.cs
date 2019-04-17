using System.Linq;
using System.Web.Mvc;
using EPiServer.Web.Mvc;
using MadeToEngageTasks.Business;
using MadeToEngageTasks.Models.Pages;
using MadeToEngageTasks.Models.ViewModels;

namespace MadeToEngageTasks.Controllers
{
    public class EventListingPageController : PageController<EventListingPage>
    {
        private readonly IContentLocator _contentLocator;

        public EventListingPageController(IContentLocator contentLocator)
        {
            _contentLocator = contentLocator;
        }

        public ActionResult Index(EventListingPage currentPage)
        {
            var model = new EventListingViewModel(currentPage);           
            model.AllEvents = _contentLocator.GetEventPages(currentPage.ContentLink).ToList();

            return View(model);
        }
    }
}