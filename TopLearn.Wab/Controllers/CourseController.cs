﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayeer.Entities.Course;

namespace TopLearn.Wab.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _courseService;
        private IOrderService _orderService;
        private IUserService _userService;
        public CourseController(ICourseService courseService , IOrderService orderService ,IUserService userService)
        {
            _courseService = courseService;
            _orderService = orderService;
            _userService = userService;
            
        }
        public IActionResult Index(int pageId = 1, string filter = ""
            , string getType = "all", string orderByType = "date", int startPrice = 0,
            int endPrice = 0, List<int> selectedGroups = null, int take = 0 )
        {
            ViewBag.selectedGroups = selectedGroups;
            ViewBag.Groups = _courseService.GetAllGroup();
            ViewBag.pageId = pageId;
            return View(_courseService.GetCourse(pageId, filter, getType, orderByType, startPrice, endPrice, selectedGroups, 9));

        }
        [Route("ShowCourse / {id}")]
        public IActionResult ShowCourse(int id)
        {
            var course = _courseService.GetCourseForShow(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);    
        }
        [Authorize]
        public ActionResult BuyCourse(int id)
        {
            int orderId =_orderService.AddOrder(User.Identity.Name, id);
            return Redirect("/UserPanel/MyOrders/ShowOrder/" +  orderId);  
        }
        [Route("DownloadFile/{episodeId")]
        public ActionResult DownloadFile(int episodeId)
        {
            var episode = _courseService.GetEpisodeById(episodeId);
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/courseFiles/",episode.EpisodeFileName);
            string fileName = episode.EpisodeFileName;
            if (episode.IsFree)
            {
                byte[] file = System.IO.File.ReadAllBytes(filepath);
                return File(file, "application/force-download", fileName);
            }
            if (User.Identity.IsAuthenticated)
            {
                if (_orderService.IsUserInCourse(User.Identity.Name , episode.CourseId))
                {
                    byte[] file = System.IO.File.ReadAllBytes(filepath);
                    return File(file, "application / force - download", fileName);
                }
            }
            return Forbid();
        }
        
        [HttpPost]
        public IActionResult CreateComment(CourseComment comment)
        {
            comment.IsDelete = false;
            comment.Createdate = DateTime.Now;
            comment.UserId = _userService.GetUserIdByUserName(User.Identity.Name);  
            _courseService.AddComment(comment);

            return View("ShowComment" , _courseService.GetCourseComments(comment.CourseId));
        }
        public IActionResult ShowComment (int id , int pageId =1)
        {
            return View(_courseService.GetCourseComments(id , pageId));
        }
    }
}
