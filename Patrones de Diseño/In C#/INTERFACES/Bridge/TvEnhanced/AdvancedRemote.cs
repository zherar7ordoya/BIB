namespace TvEnhanced
{
    public class AdvancedRemote : RemoteAbstract
    {
        public AdvancedRemote(ITV implementor) : base(implementor) { }

        public override void SwitchOn() => implementor.On();
        public override void SwitchOff() => implementor.Off();
        public override void SetChannel(int channel) => implementor.SwitchChannel(channel);
        public void Mute() => implementor.SetVolume(0);
    }
}
