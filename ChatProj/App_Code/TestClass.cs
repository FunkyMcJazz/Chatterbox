using System;
using System.Collections.Generic;
using System.Linq;
using ChatProj.Hubs;
using ChatProj.Service_Layer;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRChat;

namespace ChatProj.App_Code
{
    public class TestClass
    {
        public void TestMethod()
        {
            ChatHub test = new ChatHub();
            //var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            test.JoinGrupprum1();
        }
    }
}