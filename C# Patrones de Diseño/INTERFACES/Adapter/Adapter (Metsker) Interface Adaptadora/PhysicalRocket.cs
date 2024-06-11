namespace AdapterInterface
{
    public class PhysicalRocket
    {
        readonly double _burnArea;
        readonly double _burnRate;
        readonly double _initialFuelMass;
        readonly double _totalMass;
        readonly double _totalBurnTime;
        readonly static double SPECIFIC_IMPULSE = 620; // Newtons/Kg
        readonly static double FUEL_DENSITY = 1800; // Kg/M**3

        public PhysicalRocket(
            double burnArea,
            double burnRate,
            double fuelMass,
            double totalMass)
        {
            _burnArea = burnArea;
            _burnRate = burnRate;
            _initialFuelMass = fuelMass;
            _totalMass = totalMass;
            double _initialFuelVolume = _initialFuelMass / FUEL_DENSITY;
            _totalBurnTime = _initialFuelVolume / (_burnRate * _burnArea);
        }

        public double GetMass(double t)
        {
            if (t > _totalBurnTime) return _totalMass - _initialFuelMass;
            double burntFuelVolume = _burnRate * _burnArea * t;
            return _totalMass - burntFuelVolume * FUEL_DENSITY;
        }

        public double GetThrust(double time)
        {
            if (time > _totalBurnTime) return 0;
            return FUEL_DENSITY * SPECIFIC_IMPULSE * _burnRate * _burnArea;
        }

        public double GetBurnTime()
        {
            return _totalBurnTime;
        }
    }
}
