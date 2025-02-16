using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XlationASP.Data;
using XlationASP.Dtos;
using XlationASP.Models;
using XlationASP.ViewModels;

namespace XlationASP.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UsersController(ApplicationDbContext applicationDbContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        // GET /api/users
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _applicationDbContext.Users.Include(u => u.MembershipType).ToList();
            var usersDto = new List<ApplicationUserDto>();

            foreach (var user in users)
            {
                var userDto = _mapper.Map<ApplicationUserDto>(user);
                var rolesForUser = _userManager.GetRolesAsync(user).Result;
                userDto.Roles = [..rolesForUser];

                usersDto.Add(userDto);
            }

            return Ok(usersDto);
        }

        // GET /api/users/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound("No User found with the Id provided.");

            var userDto = _mapper.Map<ApplicationUserDto>(user);
            userDto.Roles = [.. _userManager.GetRolesAsync(user).Result];

            return Ok(userDto);
        }
    }
}
