using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Collections;
using ChatProj.Models;
using Microsoft.AspNet.SignalR;
using System.Data.Entity;
using ChatProj.Hubs;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ChatProj.DAL;
using ChatProj.Service_Layer;
using System.Globalization;
using System.Data.Entity.Core.Objects;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace SignalRChat
{   
    
    public class ChatHub : Hub
    {
        
        public ChatHub()
        {

            userService = new UserService();
        }

        public IUserService userService;

        public MessageContext messageContext = new MessageContext();


        public void Send(string message)
        {
            if (HandleCommand(message) == false)
            {
                string room = Context.QueryString["room"];
                var user = Context.User;
                //Clients.All.addNewMessageToPage(user.Identity.Name, message);
                Clients.Group(room).addNewMessageToPage(Context.User.Identity.Name, message);

                Message carrier = new Message
                {
                    Name = Context.User.Identity.Name,
                    MessageString = message,
                    MessageDate = DateTime.Now
                };

                userService.SaveMessage(carrier);
                userService.SpamCheckAndReport(Context, Clients);
            }
            }

        public override async Task OnConnected()
        {
            string room = Context.QueryString["room"];
            
            await Groups.Add(Context.ConnectionId, room);
            
            string name = Context.User.Identity.Name;
            await Groups.Add(Context.ConnectionId, name);

            if (userService.IsAdmin(Context))
            {
                await Groups.Add(Context.ConnectionId, "admingroup");
                //await Clients.Group("admingroup").addNewMessageToPage("The admin " + Context.User.Identity.Name + " has joined the chat.");
                await Clients.Group(room).addNewMessageToPage("The admin " + Context.User.Identity.Name + " has joined " + room + ".");
                {
                };   
            } 
        }
        public bool HandleCommand(string message)
        {
            /*
            var test8 = var viewPath = ((WebFormView)ViewContext.View).ViewPath;
            var test7 = ViewContext.RouteData.Values["action"];
            var test6 = ViewContext.Controller.GetType().Name;
            var test5 = ControllerContext.Controller.ValueProvider.GetValue("controller").RawValue;
            string currentActionName = ViewContext.RouteData.GetRequiredString("action");
            string currentViewName = ((WebFormView)ViewContext.View).ViewPath;
            var test4 = ViewContext.RouteData.Values["controller"];
            ActionDescriptor actionDescriptor = filterContext.ActionDescriptor;
            string actionName = actionDescriptor.ActionName;
            string controllerName = actionDescriptor.ControllerDescriptor.ControllerName;
            var test3 = ViewContext.RouteData.Values["id"].ToString();
            var test2 = ViewContext.Controller.ValueProvider.GetValue("action").RawValue;
            var test = ViewContext.RouteData.GetRequiredString("action");
            var test9 = ViewName(this HtmlHelper(new ViewContext, new IViewDataContainer);
            var test10 = ViewContext.RouteData.Values["action"];
            */
            CultureInfo ci = new CultureInfo("sv-SE");
            if (message.StartsWith("/"))
            {
                
               if(message.StartsWith("/whisper", true, ci))
                {
                    var parts = message.Substring(9).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var unParsedName = parts[0];
                    string name = unParsedName.Trim();

                    var meddelandeOformaterat = parts.Skip(1);
                    string meddelande = string.Join(" ", meddelandeOformaterat);
                    
                    if (meddelande == null)
                    {
                        return false;
                    }
                    Clients.Group(Context.User.Identity.Name).addNewMessageToPage("You" + " whisper " + name, meddelande);
                    Clients.Group(name).addNewMessageToPage(Context.User.Identity.Name + " whispers", meddelande);
                    return true;
                    
                }

               if (message.StartsWith("/help", true, ci))
               {
                   string user = Context.User.Identity.Name;
                   Clients.Group(user).addNewMessageToPage("Hello " + user , "Currently available commands are /help and /whisper *Username* *Message* . " );
                   return true;
               }

               
            }
            return false;
        }
        public void JoinGrupprum1()
        {
            Groups.Add(Context.ConnectionId, "Grupprum1");
            string a = "a";
        }
        
        
    }
}