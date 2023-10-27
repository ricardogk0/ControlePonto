using AutoMapper;
using Backend.DTOs;
using Backend.Interfaces;
using Backend.Models;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace beckend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly BatidaPontoContext _context;
        private readonly IUser _user;

        public UserController(BatidaPontoContext context, IUser user)
        {
            _context = context;
            _user = user;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
    }
}
