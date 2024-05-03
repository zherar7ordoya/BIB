using System;

namespace SerializacionXML
{
    [Serializable]
    public class CMotor
    {
        private int cilindros;
        private int hp;

        public int Cilindros { get => cilindros; set => cilindros = value; }
        public int HP { get => hp; set => hp = value; }

        // Para serializar, debemos tener (por regla) un constructor sin parámetros
        public CMotor() { }

        public CMotor(int cilindros, int hp)
        {
            this.cilindros = cilindros;
            this.hp = hp;
        }

        public void MuestraMotor()
        {
            Console.WriteLine("Cilindros: {0}", cilindros);
            Console.WriteLine("HP: {0}", hp);
        }
    }
}
