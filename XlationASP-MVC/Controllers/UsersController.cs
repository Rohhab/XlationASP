using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using XlationASP.Models;
using XlationASP.ViewModels;

namespace XlationASP.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: UsersController
        public IActionResult Index()
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

            if (User.IsInRole("Admin"))
            {
                ViewData["Title"] = "User Management Console";
                return View(viewModel);
            }
            else
            {
                ViewData["Title"] = "Users Console";
                return View(viewModel);
            }
        }

        // GET: UsersController/Edit/Id
        [HttpGet]
        [Route("users/details/{id?}")]
        public async Task<IActionResult> Details(string? id, string? queryId)
        {
            var effectiveId = id ?? queryId;

            if (effectiveId == null)
                return NotFound();

            var user = await _userManager.FindByIdAsync(effectiveId);
            var roles = _roleManager.Roles.ToList();
            List<String> modelRoles = [];

            if (user == null)
                return NotFound("User not found.");

            foreach(var role in roles)
            {
                modelRoles.Add(role.Name);
            }

            var viewModel = new UserFormViewModel
            {
                User = user,
                Roles = modelRoles
            };

            return View(viewModel);
        }
    }
}
