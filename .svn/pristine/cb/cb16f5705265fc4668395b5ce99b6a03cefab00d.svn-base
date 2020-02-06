using System;
using System.Collections.Generic;
using System.Linq;
using ChatProj.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using ChatProj.DAL;
using System.Web;

namespace ChatProj.Service_Layer
{
    public class UserService : IUserService
    {
        public MessageContext messageContext = new MessageContext();
        IMessageContext iMessageContext = new MessageContext();
        private HubCallerContext hubCallerContext;

        public UserService()
        {
            
            _messageRepository = new MessageRepository(iMessageContext, hubCallerContext);
        }

        private  IMessageRepository _messageRepository;

        public void SaveMessage(Message message)
        {
            iMessageContext.Messages.Add(message);
            _messageRepository.Save();
        }

        public bool IsAdmin(HubCallerContext hubCallerContext)
        {
            return hubCallerContext.User.IsInRole("admin");
        }

        public void SpamCheckAndReport(HubCallerContext hubCallerContext, HubConnectionContext hubConnectionContext)
        {
            int spamNumber = _messageRepository.CountMessagesByTimeSec(10, hubCallerContext);
            if (spamNumber > 4)
            {
                hubConnectionContext.Group("admingroup").addNewMessageToPage(hubCallerContext.User.Identity.Name + " is spamming! He's sent " + spamNumber + " messages the last 10 seconds!");
            }
        }
    }
}