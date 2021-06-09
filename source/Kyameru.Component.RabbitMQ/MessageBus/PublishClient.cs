using System;
using RabbitMQ.Client;

namespace Kyameru.Component.RabbitMQ.MessageBus
{
    /// <summary>
    /// RabbitMQ Publisher Client
    /// </summary>
    /// <remarks>
    /// This can be used as a connect and disconnect but connections in RabbitMQ
    /// are expensive and you should maintain a constant connection rather than
    /// connect and disconnect. I'll leave this option open with a warning in
    /// documentation. The choice should be there BUT advice on proper use should
    /// be thre.
    /// </remarks>
    public class PublishClient : IDisposable
    {
        private readonly IConnection rabbitMQConnection;
        private readonly IModel rabbitMQModel;
        private readonly string rabbitMQExchange;
        private readonly string appId;

        private bool disposed = false;

        public PublishClient(
            string queue,
            string exchange,
            string username,
            string password,
            string hostName = "localhost",
            string vHost = "/",
            int port = 5672,
            string appId = "Kyameru.Component.RabbitMQ")
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = hostName,
                VirtualHost = vHost,
                Port = port,
                UserName = username,
                Password = password
            };
            this.rabbitMQConnection = factory.CreateConnection();
            this.rabbitMQModel = this.rabbitMQConnection.CreateModel();
            this.rabbitMQExchange = exchange;
            this.appId = appId;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if(this.disposed)
            {
                return;
            }

            if(disposing)
            {
                this.rabbitMQModel.Dispose();
                if(this.rabbitMQConnection != null)
                {
                    this.rabbitMQConnection.Close();
                    this.rabbitMQConnection.Dispose();
                }
            }
        }

        public void Publish(string routingKey, Models.Message message)
        {
            IBasicProperties properties = this.rabbitMQModel.CreateBasicProperties();
            properties.AppId = this.appId;
            properties.Headers = message.Headers;
            byte[] body = System.Text.Encoding.UTF8.GetBytes(message.Body);

            this.rabbitMQModel.BasicPublish(
                exchange:this.rabbitMQExchange,
                body: body,
                basicProperties: properties,
                routingKey: routingKey)
        }
    }
}
