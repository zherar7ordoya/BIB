using System;

namespace SerializacionBinaria
{
    [Serializable]
    public class CMotor
    {
        private int cilindros;
        private int hp;

        public int Cilindros { get => cilindros; set => cilindros = value; }
        public int HP { get => hp; set => hp = value; }

        public CMotor()
        {
            cilindros = 4;
            hp = 200;
        }

        public void MuestraMotor()
        {
            Console.WriteLine("Cilindros: {0}", cilindros);
            Console.WriteLine("HP: {0}", hp);
        }
    }
}
