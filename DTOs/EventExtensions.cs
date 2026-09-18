using EventCountdownBackend.Models;

namespace EventCountdownBackend.DTOs
{
    public static class EventExtensions
    {
        // Creates Event from DTO
        public static Event ToEntity(this CreateEventRequestDTO request)
        {
            return new Event
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                IsOnline = request.IsOnline,
                OnlineEventUrl = request.OnlineEventUrl,
                EventDateTime = request.EventDateTime,
                Country = request.Country,
                City = request.City,
                Address = request.Address,
                ZipCode = request.ZipCode
            };
        }

        public static void PatchEntity(this UpdateEventRequestDTO eventUpdateRequest, Event eventToPatch)
        {
            if(eventUpdateRequest.Name is not null)
                eventToPatch.Name = eventUpdateRequest.Name;

            if (eventUpdateRequest.Description is not null)
                eventToPatch.Description = eventUpdateRequest.Description;

            //if (eventUpdateRequest.EventDateTime != .EventDateTime)
                //eventToPatch.EventDateTime = eventUpdateRequest.EventDateTime;

            if (eventUpdateRequest.IsOnline.HasValue)
                eventToPatch.IsOnline = eventUpdateRequest.IsOnline.Value;

                if (eventToPatch.IsOnline)
                {
                    eventToPatch.Address = null;
                    eventToPatch.City = null;
                    eventToPatch.ZipCode = null;
                    eventToPatch.Country = null;

                }
                else
                {
                    if (eventUpdateRequest.City is not null)
                    {
                        eventToPatch.City = eventUpdateRequest.City;
                    }
                    if (eventUpdateRequest.ZipCode is not null)
                    {   
                        eventToPatch.ZipCode = eventUpdateRequest.ZipCode;
                    }
                    if (eventUpdateRequest.Country is not null)
                    {
                        eventToPatch.Country = eventUpdateRequest.Country;
                    }
                    if (eventUpdateRequest.Address is not null)
                    {
                        eventToPatch.Address = eventUpdateRequest.Address;
                    }
            }
        }
    }
}
