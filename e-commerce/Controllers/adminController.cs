using e_commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace e_commerce.Controllers
{
   [Authorize(Roles ="Admin")]
    
    public class adminController : Controller
    {
        readonly RoleManager<IdentityRole> _rolemanager;
        readonly UserManager<appuser> _userManager;
        public adminController(RoleManager<IdentityRole> rolemanager,UserManager<appuser>userManager)
        {
            _rolemanager = rolemanager;
            _userManager = userManager;
        }
       

        public IActionResult Index()
        {
           return RedirectToAction("Index","Home");
        }
        public IActionResult create()
        {
            return View("create");
        }
        [HttpPost]
        public async Task<IActionResult> create(string name) {
            if (string.IsNullOrEmpty(name) ) {
                ModelState.AddModelError("", "name is required");
                return View();
            }
            if (name.Length > 50)
            {
                ModelState.AddModelError("", "name should less than 50 or equal");
                return View();
            }
            var role = new IdentityRole()
            {
                Name=name
            };
       
            await _rolemanager.CreateAsync(role);
            return RedirectToAction("Index");
        }
        public IActionResult viewusers()
        {
            return View("users",_userManager.Users.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetUserRole(string userId,string roleName) { 
            var user=await _userManager.FindByIdAsync(userId);
            if(user==null)
            {
                return NotFound("this user is not found");
            }
            var user_role=await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user,user_role);

            var result=await _userManager.AddToRoleAsync(user,roleName);
            
            if (result.Succeeded)
            {
                await _userManager.UpdateSecurityStampAsync(user);
                return Ok();
            }
            else
            {
                return BadRequest();
            }


        }
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user=await _userManager.FindByIdAsync(userId);
            if(user==null )
            {
                return NotFound("this user is not found");
            }
            var result=await _userManager.DeleteAsync(user);
           return result.Succeeded ? Ok("this user is deleted succesfully") : BadRequest("error on delteing the user");
        }


    }
}
