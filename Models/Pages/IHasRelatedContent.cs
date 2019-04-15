using EPiServer.Core;

namespace MadeToEngageTasks.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
