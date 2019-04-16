using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace MadeToEngageTasks.Models.Pages
{
    [ContentType(DisplayName = "Event Listing Page", GUID = "2b02da63-366c-41f8-8142-9edd26243909", Description = "")]
    [SiteImageUrl]
    [AvailableContentTypes(
        Availability.Specific,
        Include = new[] { typeof(EventPage) } )]
    public class EventListingPage : SitePageData
    {
        
    }
}