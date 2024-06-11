using System;

namespace TvEnhanced
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Usando SimpleRemote con TvSony");
            RemoteAbstract simpleRemoteSony = new SimpleRemote(new TvSony());
            simpleRemoteSony.SwitchOn();
            simpleRemoteSony.SetChannel(101);
            simpleRemoteSony.SwitchOff();

            Console.WriteLine("\nUsando AdvancedRemote con TvSony");
            AdvancedRemote advancedRemoteSony = new AdvancedRemote(new TvSony());
            advancedRemoteSony.SwitchOn();
            advancedRemoteSony.SetChannel(202);
            advancedRemoteSony.Mute();
            advancedRemoteSony.SwitchOff();

            Console.WriteLine("\nUsando AdvancedRemote con TvLG");
            AdvancedRemote advancedRemoteLG = new AdvancedRemote(new TvLG());
            advancedRemoteLG.SwitchOn();
            advancedRemoteLG.SetChannel(303);
            advancedRemoteLG.Mute();
            advancedRemoteLG.SwitchOff();

            Console.WriteLine("\nUsando SimpleRemote con TvLG");
            RemoteAbstract simpleRemoteLG = new SimpleRemote(new TvLG());
            simpleRemoteLG.SwitchOn();
            simpleRemoteLG.SetChannel(404);
            simpleRemoteLG.SwitchOff();

            Console.ReadKey();
        }
    }
}
