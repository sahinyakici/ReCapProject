using Business.Abstract;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllUsers()
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
        public IActionResult AddUser(Users user)
        {
            var result = _usersService.Add(user);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }

        [HttpPatch("update")]
        public IActionResult UpdateUser(Users user)
        {
            var result = _usersService.Update(user);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteUser(Users user)
        {
            var result = _usersService.Delete(user);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }
    }
}