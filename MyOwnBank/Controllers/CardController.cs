using System.Xml;
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


        

        public IActionResult Index(int ClientId)
        {
            return View(ClientId);
        }
        

        public IActionResult CreateACard(int clientId)
        {
                return View(clientId);
        }
        
       public IActionResult ListOfCards(int clientId)
       {
            var card = _context.BankCards.FirstOrDefault(c => c.ClientId == clientId);
            if(card == null)
                return RedirectToAction("PageNotCard",new {clientId = clientId});
            return View(card);
       } 

       public IActionResult TransferMoney(int clientId) 
       {
            return View(clientId);
       }

       [HttpPost]
       public IActionResult TransferMoney(int clientId, int mainNums, int countMoney)
       {
            var clientCard = _context.BankCards.FirstOrDefault(x => x.ClientId == clientId);
            if(clientCard == null)
                return RedirectToAction("PageNotCard", new {clientId = clientId});
            if(clientCard.Balance < countMoney)
            {
                ViewBag.CantTransfer = "Not enough money to transfer";
                return View(clientId);
            }

            var anotherCard = _context.BankCards.FirstOrDefault( x=> x.MainNumbers == mainNums.ToString());
            if(anotherCard == null)
            {
                ViewBag.NotExistCard = "This card not exists";
                return View(clientId);
            }

            clientCard.Balance -= countMoney;
            anotherCard.Balance += countMoney;
            _context.SaveChanges();
            return RedirectToAction("Index", new {clientId = clientId});
       }

        public IActionResult AddMoneyToMyCard(int clientId)
        {
            return View(clientId);
        }
        [HttpPost]
        public IActionResult MethodAddMoneyToMyCard(int countMoney, int clientId)
        {
            var card = _context.BankCards.FirstOrDefault(x => x.ClientId == clientId);
            if(card == null)
                return RedirectToAction("PageNotCard", new {clientId = clientId});
            card.Balance += countMoney;
            _context.SaveChanges();
            return RedirectToAction("Index",new {clientId = clientId});
        }
        [HttpPost]
        public IActionResult GenerateCard(int clientId)
        {
            
            var card = _context.BankCards.FirstOrDefault(c => c.ClientId == clientId);
            if(card != null)
                return RedirectToAction("Index", new {clientId = clientId});
            Random rand = new();
            BankCard cardObj = new BankCard();
            
                cardObj.MainNumbers = rand.Next(100000,999999).ToString();
                cardObj.CVVCard = rand.Next(100,999);
                cardObj.ValidThru = DateTime.Now + TimeSpan.FromDays(100);
                cardObj.ClientId = clientId; 
                cardObj.Balance =0f;
            
            

            _context.BankCards.Add(cardObj);
            _context.SaveChanges();            
            
            return RedirectToAction("Index", new {clientId = clientId});
        }
        
        public IActionResult PageNotCard(int clientId)
        {
            return View(clientId);
        }
    }
}