using MqttExample.MQTT;

namespace MqttUnitTests
{
    [TestClass]
    public class MqttServiceTest
    {
        [TestMethod]
        public void TestMqttConnect()
        {
            MqttService mqtt_service = new MqttService("broker.hivemq.com");
            mqtt_service.Connect();
        }
    }
}