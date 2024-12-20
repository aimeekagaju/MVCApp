using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCApp.Handlers.Validations;
using MVCApp.Models;
using System.Reflection.Metadata.Ecma335;


namespace MVCApp.Controllers
{
    public class AuthController : Controller
    {
        [ViewData]
        public string Title { get; set; } = null!;
        public IActionResult Index()
        {
            Title = "Accès membres";
            return RedirectToAction(nameof(Login));
        }
        
        public IActionResult Register()
        {
            Title = "Accès membres";
            if (TempData.ContainsKey("message"))
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                TempData["message"] = "Vous êtes maintenant enregistrés!";
                return View();
            }  
        }
        public IActionResult Login()
        {
            Title = "Accès membres";
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            ModelState
                .ValidateRequired(form.Email,nameof(form.Email))
                .ValidateRequired(form.Password, nameof(form.Password))
                .ValidateLength(form.Email, nameof(form.Email), 3, 320)
                .ValidateLength(form.Password, nameof(form.Password), 8, 32)
                .ValidatePassword(form.Password, nameof(form.Password));

            if(ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Vous êtes connectés!"; //tempdata est pour une redirection tandis que viewdata est pour la vue actuelle
                return RedirectToAction(nameof(Index), "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Données incorrectes !";
                return View();
            }
        }
    }
}
