using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Imitation.StaticElement;

namespace Imitation
{
    public class Model
    {
        public Model()
        {
            Start();
        }

        public void Start()
        {
            Generator generator = new Generator(1000);
            Queue queue = new Queue();
            ServiceWindow service = new ServiceWindow(1500);
            Sink sink = new Sink();

            generator.CreationTransactEvent += queue.EnterQueue;
            queue.LeaveQueueEvent += service.EnterServiceWindow;
            service.LeaveServiceWindowEvent += sink.CollectInfo;

            generator.StartGenerator();
        }
    }
}
