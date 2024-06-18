using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMessage
{
    /*
    This is going to be a concrete class that inherits from the Abstraction
    class (AbstractMessage). This Concrete Abstraction Class implements the
    operations defined by AbstractMessage class.
    */
    public class LongMessage : AbstractMessage
    {
        public LongMessage(IMessageSender messageSender)
        {
            //Initialize the super class messageSender variable
            this.messageSender = messageSender;
        }
        public override void SendMessage(string Message)
        {
            messageSender.SendMessage(Message);
        }
    }
}
