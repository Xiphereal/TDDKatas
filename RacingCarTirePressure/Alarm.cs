namespace TirePressure
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;
        private readonly ISensor sensor;

        public Alarm(ISensor sensor)
        {
            this.sensor = sensor;
        }

        public void Check()
        {
            double psiPressureValue = this.sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold
                    || HighPressureThreshold < psiPressureValue)
                this.On = true;
        }

        public bool On { get; private set; } = false;
    }
}