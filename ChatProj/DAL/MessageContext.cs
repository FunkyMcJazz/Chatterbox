using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ChatProj.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;

namespace ChatProj.DAL
{
    public class MessageContext : DbContext, IMessageContext
    {
        public IDbSet<Message> Messages { get; set; }


        public IEnumerable<Message> GetMessages()
        {
            return this.Messages.ToList();
        }

        public int GetNumMessages(int secSearch)
        {
            int messagesPM = this.Messages.Where(p => p.MessageDate > DbFunctions.AddSeconds(DateTime.Now, -secSearch)).Count();
            return messagesPM;
        }

        public int CountMessagesByTimeSec(int sec, HubCallerContext hubCallerContext)
        {
            int count = this.Messages.Where(p => p.MessageDate > DbFunctions.AddSeconds(DateTime.Now, -sec)).Where(p => p.Name == hubCallerContext.User.Identity.Name).Count();
            return count;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}