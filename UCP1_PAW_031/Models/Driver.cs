using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace UCP1_PAW_031.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Transactions = new HashSet<Transaction>();
        }
        [Key]
        public int DriverId { get; set; }
        [Required(ErrorMessage = "Driver name tidak boleh kosong")]
        public string DriverName { get; set; }
        [MinLength(10, ErrorMessage = "No hp minimal 10 angka")]
        [MaxLength(13, ErrorMessage = "No hp maksimal 13 angka")]
        public string DriverPhone { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
