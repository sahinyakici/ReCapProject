using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private IRentalsService _rentalsService;

        public RentalsController(IRentalsService rentalsService)
        {
            _rentalsService = rentalsService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllRentals()
        {
            var result = _rentalsService.GetAll();
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetRentalById(int id)
        {
            var result = _rentalsService.GetByRentalId(id);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddRental(Rentals rental)
        {
            var result = _rentalsService.Add(rental);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }

        [HttpPatch("update")]
        public IActionResult UpdateRental(Rentals rental)
        {
            var result = _rentalsService.Update(rental);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteRental(Rentals rental)
        {
            var result = _rentalsService.Delete(rental);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }
    }
}