using Business.Abstract;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult AddImages(int carId, string path)
        {
            var result = _carImageService.AddCarImage(carId, path);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAllImages()
        {
            var result = _carImageService.GetAllCarImage();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetImagesByCarId(int id)
        {
            var result = _carImageService.GetCarImageByCarId(id);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("getbyimageid")]
        public IActionResult GetImageByID(string id)
        {
            var result = _carImageService.GetCarImageById(id);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPatch("update")]
        public IActionResult UpdateImage(string path, int carImageId)
        {
            var result = _carImageService.UpdateCarImage(carImageId, path);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteImage(CarImage carImage)
        {
            var result = _carImageService.DeleteCarImage(carImage);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
    }
}