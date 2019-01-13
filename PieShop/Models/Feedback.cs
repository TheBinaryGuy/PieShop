using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace PieShop.Models
{
    public class Feedback
    {
        [BindNever]
        public int FeedbackId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Email is requried.")]
        public string Email { get; set; }

        [Required]
        [StringLength(5000, ErrorMessage = "Message is requried.")]
        public string Message { get; set; }

        [Display(Name = "Contact Me")]
        public bool ContactMe { get; set; }
    }
}
