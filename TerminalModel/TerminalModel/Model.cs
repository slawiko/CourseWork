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
            Queue queue = new Queue(0);
            Service service = new Service(1500);
            Sink sink = new Sink();

            generator.CreationTransactEvent += queue.Enter;
            queue.LeaveEvent += service.Enter;
            service.LeaveEvent += sink.CollectInfo;

            generator.StartGenerator();
        }
    }
}
