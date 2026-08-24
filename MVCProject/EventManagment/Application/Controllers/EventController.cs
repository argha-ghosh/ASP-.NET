using BLL.Model;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        EventServices service;
        public EventController(EventServices service)
        {
            this.service = service;
        }

        // Create Event
        [HttpPost("CreateEvent")]
        public IActionResult CreateEvent(EventModel model)
        {
            var result = service.CreateEvent(model);
            if (result)
                return Ok("Event created successfully.");
            else
                return BadRequest("Failed to create food.");
        }

        // Get All Events
        [HttpGet("GetAllEvents")]
        public IActionResult GetAllEvents()
        {
            var restaurants = service.GetAllEvents();
            return Ok(restaurants);
        }

        // Get Event by ID
        [HttpGet("GetEventById/{id}")]
        public IActionResult GetEventById(int id)
        {
            var restaurant = service.GetEventById(id);
            if (restaurant == null)
                return NotFound("Event not found.");
            return Ok(restaurant);
        }

        // Update Event
        [HttpPut("UpdateEvent/{id}")]
        public IActionResult UpdateEvent(int id, EventModel model)
        {
            model.EventId = id;
            var result = service.UpdateEvent(model);
            if (result)
                return Ok("Event updated successfully.");
            else
                return BadRequest("Failed to update food.");
        }

        // Delete Event
        [HttpDelete("DeleteEvent/{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var result = service.DeleteEvent(id);
            if (result)
                return Ok("Event deleted successfully.");
            else
                return BadRequest("Failed to delete food.");
        }
    }
}
