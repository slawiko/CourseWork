using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imitation.StaticElement;

namespace Imitation
{
    public class Model
    {
        public Model(double creationInterval, double serviceTime)
        {
            Generator generator = new Generator(creationInterval);
            Queue queue = new Queue();
            ServiceWindow service = new ServiceWindow(serviceTime);
            Sink sink = new Sink();

            generator.CreationTransactEvent += queue.EnterQueue;
            queue.LeaveQueueEvent += service.EnterServiceWindow;
            service.LeaveServiceWindowEvent += sink.CollectInfo;

            generator.StartGenerator();
        }
    }
}
