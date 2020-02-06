using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ChatProj.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Web;

namespace ChatProj.DAL
{

    public interface IMessageContext : IDisposable
    {
        IDbSet<Message> Messages { get; }

        IEnumerable<Message> GetMessages();
        int GetNumMessages(int numSeconds);
        int CountMessagesByTimeSec(int seconds, HubCallerContext hubCallerContext);
        int SaveChanges();
        

    }
}