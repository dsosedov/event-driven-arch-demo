using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Net.Http;
using System.Text;

namespace SwServiceRabbit.Cli
{
    class Program
    {
        const string QueueName = "sw";

        static IModel _channel;

        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection(nameof(SwServiceRabbit)))
            {
                using (_channel = connection.CreateModel())
                {
                    _channel.QueueDeclare(QueueName, false, false, false, null);

                    var consumer = new EventingBasicConsumer(_channel);

                    consumer.Received += (model, eventArgs) => HandleReceivedMessage(model, eventArgs);

                    _channel.BasicConsume(QueueName, true, consumer);

                    Console.WriteLine($"{nameof(SwServiceRabbit)} is running...");
                    Console.ReadLine();
                }
            }
        }

        private static void HandleReceivedMessage(object model, BasicDeliverEventArgs args)
        {
            var body = args.Body;
            var message = Encoding.UTF8.GetString(body);
            var error = string.Empty;

            Toon toon;

            try
            {
                toon = JsonConvert.DeserializeObject<Toon>(message);
            }
            catch (Exception ex)
            {
                error = "- could not parse the message!";

                Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}: [{args.RoutingKey}] {message}{error}");

                return;
            }

            try
            {
                var url = string.Empty;

                switch (toon.Order)
                {
                    case Order.Jedi:
                        url = "http://localhost:51585/api/jedis";
                        break;
                    case Order.Sith:
                        url = "http://localhost:51586/api/siths";
                        break;
                }

                var client = new HttpClient();

                var response = client.PostAsync(url, new StringContent($"{{name:\"{toon.Name}\"}}", Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                _channel.BasicPublish("", QueueName, null, body);
            }

            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}: [{args.RoutingKey}] {message}{error}");
        }
    }
}
