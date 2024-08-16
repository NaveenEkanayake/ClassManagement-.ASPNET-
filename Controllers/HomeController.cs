using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Studentportal.Models;
using System.Diagnostics;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var email = model.Email?.Trim().ToLower();
            var password = model.Password?.Trim();
            const string adminEmail = "admin123@gmail.com";
            const string adminPassword = "admin123";

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                if (email == adminEmail && password == adminPassword)
                {
                    _logger.LogInformation("Login successful. Redirecting to Add action in Students controller.");
                    return RedirectToAction("List", "Students");
                }
                else
                {
                    _logger.LogWarning("Invalid login attempt with Email: {Email}", model.Email);
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            else
            {
                _logger.LogWarning("Email or password is null or empty.");
                ModelState.AddModelError(string.Empty, "Email or password is missing.");
            }
        }
        else
        {
            _logger.LogWarning("Model state is not valid.");
        }

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
