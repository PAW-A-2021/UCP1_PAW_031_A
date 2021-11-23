using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace UCP1_PAW_031.Models
{
    public partial class UserAccess
    {
        public UserAccess()
        {
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Nama tidak boleh kosong")]
        public string Name { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "Hanya boleh diisi oleh angka")]
        public string IdCard { get; set; }
        [Required(ErrorMessage = "Email tidak boleh kosong")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Masukkan email dengan benar")]
        public string Email { get; set; }
        [MinLength(10, ErrorMessage = "No hp minimal 10 angka")]
        [MaxLength(13, ErrorMessage = "No hp maksimal 13 angka")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Alamat tidak boleh kosong")]
        public string Address { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
