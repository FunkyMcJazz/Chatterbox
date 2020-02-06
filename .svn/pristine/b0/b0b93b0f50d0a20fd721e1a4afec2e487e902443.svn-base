using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using ChatProj.Models;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Data.Entity;

namespace ChatProj.DAL
{
    public class MessageRepository : IMessageRepository, IDisposable
    {
        private IMessageContext context;
        private HubCallerContext hubCallerContext;

        public MessageRepository(IMessageContext context, HubCallerContext hubCallerContext)
        {
            this.context = context;
            this.hubCallerContext = hubCallerContext;
        }

        public IEnumerable<Message> GetMessages()
        {

            return context.Messages.ToList();
        
        }

        public int GetNumMessages(int secSearch)
        {
            
            int messagesPM = context.Messages.Where(p => p.MessageDate > DbFunctions.AddSeconds(DateTime.Now, - secSearch)).Count();
            return messagesPM;
        }

        public int CountMessagesByTimeSec(int sec, HubCallerContext hubCallerContext)
        {
            int count = context.Messages.Where(p => p.MessageDate > DbFunctions.AddSeconds(DateTime.Now, -sec)).Where(p => p.Name == hubCallerContext.User.Identity.Name).Count();
            return count;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}