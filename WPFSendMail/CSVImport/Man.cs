using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVImport
{
    public class Man
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        public string Phone { get; set; }
        public Man() { }
        public Man(string name, string email,string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}
