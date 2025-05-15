using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SiggaFakeStore.Models;
using SiggaFakeStore.Services;
using SiggaFakeStore.Data.Services;

namespace SiggaFakeStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private UserFavoriteProductsManagement userFavoriteProductsManagement = new UserFavoriteProductsManagement();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;

        DataBaseInitializator.InitializeDB();
    }

    public IActionResult Index(int? user)
    {
        if(user == null || user == 0)
        {
            user = 1;
        }

        ViewBag.user = user;

        return View();
    }

    public IActionResult Privacy(int id, int user)
    {
        ViewBag.id = id;
        ViewBag.user = user;

        return View();
    }

    [HttpPost]
    public IActionResult AddFavoriteProduct(int id, int user)
    {
        userFavoriteProductsManagement.AddFavorite(id, user);

        return Json(true);
    }

    [HttpPost]
    public IActionResult RemoveFavoriteProduct(int id, int user)
    {
        userFavoriteProductsManagement.RemoveFavorite(id, user);

        return Json(true);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
