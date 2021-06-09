using System;
using System.Collections.Generic;

namespace Kyameru.Component.RabbitMQ.MessageBus.Models
{
    /// <summary>
    /// RabbitMQ Message
    /// </summary>
    public class Message
    {
        public Message(string body)
        {
            this.Body = body;
        }

        public Dictionary<string, object> Headers { get; set; }
        public string Body { get; internal set; }
    }
}
