using System;
using Kyameru.Core.Entities;

namespace Kyameru.Component.RabbitMQ
{
    public class Publisher : Kyameru.Core.Contracts.IToComponent
    {
        public Publisher()
        {
        }

        public event EventHandler<Log> OnLog;

        public void Process(Routable item)
        {
            throw new NotImplementedException();
        }
    }
}
