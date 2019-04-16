using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;

namespace MadeToEngageTasks.Models.Pages
{
    [ContentType(DisplayName = "Event", GUID = "a99a35b2-b52c-4585-a93d-cf1656fe1c59", Description = "")]
    public class EventPage : StandardPage, IValidatableObject
    {
        [Display(
            Name = "Summary",
            GroupName = Global.GroupNames.Content,
            Order = 1)]
        [UIHint(UIHint.Textarea)]
        public virtual string Summary { get; set; }


        [Display(
            Name = "Description",
            GroupName = Global.GroupNames.Content,
            Order = 2)]
        public virtual XhtmlString Description { get; set; }


        [Display(
            Name = "Title",
            GroupName = Global.GroupNames.Event,
            Order = 3)]
        [Required]
        [RegularExpression("[a-zA-Z0-9_\\s]+", ErrorMessage = "Title should be alphanumeric")]
        public virtual string Title { get; set; }

        [Display(
           Name = "Speaker",
           GroupName = Global.GroupNames.Event,
           Order = 4)]
        //[SpecialSpeaker]
        [SelectOne(SelectionFactoryType = typeof(SpeakerSelectionAttribute))]
        public virtual string Speaker { get; set; }

        [Display(
           Name = "No Attendees",
           GroupName = Global.GroupNames.Event,
           Order = 5)]
        [Range(1, 100, ErrorMessage = "The value must be between 1 and 100")]
        public virtual int NoAttendees { get; set; }

        [Display(
           Name = "Start Date",
           GroupName = Global.GroupNames.Event,
           Order = 6)]
        [Required]
        public virtual DateTime StartDate { get; set; }

        [Display(
           Name = "End Date",
           GroupName = Global.GroupNames.Event,
           Order = 7)]
        public virtual DateTime EndDate { get; set; }

        [Display(
           Name = "Event Image",
           GroupName = Global.GroupNames.Event,
           Order = 8)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference EventImage { get; set; }

        [Display(
           Name = "Description",
           GroupName = Global.GroupNames.Content,
           Order = 9)]
        public virtual ContentArea AdditionalContent { get; set; }

        [Display(
           Name = "Description",
           GroupName = Global.GroupNames.Event,
           Order = 10)]
        public virtual EventStatus EvtStatus { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();
            if (EndDate < StartDate)
            {
                ValidationResult message = new ValidationResult("End date must not before Start Date");
                result.Add(message);
            }
            return result;
        }
    }

    public enum EventStatus
    {
        Unknown, Closed
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
}