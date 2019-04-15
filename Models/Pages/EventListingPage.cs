using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace MadeToEngageTasks.Models.Pages
{
    [ContentType(DisplayName = "EventListingPage", GUID = "2b02da63-366c-41f8-8142-9edd26243909", Description = "")]
    [AvailableContentTypes(
        Availability.Specific,
        Include = new[] { typeof(EventPage) } )]
    public class EventListingPage : SitePageData
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Main body",
                    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual XhtmlString MainBody { get; set; }
         */
    }
}