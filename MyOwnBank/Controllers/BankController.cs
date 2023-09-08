using Microsoft.AspNetCore.Mvc;
using MyOwnBank.Contracts.ClientClasses;
using MyOwnBank.Data;
using MyOwnBank.Models;

namespace MyOwnBank.Controllers;

public class BankController : Controller
{
    private readonly MyDbContext _context;

    public BankController(MyDbContext context)
    {
        _context = context;   
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string Login, string Password)
    {
        var clientObj = _context.Clients.FirstOrDefault(c => c.Login == Login && c.Password == Password);
        if (clientObj == null)
        {
            ViewBag.NotFoundAccount = "Not right login or password";
            return View();
        }
        else
        {
            return RedirectToAction("MainPage",clientObj);
        }
    }

    public IActionResult MainPage(Client clientObj)
    {
        return View(clientObj);
    }

    public IActionResult CreateClientAccount()
    {
        return View();
    }
    [HttpPost]
    public IActionResult CreateClientAccount(string Name, int Age, string Login, string Password)
    {
        bool IsHasClient = _context.Clients.FirstOrDefault(c => c.Login == Login) != null; 
        if(IsHasClient)
        {
            ViewBag.ErrorSameClientLogin = "This login already registered";
            return View();
        }
        Client client = new()
        {
            Name = Name,
            Age = Age,
            Login = Login,
            Password = Password,
            BankCard = null
        };
        _context.Clients.Add(client);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}