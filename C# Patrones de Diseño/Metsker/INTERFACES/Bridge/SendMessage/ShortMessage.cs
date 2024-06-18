using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMessage
{
    /*
    This is going to be  a concrete class which inherits from the Abstraction
    class (AbstractMessage). This Concrete Abstraction Class implements the
    operations defined by AbstractMessage class.
    */
    public class ShortMessage : AbstractMessage
    {
        //The constructor expected an argument of type object which implements the IMessageSender interface
        public ShortMessage(IMessageSender messageSender)
        {
            //Initialize the super class messageSender variable
            this.messageSender = messageSender;
        }
        public override void SendMessage(string Message)
        {
            if (Message.Length <= 10)
            {
                messageSender.SendMessage(Message);
            }
            else
            {
                Console.WriteLine("Unable to send the message as length > 10 characters");
            }
        }
    }
}