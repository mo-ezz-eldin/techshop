using e_commerce.Models;
using e_commerce.viewmodels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Controllers
{
    public class accountController : Controller
    {
        private readonly SignInManager<appuser> _signInManager;
        private readonly UserManager<appuser> _userManager;
        public accountController(SignInManager<appuser> signInManager, UserManager<appuser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult register()
        {
            return View("register");
        }
        [HttpPost]
        public async Task<IActionResult> Register(userregisterviewmodel model)
        {
            if (ModelState.IsValid)
            {
                var user = new appuser()
                {
                    UserName = model.username,
                    Email = model.email,


                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login(string? ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(userloginviewmodel model, string? ReturnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Email or password is invalid");
                }
                else
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(user.UserName, model.password, model.remember_me, false);
                    if (signInResult.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email or password is invalid");
                    }
                }
            }

            return View(model);
        }
        public async Task<IActionResult> logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> edit(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            var model = new UserEditVM()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName

            };
            return View("Edit", model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return NotFound();
            }


            if (user.Email != model.Email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setEmailResult.Succeeded)
                {
                    foreach (var error in setEmailResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }
                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignInAsync(user, isPersistent: true);
            }

           
            if (user.UserName != model.UserName)
            {
                var setUserNameResult = await _userManager.SetUserNameAsync(user, model.UserName);
                if (!setUserNameResult.Succeeded)
                {
                    foreach (var error in setUserNameResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }
                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignInAsync(user, isPersistent: true);
            }

           
            if (!string.IsNullOrEmpty(model.NewPassword))
            {
         
                if (model.NewPassword.Length < 14)
                {
                    ModelState.AddModelError(nameof(model.NewPassword), "Password must be at least 14 characters.");
                    return View(model);
                }

                if (model.NewPassword != model.ConfirmPassword)
                {
                    ModelState.AddModelError(nameof(model.ConfirmPassword), "Passwords do not match.");
                    return View(model);
                }

             
                var removeResult = await _userManager.RemovePasswordAsync(user);
                if (!removeResult.Succeeded)
                {
                    foreach (var error in removeResult.Errors)
                        ModelState.AddModelError("", error.Description);
                    return View(model);
                }

                var addResult = await _userManager.AddPasswordAsync(user, model.NewPassword);
                if (!addResult.Succeeded)
                {
                    foreach (var error in addResult.Errors)
                        ModelState.AddModelError("", error.Description);
                    return View(model);
                }

              
                await _signInManager.SignInAsync(user, isPersistent: true);
            }

            return RedirectToAction("Index", "Home");
        }




    }
}

