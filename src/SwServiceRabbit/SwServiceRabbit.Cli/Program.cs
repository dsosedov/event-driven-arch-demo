using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace SwServiceRabbit.Cli
{
    class Program
    {
        const string QueueName = "sw";

        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection(nameof(SwServiceRabbit)))
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(QueueName, false, false, false, null);

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, eventArgs) => HandleReceivedMessage(model, eventArgs);

                    channel.BasicConsume(QueueName, true, consumer);

                    Console.ReadLine();
                }
            }
        }

        private static void HandleReceivedMessage(object model, BasicDeliverEventArgs args)
        {
            var body = args.Body;
            var message = Encoding.UTF8.GetString(body);
            var error = string.Empty;

            try
            {
                var toon = JsonConvert.DeserializeObject<Toon>(message);
            }
            catch (Exception ex)
            {
                error = "- could not parse the message!";
            }

            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}: [{args.RoutingKey}] {message}{error}");
        }
    }
}
