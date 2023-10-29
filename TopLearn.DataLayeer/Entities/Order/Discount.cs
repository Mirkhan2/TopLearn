using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.DataLayeer.Entities.User;

namespace TopLearn.DataLayeer.Entities.Order
{
    public  class Discount
    {
        [Key]
        public int DiscountId { get; set; }


		[Display(Name = "کد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(150)]
		public string DiscountCode { get; set; }

		[Display(Name = "درصد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int DiscountPercent { get; set; }
        public int? UseableCount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public List<UserDiscountCode> UserDiscountCodes { get; set; }

    }
}
