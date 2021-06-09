using System;
using Kyameru.Core.Entities;

namespace Kyameru.Component.RabbitMQ
{
    public class Consumer : Kyameru.Core.Contracts.IFromComponent
    {
        public Consumer(System.Collections.Generic.Dictionary<string, string> headers)
        {
        }

        public event EventHandler<Routable> OnAction;
        public event EventHandler<Log> OnLog;

        public void Setup()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
