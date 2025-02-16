using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using XlationASP.Data;
using XlationASP.Models;
using XlationASP.ViewModels;

namespace XlationASP.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly ApplicationDbContext _applicationDbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly IMapper _mapper;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //_applicationDbContext = applicationDbContext;
            _roleManager = roleManager;
            _userManager = userManager;
            //_mapper = mapper;
        }

        // GET /api/users
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userManager.Users.ToList();
            var roles = _roleManager.Roles.ToList();

            var viewModel = new List<UserFormViewModel>();

            foreach (var user in users)
            {
                var rolesForUser = _userManager.GetRolesAsync(user).Result;
                
                viewModel.Add(new UserFormViewModel
                {
                    User = user,
                    Roles = rolesForUser
                });
            }

            return Ok(viewModel);
        }
    }
}
