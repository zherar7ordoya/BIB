namespace DotNet
{
    // This is going to be a concrete class which inherits from the Abstraction
    // class i.e., AbstractRemoteControl. This Redefined Abstraction Class
    // extends the interface defined by AbstractRemoteControl class.
    public class RemoteSamsung : RemoteAbstract
    {
        public RemoteSamsung(ITv ledTv)
        {
            this.ledTv = ledTv;
        }
        public override void SwitchOn()
        {
            ledTv.SwitchOn();
        }
        public override void SwitchOff()
        {
            ledTv.SwitchOff();
        }
        public override void SetChannel(int channelNumber)
        {
            ledTv.SetChannel(channelNumber);
        }
    }
}
