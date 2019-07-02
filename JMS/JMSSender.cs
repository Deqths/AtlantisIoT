using Apache.NMS.ActiveMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Messaging.Nms.Core;
using System.Threading.Tasks;

namespace JMS
{
    class JMSSender
    {
        private const string URI = "tcp://192.168.9.129:61616";
        private const string RequestInfo = "RequestInfo";
        private const string Answer = "Answer";
        private const string Metrics = "Metrics";
        private const string Command = "Command";

        public static void Send(string message, string queue)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory(URI);
            NmsTemplate template = new NmsTemplate(connectionFactory);
            template.ConvertAndSend(queue, message);
        }
    }
}
