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
    public class TermDepositsController : Controller
    {
        private AccountDBContext db = new AccountDBContext();

        // GET: TermDeposits
        public ActionResult Index()
        {
            return View(db.termDeposits.ToList());
        }

        // GET: TermDeposits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TermDeposit termDeposit = db.termDeposits.Find(id);
            if (termDeposit == null)
            {
                return HttpNotFound();
            }
            return View(termDeposit);
        }

        // GET: TermDeposits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TermDeposits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TermDepositID,Deposit,TermCreation")] TermDeposit termDeposit)
        {
            if (ModelState.IsValid)
            {
                db.termDeposits.Add(termDeposit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(termDeposit);
        }

        // GET: TermDeposits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TermDeposit termDeposit = db.termDeposits.Find(id);
            if (termDeposit == null)
            {
                return HttpNotFound();
            }
            return View(termDeposit);
        }

        // POST: TermDeposits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TermDepositID,Deposit,TermCreation")] TermDeposit termDeposit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(termDeposit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(termDeposit);
        }

        // GET: TermDeposits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TermDeposit termDeposit = db.termDeposits.Find(id);
            if (termDeposit == null)
            {
                return HttpNotFound();
            }
            return View(termDeposit);
        }

        // POST: TermDeposits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TermDeposit termDeposit = db.termDeposits.Find(id);
            db.termDeposits.Remove(termDeposit);
            db.SaveChanges();
            return RedirectToAction("Index");
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
