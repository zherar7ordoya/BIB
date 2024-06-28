namespace AdapterInterface
{
    public class OozinozRocket : PhysicalRocket, IRocketSim
    {
        public OozinozRocket
            (
            double burnArea,
            double burnRate,
            double fuelMass,
            double totalMass
            )
            : base(burnArea, burnRate, fuelMass, totalMass)
        {
        }

        private double _time;

        public double GetMass() => GetMass(_time);

        public double GetThrust() => GetThrust(_time);

        public void SetSimTime(double time) => _time = time;
    }
}
