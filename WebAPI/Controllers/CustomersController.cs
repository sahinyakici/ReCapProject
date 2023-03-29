using Business.Abstract;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllCustomers()
        {
            var result = _customersService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetByCustomerId(int id)
        {
            var result = _customersService.GetByCustomerId(id);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddCustomer(Customers customer)
        {
            var result = _customersService.Add(customer);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteCustomer(Customers customer)
        {
            var result = _customersService.Delete(customer);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }

        [HttpPatch("update")]
        public IActionResult UpdateCustomer(Customers customer)
        {
            var result = _customersService.Update(customer);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }
    }
}