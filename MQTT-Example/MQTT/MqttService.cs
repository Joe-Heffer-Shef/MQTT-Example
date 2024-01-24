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
        public string Url => $"mqtt://{Domain}:{Port}";
        private readonly string Domain;
        private readonly int Port;
        public IManagedMqttClient Client;

        public MqttService(string domain, int port = 1883)
        {
            // Constructor
            this.Domain = domain;
            this.Port = port;
            this.Client = this.CreateClient();
        }
        /// <summary>
        /// Create a managed MQTT client
        /// </summary>
        /// <returns>MQTT client</returns>
        public IManagedMqttClient CreateClient()
        {
            // https://github.com/dotnet/MQTTnet/blob/master/Samples/ManagedClient/Managed_Client_Simple_Samples.cs
            var mqttFactory = new MqttFactory();
            var client = mqttFactory.CreateManagedMqttClient();

            return client;
        }
        /// <summary>
        /// Specify the options for the MQTT client.
        /// </summary>
        /// <returns>MQTT options</returns>
        public ManagedMqttClientOptions MqttClientOptions()
        {
            var mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer(this.Domain, this.Port)
                .Build();

            var Options = new ManagedMqttClientOptionsBuilder()
                .WithClientOptions(mqttClientOptions)
                .Build();

            return Options;
        }
        public void Connect(bool debug = false)
        {
            this.Client.StartAsync(this.MqttClientOptions());
        }
        public void Disconnect(bool debug = false)
        {
            this.Client.StopAsync();
        }
        //bool CreateBinder<TMessage>(string topic, BindMode bindMode, out ChannelBinder channelBinder) where TMessage : Message, new()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
