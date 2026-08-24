using BLL.Model;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        VolunteerServices service;
        public VolunteerController(VolunteerServices service)
        {
            this.service = service;
        }

        // Create Volunteer
        [HttpPost("CreateVolunteer")]
        public IActionResult CreateVolunteer(VolunteerModel model)
        {
            var result = service.CreateVolunteer(model);
            if (result)
                return Ok("Volunteer created successfully.");
            else
                return BadRequest("Failed to create food.");
        }

        // Get All Volunteers
        [HttpGet("GetAllVolunteers")]
        public IActionResult GetAllVolunteers()
        {
            var restaurants = service.GetAllVolunteers();
            return Ok(restaurants);
        }

        // Get Volunteer by ID
        [HttpGet("GetVolunteerById/{id}")]
        public IActionResult GetVolunteerById(int id)
        {
            var restaurant = service.GetVolunteerById(id);
            if (restaurant == null)
                return NotFound("Volunteer not found.");
            return Ok(restaurant);
        }

        // Update Volunteer
        [HttpPut("UpdateVolunteer/{id}")]
        public IActionResult UpdateVolunteer(int id, VolunteerModel model)
        {
            model.VolunteerId = id;
            var result = service.UpdateVolunteer(model);
            if (result)
                return Ok("Volunteer updated successfully.");
            else
                return BadRequest("Failed to update food.");
        }

        // Delete Volunteer
        [HttpDelete("DeleteVolunteer/{id}")]
        public IActionResult DeleteVolunteer(int id)
        {
            var result = service.DeleteVolunteer(id);
            if (result)
                return Ok("Volunteer deleted successfully.");
            else
                return BadRequest("Failed to delete food.");
        }
    }
}
