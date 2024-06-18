namespace TvEnhanced
{
    public class SimpleRemote : RemoteAbstract
    {
        public SimpleRemote(ITV implementor) : base(implementor) { }

        public override void SwitchOn() => implementor.On();
        public override void SwitchOff() => implementor.Off();
        public override void SetChannel(int channel) => implementor.SwitchChannel(channel);
    }
}
