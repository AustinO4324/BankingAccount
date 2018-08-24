using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BankAccountNet.Models;

namespace BankAccountNet.Controllers
{
    public class AccountDetailsController : Controller
    {
        private AccountDBContext db = new AccountDBContext();

        // GET: AccountDetails
        public ActionResult Index()
        {
            var accountInfos = db.AccountInfos.Include(a => a.Customer);
            return View(accountInfos.ToList());
        }

        // GET: AccountDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountDetail accountDetail = db.AccountInfos.Find(id);
            if (accountDetail == null)
            {
                return HttpNotFound();
            }
            return View(accountDetail);
        }

        // GET: AccountDetails/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName");
            return View();
        }

        // POST: AccountDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( AccountDetail accountDetail)
        {
            if (ModelState.IsValid)
            {
                db.AccountInfos.Add(accountDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", accountDetail.CustomerID);
            return View(accountDetail);
        }

        // GET: AccountDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountDetail accountDetail = db.AccountInfos.Find(id);
            if (accountDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", accountDetail.CustomerID);
            return View(accountDetail);
        }

        // POST: AccountDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AccountDetail accountDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", accountDetail.CustomerID);
            return View(accountDetail);
        }

        public ActionResult Deposit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountDetail accountDetail = db.AccountInfos.Find(id);
            TempData["AccountBalance"] = accountDetail.Balance;
            if (accountDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", accountDetail.CustomerID);


            return View(accountDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deposit(AccountDetail accountDetail)
        {
            if (ModelState.IsValid)
            {
                var depositAmount = accountDetail.Balance;
                accountDetail.Balance = (double)TempData["AccountBalance"];
                accountDetail.Balance += depositAmount;
                db.Entry(accountDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = accountDetail.CustomerID });
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", accountDetail.CustomerID);
            return View(accountDetail);
        }

        // GET: AccountDetails/Delete/5
        public ActionResult Withdraw(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountDetail accountDetail = db.AccountInfos.Find(id);
            TempData["AccountBalance"] = accountDetail.Balance;
            if (accountDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", accountDetail.CustomerID);
            return View(accountDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Withdraw( AccountDetail accountDetail)
        {
            if (ModelState.IsValid)
            {
                var withdrawAmount = accountDetail.Balance;
                accountDetail.Balance = (double)TempData["AccountBalance"];
                accountDetail.Balance -= withdrawAmount;
                db.Entry(accountDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = accountDetail.CustomerID});
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", accountDetail.CustomerID);
            return View(accountDetail);
        }


        // GET: AccountDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountDetail accountDetail = db.AccountInfos.Find(id);
            if (accountDetail == null)
            {
                return HttpNotFound();
            }
            return View(accountDetail);
        }

        // POST: AccountDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountDetail accountDetail = db.AccountInfos.Find(id);
            db.AccountInfos.Remove(accountDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ViewCustomers(int id)
        {
            return RedirectToAction("Index", "Customers", new { id = id });
        }

        public ActionResult ViewLoans(int id)
        {
            return RedirectToAction("Index", "Loans", new { id = id });
        }

        public ActionResult ViewTermDeposit(int id)
        {
            return RedirectToAction("Index", "TermDeposits", new { id = id });
        }

        public ActionResult ViewAccounts(int id)
        {
            return RedirectToAction("Index", "AccountDetails", new { id = id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
