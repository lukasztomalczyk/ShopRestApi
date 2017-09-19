using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BussinesAccessLayer.BusinessObjects
{
    public class OrderBussinesObject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public CustomerBussinesObject Customer { get; set; }
    }
}
