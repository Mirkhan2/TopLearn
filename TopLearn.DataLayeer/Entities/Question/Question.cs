using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLearn.DataLayeer.Entities.Question
{
    public  class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Display(Name ="Onvane Soal")]
        [Required(ErrorMessage ="Onvane soal")]
        [MaxLength(400)]
        public string  Title { get; set; }

        [Display(Name = "Matne SOal")]
        [Required(ErrorMessage = "Matne soale")]
        public string  Body { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        public User.User User { get; set; }
        public Course.Course Course { get; set; }
        public List<Answer>  Answers{ get; set; }
    }
}
