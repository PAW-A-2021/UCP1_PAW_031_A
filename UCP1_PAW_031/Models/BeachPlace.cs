using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace UCP1_PAW_031.Models
{
    public partial class BeachPlace
    {
        public BeachPlace()
        {
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        public int BeachId { get; set; }
        [Required(ErrorMessage = "Nama pantai tidak boleh kosong")]
        public string BeachName { get; set; }
        [Required(ErrorMessage = "Deskripsi tidak boleh kosong")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Harga tidak boleh kosong")]
        public string Price { get; set; }
        [Required(ErrorMessage = "Lokasi tidak boleh kosong")]
        public string Location { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
