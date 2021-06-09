using System;
using System.Collections.Generic;
using Kyameru.Core.Contracts;

namespace Kyameru.Component.RabbitMQ
{
    public class Inflator : IOasis
    {
        

        public IAtomicComponent CreateAtomicComponent(Dictionary<string, string> headers)
        {
            throw new NotImplementedException();
        }

        public IFromComponent CreateFromComponent(Dictionary<string, string> headers, bool isAtomic)
        {
            return new Consumer(headers);
        }

        public IToComponent CreateToComponent(Dictionary<string, string> headers)
        {
            throw new NotImplementedException();
        }
    }
}
