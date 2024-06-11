using System;

namespace TvEnhanced
{
    public class TvSony : ITV
    {
        public void On() => Console.WriteLine("Sony TV is ON");
        public void Off() => Console.WriteLine("Sony TV is OFF");
        public void SwitchChannel(int channel) => Console.WriteLine($"Sony TV: channel {channel}");
        public void SetVolume(int volume) => Console.WriteLine($"Sony TV: volume set to {volume}");
    }
}
