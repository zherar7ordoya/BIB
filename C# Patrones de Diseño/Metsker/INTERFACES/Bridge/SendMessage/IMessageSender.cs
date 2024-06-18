using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMessage
{
    /*
    This is an interface that acts as a bridge between the Abstraction Layer and
    Implementation Layer. The following Implementor Interface defines the
    operations for all implementation classes. It doesn't have to match the
    Abstraction's interface. In fact, the two interfaces are entirely different.
    */
    public interface IMessageSender
    {
        void SendMessage(string Message);
    }
}
