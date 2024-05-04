using System;

namespace SerializacionXML
{
    [Serializable]
    public class CAuto
    {
        private double costo;
        private string modelo;
        private CMotor motor;

        public double Costo { get => costo; set => costo = value; }
        public string Modelo { get => modelo; set => modelo = value; }

        // El get habilita a que se pueda leer el motor
        public CMotor Motor { get => motor; set => motor = value; }


        // El constructor sin parámetros que requiere la serialización
        public CAuto() { }

        public CAuto(string modelo, double costo, CMotor motor)
        {
            this.modelo = modelo;
            this.costo = costo;
            this.motor = motor;
        }

        public CAuto(string modelo, double costo, int cilindros, int hp)
        {
            this.modelo = modelo;
            this.costo = costo;
            motor = new CMotor(cilindros, hp);
        }

        public void MuestraInformacion()
        {
            Console.WriteLine("Modelo: {0}", Modelo);
            Console.WriteLine("Costo: {0}", Costo);
            motor.MuestraMotor();
        }
    }
}
