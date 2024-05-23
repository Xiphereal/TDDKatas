using Xunit;

namespace TirePressure
{
    public class AlarmTests
    {
        [Fact]
        public void AlarmIsOffByDefault()
        {
            Alarm alarm = new Alarm();
            Assert.False(alarm.AlarmOn);
        }
    }
}