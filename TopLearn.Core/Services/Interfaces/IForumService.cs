using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.Core.DTOs.Question;
using TopLearn.DataLayeer.Entities.Question;

namespace TopLearn.Core.Services.Interfaces
{
    public  interface IForumService
    {

        #region Question
        //add
        int AddQuestion(Question question);
        //qabeliat jdid view Model 
        ShowQuestionVM ShowQuestion(int questionId);

        #endregion

        #region Answer
        void AddAnser(Answer answer);

        #endregion
    }
}
