using Apache.NMS.ActiveMQ;
using Spring.Messaging.Nms.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class JMSSender
    {
        private const string URI = "tcp://192.168.43.203:61616";

        public static void Send(string message, string queue)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory(URI);
            NmsTemplate template = new NmsTemplate(connectionFactory);
            template.ConvertAndSend(queue, message);
        }
    }
}
