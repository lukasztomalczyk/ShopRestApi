using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
