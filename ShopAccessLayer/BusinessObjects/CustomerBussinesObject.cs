using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BussinesAccessLayer.BusinessObjects
{
   public class CustomerBussinesObject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public List<AddressBussinesObject> Addresses { get; set; }
   
    }
}
