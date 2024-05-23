using FluentAssertions;
using Xunit;

namespace TirePressure
{
    public class AlarmShould
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        [Fact]
        public void BeOffByDefault()
        {
            ISensor sensor = new FakeSensor();
            var alarm = new Alarm(sensor);

            alarm.On.Should().BeFalse();
        }

        [Fact]
        public void NotSetOfWithinThreshold()
        {
            FakeSensor sensor = new FakeSensor();
            sensor.AlwaysReturn(LowPressureThreshold + 1);
            var alarm = new Alarm(sensor);

            alarm.On.Should().BeFalse();
        }

        [Fact]
        public void SetOfAboveThreshold()
        {
            FakeSensor sensor = new FakeSensor();
            sensor.AlwaysReturn(HighPressureThreshold + 1);
            var alarm = new Alarm(sensor);

            alarm.Check();

            alarm.On.Should().BeTrue();
        }
    }
}