using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace BookSeller.EmailSender
{
    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            string queueName = "orderConfirmation";
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var customerEmail = message.Split(",")[0];
                var orderId = message.Split(",")[1];
                Console.WriteLine($"Mesaj alındı => Customer Email:{customerEmail} / OrderId:{orderId}");
                
                var result = SendEmail(customerEmail, orderId);
                Console.WriteLine(result);
            };

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
            Console.ReadLine();
        }

        public static string SendEmail(string customerEmail, string orderId)
        {
            string senderAddress = "booksellerproject@outlook.com";
            string recipientAddress = customerEmail;
            string subject = $"Sipariş Onayı : {orderId}";
            string body = $"{orderId} numaralı siparişiniz onaylanmıştır.";

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sender", senderAddress));
            message.To.Add(new MailboxAddress("Recipient", recipientAddress));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = body;
            message.Body = bodyBuilder.ToMessageBody();
            
            var client = new SmtpClient();
            client.Connect("smtp-mail.outlook.com", 587, false);
            client.Authenticate("booksellerproject@outlook.com", "bookSeller");
            client.Send(message);
            client.Disconnect(true);

            return "E-posta gönderim isteği başarıyla gönderildi.";

        }
    }
}
