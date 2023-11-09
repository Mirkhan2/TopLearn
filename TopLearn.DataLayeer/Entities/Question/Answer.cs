using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLearn.DataLayeer.Entities.Question
{
    public  class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public Question Question { get; set; }

        [Required]
        public int UserId { get; set; }

        public User.User User { get; set; }

        [Required]
        public string  BodyAnswer { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }


    }
}
