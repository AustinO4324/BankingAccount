using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankAccountNet.Models
{
    public class AccountDetail
    {
        [Key]
        public int AccountID { get; set; }
        public int TermDepositID { get; set; }
        [Required]
        [StringLength(20)]
        public string AccountType { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Balance { get; set; }
        [Required]
        public int CustomerID { get; set; }



        public virtual IList<TermDeposit> TermDeposits { get; set; }
        public virtual Customer Customer { get; set; }
    }
}