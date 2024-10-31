using ApplicationLayer.DTOs;
using ApplicationLayer.Service.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagaBookMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetUsersAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserDto user)
        {


            if (ModelState.IsValid)
            {
               


            
                await _userService.CreateUserAsync(user);
        
                return RedirectToAction("Index");


            }
            else
            {
    
                List<String> errors = new List<String>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = String.Join("\n", errors);
                return BadRequest(errorMessage);
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserDto user)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateUserAsync(user);
                return RedirectToAction("Index"); 
            }

            TempData["error"] = "Update thất bại"; 
            List<string> errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
            string errorMessage = string.Join("\n", errors);
            return BadRequest(errorMessage); 
        }
        public async Task<IActionResult> Delete(int Id)
        {

            await _userService.DeleteUserAsync(Id);
       
            return RedirectToAction("Index");

        }
    }
}
