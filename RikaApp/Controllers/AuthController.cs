using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RikaApp.ViewModels;

namespace accountProvider.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, DataContext context) : Controller
{
    private readonly DataContext _context = context;
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    [Route("/signup")]
    public IActionResult SignUp()
    {
        Console.WriteLine("Navigated to SignUp view (GET request).");
        return View();
    }

    [HttpPost]
    [Route("/signup")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SignUp(SignUpViewModel model)
    {
        Console.WriteLine("SignUp POST request received.");

        if (ModelState.IsValid)
        {
            Console.WriteLine("Model state is valid for email: " + model.Email);

            if (!await _context.Users.AnyAsync(x => x.Email == model.Email))
            {
                Console.WriteLine("No existing user found with email: " + model.Email);

                var userEntity = new UserEntity
                {
                    Email = model.Email,
                    UserName = model.Email
                };

                var result = await _userManager.CreateAsync(userEntity, model.Password);
                if (result.Succeeded)
                {
                    Console.WriteLine("User successfully created and signed in with email: " + model.Email);
                    await _signInManager.SignInAsync(userEntity, isPersistent: false);
                    return LocalRedirect("/");
                }
                else
                {
                    Console.WriteLine("Failed to create user with email: " + model.Email);
                    ViewData["StatusMessage"] = "Something went wrong. Try again later";
                }
            }
            else
            {
                Console.WriteLine("User with email already exists: " + model.Email);
                ViewData["StatusMessage"] = "User with the same email already exists";
            }
        }
        else
        {
            Console.WriteLine("Model state is invalid for email: " + model.Email);
        }

        Console.WriteLine("Returning to SignUp view due to validation or error.");
        return View(model);
    }


    //SIGNIN VIEW

    [Route("/signin")]
    public IActionResult SignIn()
    {
        return View();
    }

    /// <summary>
    /// Signs in a user and redirects to profile page.
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    [Route("/signin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel)
    {
        //försök logga in om giltig
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(viewModel.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Profile", "Account");
                }

            }
        }

        ViewData["StatusMessage"] = "Incorrect credentials, try again.";
        return View(viewModel);
    }

    /// <summary>
    /// Logs out and redirects the user to the frontpage.
    /// </summary>
    /// <returns></returns>
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Home", "Default");
    }
}