﻿using System;

namespace DotNet
{
    // This is going to be a class which implements the ILEDTV interface and 
    // also provide the implementation details for the associated Abstraction
    // class. Each Concrete Implementation corresponds to a specific platform.

    public class TvSamsung : ITv
    {
        public void SwitchOn()
        {
            Console.WriteLine("Turning ON : Samsung TV");
        }
        public void SwitchOff()
        {
            Console.WriteLine("Turning OFF : Samsung TV");
        }
        public void SetChannel(int channelNumber)
        {
            Console.WriteLine("Setting channel Number " + channelNumber + " on Samsung TV");
        }
    }
}
