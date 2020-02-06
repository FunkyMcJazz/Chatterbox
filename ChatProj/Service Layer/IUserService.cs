using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using ChatProj.Models;
using ChatProj.DAL;
using System.Web;

namespace ChatProj.Service_Layer
{
    public interface IUserService
    {
        bool IsAdmin(HubCallerContext hubCallerContext);
        void SpamCheckAndReport(HubCallerContext hubCallerContext, HubConnectionContext hubConnectionContext);
        void SaveMessage(Message message);
        

    }
}