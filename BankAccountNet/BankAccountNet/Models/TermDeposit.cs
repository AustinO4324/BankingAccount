using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankAccountNet.Models
{
    public class TermDeposit
    {
        [Key]
        public int TermDepositID { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Deposit { get; set; }
        [DataType(DataType.Date)]
        public DateTime TermCreation { get; set; }

    }
}