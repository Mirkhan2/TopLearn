using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.DataLayeer.Entities.Question;

namespace TopLearn.Core.DTOs.Question
{
    public  class ShowQuestionVM
    {
        public DataLayeer.Entities.Question.Question Question { get; set; }
        public List<Answer > Answers { get; set; }
        //public ShowQuestionVM() { }
        //15Oct Update
    }
}
