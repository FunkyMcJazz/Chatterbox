﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using ChatProj.DAL;
using ChatProj.Models;
using System.Data;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR.Hubs;

namespace ChatProj.Controllers
{
    public class HomeController : Controller
    {
        private IMessageRepository messageRepository;
        IMessageContext messageContext = new MessageContext();
        private HubCallerContext hubCallerContext;
        
        public HomeController()
        {
            this.messageRepository = new MessageRepository(messageContext, hubCallerContext);
        }

        public HomeController(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }
        
        
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
        public ActionResult Grupprum1()
        {
            ViewBag.Message = "Grupprum 1";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }

        public ViewResult Logg(int? page)
        {

            var messages = from s in messageRepository.GetMessages() 
                           select s;

                int pageSize = 20;
                int pageNumber = (page ?? 1);

                messages = messages.OrderByDescending(s => s.MessageDate);

            return View(messages.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ChartArrayBasic()
        {
            return View();
        }

        public ActionResult ShowChart()
        {
            return View();
        }

        public ActionResult HighChart()
        {
            return View();
        }

        public int GetNumMessagesPerSeconds(DateTime currentTime, int numSeconds)
        {
            
            return messageRepository.GetNumMessages(numSeconds);
        }
        public ActionResult DynamicView()
        {
            return View();
        }
    }
}
