using RabbitMQ.Client;
using System.Text;

namespace SwWebServiceRabbit.Web
{
    public sealed class QueueConnector
    {
        const string QueueName = "sw";

        private static QueueConnector instance = null;
        private static readonly object @lock = new object();

        readonly IConnection _connection;
        readonly IModel _channel;

        QueueConnector()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            _connection = factory.CreateConnection(nameof(SwWebServiceRabbit));

            _channel = _connection.CreateModel();

            _channel.QueueDeclare(QueueName, false, false, false, null);
        }

        ~QueueConnector()
        {
            _channel.Dispose();
            _connection.Dispose();
        }

        public void Publish(string message)
        {
            _channel.BasicPublish("", QueueName, null, Encoding.UTF8.GetBytes(message));
        }

        public static QueueConnector Instance
        {
            get
            {
                lock (@lock)
                {
                    if (instance == null)
                    {
                        instance = new QueueConnector();
                    }

                    return instance;
                }
            }
        }
    }
}
