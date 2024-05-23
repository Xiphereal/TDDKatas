namespace TirePressure
{
    public class FakeSensor : ISensor
    {
        private double value;

        public double PopNextPressurePsiValue()
        {
            return value;
        }

        public void AlwaysReturn(double v)
        {
            this.value = v;
        }
    }
}