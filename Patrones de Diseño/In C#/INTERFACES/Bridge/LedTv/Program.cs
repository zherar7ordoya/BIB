using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            AbstractRemoteControl sonyRemoteControl = new SonyRemoteControl(new SonyLedTv());
            sonyRemoteControl.SwitchOn();
            sonyRemoteControl.SetChannel(101);
            sonyRemoteControl.SwitchOff();
            Console.WriteLine();
            AbstractRemoteControl samsungRemoteControl = new SamsungRemoteControl(new SamsungLedTv());
            samsungRemoteControl.SwitchOn();
            samsungRemoteControl.SetChannel(202);
            samsungRemoteControl.SwitchOff();
            Console.ReadKey();
        }
    }
}