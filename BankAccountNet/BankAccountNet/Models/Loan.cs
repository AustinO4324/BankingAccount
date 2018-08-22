using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankAccountNet.Models
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double LoanAmount { get; set; }
        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }

    }
}