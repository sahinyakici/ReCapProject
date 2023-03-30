using Business.Abstract;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllCars()
        {
            var result = _carService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetCarById(int id)
        {
            var result = _carService.GetCarById(id);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetCarByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("getbycolorid")]
        public IActionResult GetCarByColorId(int id)
        {
            var result = _carService.GetCarsByColorId(id);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPatch("update")]
        public IActionResult UpdateCar(Car car)
        {
            var result = _carService.Update(car);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteCar(Car car)
        {
            var result = _carService.Delete(car);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("getdetailsbybrand")]
        public IActionResult GetCarDetailsByBrand(int brandId)
        {
            var result = _carService.GetCarDetailsByBrandId(brandId);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        
        [HttpGet("getdetailsbycolor")]
        public IActionResult GetCarDetailsByColor(int colorId)
        {
            var result = _carService.GetCarDetailsByColorId(colorId);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddCar(Car car)
        {
            var result = _carService.Add(car);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }
    }
}