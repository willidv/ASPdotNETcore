using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Bank_Accounts.Models;
using System.Linq;


namespace Bank_Accounts.Controllers
{
    public class Bank_AccountsController : Controller
    {
        private Bank_AccountsContext _context;
 
        public Bank_AccountsController(Bank_AccountsContext context)
    {
        _context = context;
    }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.userError = TempData["UserError"];
            ViewBag.loginError = TempData["LoginError"];
            return View();
        }
        [HttpPost]
        [Route("/CreateOwner")]
        public IActionResult CreateOwner(WrapperVM theOwner)
        {
            TempData["UserError"] = null;
            if(ModelState.IsValid)
            {
                Owner newOwner = new Owner
                {
                    First_Name = theOwner.RegisterVM.First_Name,
                    Last_Name = theOwner.RegisterVM.Last_Name,
                    Email = theOwner.RegisterVM.Email,
                    Password = theOwner.RegisterVM.Password,
                    
                };
 
                _context.Owner.Add(newOwner);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("Current_Owner.id" , newOwner.id);

                 Bank_Account NewBank_Account = new Bank_Account
            {
                owner_id = newOwner.id,
                User_Name = theOwner.RegisterVM.First_Name,
                Account_Balance = 300,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            
            _context.Add(NewBank_Account);
            _context.SaveChanges();
            
            ViewBag.Bank_Account = NewBank_Account;   
            }
           
            return Redirect("Statement");
        }
        [HttpGet]
        [Route("/LoginPage")]
        public IActionResult LoginPage()
        {
            return View("LoginPage");
        }

        [HttpPost]
        [Route("/Login")]
        public IActionResult Login(WrapperVM model)
        {
            Owner Account_Owner = _context.Owner.SingleOrDefault(Owner => Owner.Email == model.LogUser.LogEmail);

            if(model.LogUser.LogPassword == Account_Owner.Password)
            {
                HttpContext.Session.SetInt32("Current_Owner.id" , Account_Owner.id);
                return RedirectToAction("Statement");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        [Route("/Statement")]
        public IActionResult Statement()
        {
            
            Owner thisOwner = _context.Owner.SingleOrDefault(Owner => Owner.id == HttpContext.Session.GetInt32("Current_Owner.id"));

            Bank_Account thisAccount = _context.Bank_Accounts.SingleOrDefault(Bank_Account => Bank_Account.User_Name == thisOwner.First_Name);

            ViewBag.Bank_Account = thisAccount;

            List<TransactionModel> AccountTransactions = _context.Transactions.Where(Account => Account.Account_id == thisAccount.id).ToList();
             
            ViewBag.AccountTransactions = AccountTransactions;
            

            return View("BankStatement");
        }

        [HttpPost]
        [Route("/Withdraw")]
        public IActionResult Withdraw(WrapperVM model)
        {
            Owner thisOwner = _context.Owner.SingleOrDefault(Owner => Owner.id == HttpContext.Session.GetInt32("Current_Owner.id"));

            Bank_Account thisAccount = _context.Bank_Accounts.SingleOrDefault(Bank_Account => Bank_Account.User_Name == thisOwner.First_Name);

            int withdrawl = model.Transaction.withdrawl;
            TransactionModel newTransaction = new TransactionModel
                {
                    Account_id = thisAccount.id,
                    withdrawl = model.Transaction.withdrawl, 
                };
                _context.Add(newTransaction);
                _context.SaveChanges();

                List<TransactionModel> AccountTransactions = _context.Transactions.Where(Account => Account.Account_id == thisAccount.id).ToList();
                ViewBag.AccountTransactions = AccountTransactions;

            if (thisAccount.Account_Balance < withdrawl)
            {
                // MessageBox.Show( "Insufficcient Funds");
            System.Console.WriteLine("Insufficcient Funds");
            }
            else 
            {
                // MessageBox.Show( "Successfull withdrew from your account");
                thisAccount.Account_Balance -= withdrawl;
                _context.Update(thisAccount);
                _context.SaveChanges();
                System.Console.WriteLine(thisAccount.Account_Balance);

            }
            return RedirectToAction("Statement");
        }
        [HttpPost]
        [Route("/Deposit")]
        public IActionResult Deposit(WrapperVM model)
        {
            Owner thisOwner = _context.Owner.SingleOrDefault(Owner => Owner.id == HttpContext.Session.GetInt32("Current_Owner.id"));

            Bank_Account thisAccount = _context.Bank_Accounts.SingleOrDefault(Bank_Account => Bank_Account.User_Name == thisOwner.First_Name);

            int deposit = model.Transaction.deposit;
            TransactionModel newTransaction = new TransactionModel
                {
                    Account_id = thisAccount.id,
                    deposit = model.Transaction.deposit, 
                };
                _context.Add(newTransaction);
                _context.SaveChanges();
            

            List<TransactionModel> AccountTransactions = _context.Transactions.Where(Account => Account.Account_id == thisAccount.id).ToList();

            ViewBag.AccountTransactions = AccountTransactions;

                thisAccount.Account_Balance += deposit;
                _context.Update(thisAccount);
                _context.SaveChanges();
                System.Console.WriteLine(thisAccount.Account_Balance);

            return RedirectToAction("Statement");
        }
        [HttpGet]
        [Route("/Logout")]
        public IActionResult Logout()
        {
           HttpContext.Session.Clear();
           return RedirectToAction("Index");
        }
    }
}
