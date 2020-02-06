using System;
using System.Collections.Generic;
using System.Linq;
using ChatProj.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Web;

namespace ChatProj.DAL
{
    public interface IMessageRepository : IDisposable
    {
        IEnumerable<Message> GetMessages();
        int GetNumMessages(int numSeconds);
        void Save();
        int CountMessagesByTimeSec(int seconds, HubCallerContext hubCallerContext);
        
    }
}