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
            Service service = new Service(1500);
            Sink sink = new Sink();

            generator.CreationTransactEvent += queue.EnterQueue;
            queue.LeaveQueueEvent += service.EnterService;
            service.LeaveServiceEvent += sink.CollectInfo;

            generator.StartGenerator();
        }
    }
}
