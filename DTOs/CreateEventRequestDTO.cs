using EventCountdownBackend.Models;
using System.ComponentModel.DataAnnotations;

namespace EventCountdownBackend.DTOs
{
    public class CreateEventRequestDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public bool IsOnline { get; set; } = false;
        public string? OnlineEventUrl { get; set; }
        [Required(ErrorMessage = "Event Date Required")]
        public DateTime EventDateTime { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public int? ZipCode {  get; set; }
    }

    
}