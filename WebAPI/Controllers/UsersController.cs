using Business.Abstract;
using Entities.Abstract.Concrete;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _usersService;

        public UserController(IUserService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllUser()
        {
            var result = _usersService.GetAll();
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetUserById(int id)
        {
            var result = _usersService.GetUserById(id);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddUser(User user)
        {
            var result = _usersService.Add(user);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }

        [HttpPatch("update")]
        public IActionResult UpdateUser(User user)
        {
            var result = _usersService.Update(user);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteUser(User user)
        {
            var result = _usersService.Delete(user);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }
    }
}