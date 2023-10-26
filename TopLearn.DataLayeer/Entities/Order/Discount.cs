using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLearn.DataLayeer.Entities.Order
{
    public  class Discount
    {
        [Key]
        public int DiscountId { get; set; }

        [Required]
        [MaxLength(100)]
        public string DiscountCode { get; set; }
        
        [Required]
        public int DiscountPercent { get; set; }
        public int? UseableCount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
