namespace TirePressure
{
    public class FakeSensor : ISensor
    {
        private double value;

        public double PopNextPressurePsiValue()
        {
            return value;
        }

        public void AlwaysWithinThreshold()
        {
            this.value = 19;
        }
    }
}