using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;


namespace MqttExample.MQTT
{
    public class MqttService
    {
        private readonly string Url;
        private readonly string Domain;
        private readonly int Port;
        private readonly IManagedMqttClient Client;
        private readonly ManagedMqttClientOptions Options;

        public MqttService(string domain, int port = 1883)
        {
            Domain = domain;
            Port = port;
            // Build URI
            Url = $"mqtt://{Domain}:{Port}";

            Client = CreateClient()

            // TODO fix this mess
        }
        static IManagedMqttClient CreateClient(string domain, int port)
        {
            var mqttFactory = new MqttFactory();
            var client = mqttFactory.CreateManagedMqttClient();
            var mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer(domain, port)
                .Build();

            var Options = new ManagedMqttClientOptionsBuilder()
                .WithClientOptions(mqttClientOptions)
                .Build();

            return client;
        }
        public void Connect(bool debug = false)
        {
            Client.StartAsync(managedMqttClientOptions);
        }
        public void Disconnect(bool debug = false)
        {
            throw new NotImplementedException();
        }
        //bool CreateBinder<TMessage>(string topic, BindMode bindMode, out ChannelBinder channelBinder) where TMessage : Message, new()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
