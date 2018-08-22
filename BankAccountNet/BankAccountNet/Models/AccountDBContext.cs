using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankAccountNet.Models
{
    public class AccountDBContext : DbContext
    {
        public AccountDBContext() 
            : base("name=DefaultConnection")

        {

        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<AccountDetail> AccountInfos { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<TermDeposit> termDeposits { get; set; }
    }
}