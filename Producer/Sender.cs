using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    class Sender
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("Basic", exclusive: false);

                    var message = "Getting started with .NET Core & RabbitMQ";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish("", "Basic", null, body);
                    Console.WriteLine("Sent message: {0}", message);
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
