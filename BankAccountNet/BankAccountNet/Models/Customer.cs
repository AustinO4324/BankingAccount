using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankAccountNet.Models
{
    public class Customer
    {

        [Key]
        public int CustomerID { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [StringLength(20)]
        public string LastName { get; set; }
        [StringLength(128)]
        public string UserID { get; set; }

        public virtual IList<AccountDetail> Accounts { get; set; }
        public virtual IList<Loan> Loans { get; set; }
    }
}