using FluentAssertions;
using Xunit;

namespace TirePressure
{
    public class AlarmTests
    {
        [Fact]
        public void AlarmIsOffByDefault()
        {
            ISensor sensor = new FakeSensor();
            var alarm = new Alarm(sensor);

            alarm.AlarmOn.Should().BeFalse();
        }
    }
}