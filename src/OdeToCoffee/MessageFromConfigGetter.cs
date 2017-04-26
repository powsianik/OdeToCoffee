﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace OdeToCoffee
{
    public interface IMessageGetter
    {
        string GetMessage();
    }

    public class MessageFromConfigGetter : IMessageGetter
    {
        private string message;

        public MessageFromConfigGetter(IConfiguration config)
        {
            this.message = config["Title"];
        }

        public string GetMessage()
        {
            return this.message;
        }
    }
}