using EPiServer.Shell.ObjectEditing;
using EPiServer.Validation;
using MadeToEngageTasks.Models.Pages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MadeToEngageTasks.Helpers
{
    public class EventListingHelpers
    {
    }

    public enum EventStatus
    {
        Unknown, Closed
    }

    // Epi Way
    public class SpeakerSelectionAttribute : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new ISelectItem[]
            {
               new SelectItem() { Text = "Scott Allen"},
               new SelectItem() { Text = "Damien Edwards"},
               new SelectItem() { Text = "David Fowler"},
               new SelectItem() { Text = "Scott Guthrie"}
            };
        }
    }

    // Test validate speaker using own validation attribute
    public class SpecialSpeakerAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.ToString() == "Scott Allen" || value.ToString() == "Damien Edwards" || value.ToString() == "David Fowler" || value.ToString() == "Scott Guthrie")
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Please enter a coorect value");
        }
    }
}