using System;

namespace TvEnhanced
{
    public class TvLG : ITV
    {
        public void On() => Console.WriteLine("LG TV is ON");
        public void Off() => Console.WriteLine("LG TV is OFF");
        public void SwitchChannel(int channel) => Console.WriteLine($"LG TV: channel {channel}");
        public void SetVolume(int volume) => Console.WriteLine($"LG TV: volume set to {volume}");
    }
}
