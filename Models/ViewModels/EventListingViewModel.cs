using MadeToEngageTasks.Models.Pages;
using System.Collections.Generic;

namespace MadeToEngageTasks.Models.ViewModels
{
    public class EventListingViewModel : PageViewModel<EventListingPage>
    {
        public EventListingViewModel(EventListingPage currentPage) : base(currentPage)
        {
        }      

        public IEnumerable<EventPage> AllEvents { get; set; }
    }
}
