using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TopLearn.Core.DTOs.Question;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayeer.Context;
using TopLearn.DataLayeer.Entities.Question;

namespace TopLearn.Core.Services
{
    public class ForumService : IForumService
    {
        private TopLearnContext _context;
        public ForumService(TopLearnContext context)
        {
            _context = context;
        }

        public void AddAnser(Answer answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }

        public int AddQuestion(Question question)
        {
            question.CreateDate = DateTime.Now;
            question.ModifiedDate = DateTime.Now;
            _context.Add(question);
           _context.SaveChanges();
            return question.QuestionId;
        }

        public ShowQuestionVM ShowQuestion(int questionId)
        {
            var question = new ShowQuestionVM();
            question.Question = _context.Questions.Include(q => q.User).FirstOrDefault(q => q.QuestionId == questionId);
            question.Answers = _context.Answers.Where(a => a.QuestionId == questionId).Include(u =>u.User).ToList();
            return question;
        }

     
    }
}
