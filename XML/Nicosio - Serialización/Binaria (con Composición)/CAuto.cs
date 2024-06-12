using System;

namespace SerializacionBinaria
{
    [Serializable]
    public class CAuto
    {
        private double costo;
        private string modelo;
        private CMotor motor;

        public double Costo { get => costo; set => costo = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public CMotor Motor { set => motor = value; }


        // El constructor no debe tener parámetros
        public CAuto()
        {
            costo = 125000;
            modelo = "Renault";
            motor = new CMotor();
        }

        public void MuestraInformacion()
        {
            Console.WriteLine("Modelo: {0}", Modelo);
            Console.WriteLine("Costo: {0}", Costo);
            motor.MuestraMotor();
        }
    }
}
