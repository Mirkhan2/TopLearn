using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayeer.Entities.Question;

namespace TopLearn.Wab.Controllers
{
    public class ForumController : Controller
    {
        private IForumService _forumService;
        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region Create Question

        [Authorize]
        public IActionResult CreateQuestion(int id)
        {
            Question question = new Question()
            {
                CourseId = id,
            };

            return View(question);
        }

        [HttpPost]
        public IActionResult CreateQuestion(Question question)
        {
            if (!ModelState.IsValid)
            {
                return View(question);
            }
            question.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            int questionId = _forumService.AddQuestion(question);
            return Redirect(url: $"/Forum/ShowQuestion/{questionId}");
        }
        #endregion

        #region Show Question
        public IActionResult ShowQuestion(int id)
        {
            return View(_forumService.ShowQuestion(id));
        }

        #endregion

        #region Answer

        public IActionResult Answer(int id , string body)
        {
            if (!string.IsNullOrEmpty(body))
            {
                _forumService.AddAnser(new Answer()
                {
                    BodyAnswer = body,
                    CreateDate = DateTime.Now ,
                    UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                    QuestionId = id
                });
            }
            return RedirectToAction("ShowQuestion",new {id });
        }
        #endregion
    }
}
