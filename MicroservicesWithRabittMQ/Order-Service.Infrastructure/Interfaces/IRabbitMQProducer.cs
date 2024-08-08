using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Service.Infrastructure.Interfaces
{
    public interface IRabbitMQProducer
    {
        public void SendProductMessage<T>(T message);
    }
}
