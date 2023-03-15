using Business.Abstract;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllColors()
        {
            var result = _colorService.GetAllColors();
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetColorById(int id)
        {
            var result = _colorService.GetColorById(id);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddColor(Color color)
        {
            var result = _colorService.Insert(color);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }

        [HttpPatch("update")]
        public IActionResult UpdateColor(Color color)
        {
            var result = _colorService.Update(color);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteColor(Color color)
        {
            var result = _colorService.Delete(color);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }
    }
}