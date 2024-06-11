using System;

namespace DotNet
{
    internal class Program
    {
        static void Main()
        {
            /*
            Excepto por la fase de inicialización [en donde se obtiene un objeto
            de abstracción (es decir: SonyRemoteControl o SamsungRemoteControl)
            vinculado con un objeto de implementación específico (es decir: new
            SonyLedTv o new SamsungLedTv)] el código del cliente solo debe
            depender de la clase de abstracción (es decir: SonyRemoteControl o
            SamsungRemoteControl).
            */
            // Except for the initialization phase, where an Abstraction object
            // gets, i.e. SonyRemoteControl or SamsungRemoteControl, linked with
            // a specific Implementation object, i.e. new SonyLedTv() or new
            // SamsungLedTv(), the client code should only depend on the
            // Abstraction class, i.e. SonyRemoteControl or SamsungRemoteControl

            RemoteAbstract abstracto;

            abstracto = new RemoteSony(new TvSony());
            abstracto.SwitchOn();
            abstracto.SetChannel(101);
            abstracto.SwitchOff();
            
            Console.WriteLine();
            
            abstracto = new RemoteSamsung(new TvSamsung());
            abstracto.SwitchOn();
            abstracto.SetChannel(202);
            abstracto.SwitchOff();
            
            Console.ReadKey();
        }
    }
}