using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyOwnBank.Controllers
{
    public class CardController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
        

        public IActionResult CreateACard()
        {
            return View();
        }
        
       public IActionResult ListOfCards()
       {
            return View();
       } 

       public IActionResult TransferMoney() 
       {
            return View();
       }
       
       [HttpPost]
       public IActionResult GenerateCard()
       {
            System.Console.WriteLine("LALALALLALALALALALHAAHAHAHAHHA");
            return RedirectToAction("CreateACard");
       }
    }
}