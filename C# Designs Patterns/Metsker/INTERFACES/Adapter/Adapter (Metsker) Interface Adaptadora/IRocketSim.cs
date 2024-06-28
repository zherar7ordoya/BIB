/*
ÉSTE CASO (EL MEJOR ESCENARIO POSIBLE)
La mejor manera de planificar la adaptación es definir las necesidades de un
programa cliente en una interfaz.

EL OTRO CASO (<== el ejemplo de Battaglia, el peor escenario posible)
Si no prevé un tipo específico de adaptación, para que otros desarrolladores
puedan crear adaptadores de objetos para su clase, coloque modificadores
virtuales en los métodos que desee permitir que las subclases anulen.
*/

namespace AdapterInterface
{
    public interface IRocketSim
    {
        double GetMass();
        double GetThrust();
        void SetSimTime(double time);
    }
}
