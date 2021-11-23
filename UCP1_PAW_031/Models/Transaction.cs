using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace UCP1_PAW_031.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
            Payments = new HashSet<Payment>();
        }

        [Key]
        public int TransactionId { get; set; }
        [Required(ErrorMessage = "User tidak boleh kosong")]
        public int? UserId { get; set; }
        [Required(ErrorMessage = "Pantai tidak boleh kosong")]
        public int? BeachId { get; set; }
        [Required(ErrorMessage = "Driver tidak boleh kosong")]
        public int? DriverId { get; set; }
        [Required(ErrorMessage = "Tanggal transaksi tidak boleh kosong")]
        public DateTime? TanggalTransaksi { get; set; }
        [Required(ErrorMessage = "Harga tidak boleh kosong")]
        public string Price { get; set; }
        [Required(ErrorMessage = "Kota tidak boleh kosong")]
        public string City { get; set; }
        [Required(ErrorMessage = "Provinsi tidak boleh kosong")]
        public string Province { get; set; }
        [MaxLength(5, ErrorMessage = "Kode pos maksimal 5 angka")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Hanya boleh diisi oleh angka")]
        public string PostalCode { get; set; }

        public virtual BeachPlace Beach { get; set; }
        public virtual UserAccess User { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
