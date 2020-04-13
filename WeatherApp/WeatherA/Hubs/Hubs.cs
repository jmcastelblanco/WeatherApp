﻿
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Configuration;

namespace WeatherA.Hubs
{


    public class MessagesHub : Hub
    {
        private static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        public void Hello()
        {
            Clients.All.hello();
        }

        [HubMethodName("sendMessages")]
        public static void SendMessages()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MessagesHub>();
            Console.WriteLine("yeah of fire");
            context.Clients.All.updateMessages();
        }
    }
}