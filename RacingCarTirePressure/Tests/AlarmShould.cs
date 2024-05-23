using FluentAssertions;
using Xunit;

namespace TirePressure
{
    public class AlarmShould
    {
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
            sensor.AlwaysWithinThreshold();
            var alarm = new Alarm(sensor);

            alarm.On.Should().BeFalse();
        }
    }
}