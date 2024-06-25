namespace DotNet
{
    // This is going to be an interface that acts as a bridge between the
    // abstraction classes and implementer classes.
    // The Implementor Interface defines the operations for all implementation
    // classes. It doesn't have to match the Abstraction's interface.
    // In fact, the two interfaces can be entirely different. 
    public interface ITv
    {
        void SwitchOn();
        void SwitchOff();
        void SetChannel(int channelNumber);
    }
}
