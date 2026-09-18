using EventCountdownBackend.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EventCountdownBackend.DTOs
{
    public class UpdateEventRequestDTO
    {

        [MinLength(4)]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool? IsOnline { get; set; }
        public string? OnlineEventUrl { get; set; }
        public DateTime EventDateTime { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public int? ZipCode { get; set; }
    }

    
}