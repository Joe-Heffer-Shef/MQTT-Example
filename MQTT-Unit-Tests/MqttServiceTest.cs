using MqttExample.MQTT;

namespace MqttUnitTests
{
    [TestClass]
    public class MqttServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            MqttService ms = new MqttService("broker.hivemq.com");
            ms.Connect();
        }
    }
}