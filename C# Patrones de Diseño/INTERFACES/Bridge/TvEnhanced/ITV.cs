namespace TvEnhanced
{
    public interface ITV
    {
        void On();
        void Off();
        void SwitchChannel(int channel);
        void SetVolume(int volume);
    }

}
