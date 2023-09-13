using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyOwnBank.Data;
using MyOwnBank.Models;

namespace MyOwnBank.Controllers
{
    public class CardController : Controller
    {


        private readonly MyDbContext _context;

        public CardController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Index(int ClientId)
        {
            return View(ClientId);
        }
        

        public IActionResult CreateACard(int clientId)
        {
            return View(clientId);
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
        public IActionResult GenerateCard(int clientId)
        {
            Random rand = new();
            BankCard cardObj = new BankCard();
            
                cardObj.MainNumbers = rand.Next(100000,999999).ToString();
                cardObj.CVVCard = rand.Next(100,999);
                cardObj.ValidThru = DateTime.Now + TimeSpan.FromDays(100);
                cardObj.ClientId = clientId; 
                cardObj.Balance =0f;
            
            

            _context.BankCards.Add(cardObj);
            _context.SaveChanges();            
            
            return RedirectToAction("CreateACard");
        }
    }
}