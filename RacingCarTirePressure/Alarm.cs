namespace TirePressure
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;
        private ISensor sensor = new Sensor();
        private bool _alarmOn = false;
        private long _alarmCount = 0;

        public Alarm(ISensor sensor)
        {
            this.sensor = sensor;
        }

        public void Check()
        {
            double psiPressureValue = sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold
                || HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
                _alarmCount += 1;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }
    }
}