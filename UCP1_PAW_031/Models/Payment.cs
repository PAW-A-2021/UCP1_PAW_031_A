using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace UCP1_PAW_031.Models
{
    public partial class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required(ErrorMessage = "Transaction tidak boleh kosong")]
        public int? TransactionId { get; set; }
        [Required(ErrorMessage = "Total tidak boleh kosong")]
        public string Total { get; set; }
        [Required(ErrorMessage = "Status tidak boleh kosong")]
        public string Status { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
