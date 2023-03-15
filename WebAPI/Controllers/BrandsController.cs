using Business.Abstract;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllBrand()
        {
            var result = _brandService.GetAllBrands();
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetBrandById(int id)
        {
            var result = _brandService.GetBrandById(id);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddBrand(Brand brand)
        {
            var result = _brandService.Insert(brand);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }

        [HttpPatch("update")]
        public IActionResult UpdateBrand(Brand brand)
        {
            var result = _brandService.Update(brand);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteBrand(Brand brand)
        {
            var result = _brandService.Delete(brand);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }
    }
}