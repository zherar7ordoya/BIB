using System;

namespace ABS
{
    public interface ICalculatorView
    {
        int FirstNumber { get; }
        int SecondNumber { get; }
        int Result { set; }
        event EventHandler CalculateClicked;
    }
}
