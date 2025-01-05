using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using XlationASP.Models;
using XlationASP.ViewModels;

namespace XlationASP.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: RoleController
        public ActionResult Index()
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

            return View(viewModel);
        }

        // GET: RoleController/Edit/Id
        [HttpGet]
        [Route("role/edit/")]
        public async Task<ActionResult> Edit()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var rolesForUser = await _userManager.GetRolesAsync(user);

            if (user == null)
                return NotFound("User not found.");

            return Ok($"User with Id = {user.Id}, has an email = {user.UserName} and roles = {string.Join(", ", rolesForUser)}");
        }
    }
}
