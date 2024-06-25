namespace DotNet
{
    //This is an abstract class that contains members that define an abstract
    //business object and its functionality. It contains a reference to an
    //object of type ILEDTV and delegates all of the real work to this object.
    //It can also act as the base class for other abstractions.
    public abstract class RemoteAbstract
    {
        // The protected keyword is a member access modifier. A protected member
        // is accessible within its class and by derived class instances.
        protected ITv ledTv;

        public abstract void SwitchOn();
        public abstract void SwitchOff();
        public abstract void SetChannel(int channelNumber);
    }
}
