using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMessage
{
    internal class Program
    {
        static void Main()
        {
            // Except for the initialization phase, where an Abstraction object
            // i.e. LongMessage or ShortMessage linked with a specific
            // Implementation object i.e. new EmailMessageSender() or new
            // SmsMessageSender(), the client code should only depend on the
            // Abstraction class i.e. AbstractMessage 
            Console.WriteLine("Select the Message Type 1. For longmessage or 2. For shortmessage");
            int MessageType = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the message that you want to send");
            string Message = Console.ReadLine();
            if (MessageType == 1)
            {
                AbstractMessage longMessage = new LongMessage(new EmailMessageSender());
                longMessage.SendMessage(Message);
            }
            else
            {
                AbstractMessage shortMessage = new ShortMessage(new SmsMessageSender());
                shortMessage.SendMessage(Message);
            }
            Console.ReadKey();
        }
    }
}
