using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imitation
{
    public class Model
    {
        // async/await?
        private readonly List<StaticElement> _staticElements;
        //private readonly List<Generator> generators;
        private readonly Generator _generator;

        public Model(List<StaticElement> staticElements, Generator generator)
        {
            this._staticElements = staticElements;
            this._generator = generator;

            this.Begin();
        }
        private void Begin()
        {
            HashSet<Transact> startTransacts = _generator.GetTransacts(); // generate transacts

            Console.WriteLine("Start transacts:"); // write statistics - another method or class
            foreach (Transact transact in startTransacts)
            {
                Console.WriteLine(transact);
            }

            HashSet<Transact> regeneratedTransacts = this.Start(startTransacts); // produce transacts
            this.End(regeneratedTransacts);
        }
        private HashSet<Transact> Start(HashSet<Transact> startTransacts)
        {
            HashSet<Transact> transacts = startTransacts;
            // асинхрронно!!! прогнать каждый транзакт через элементы
            foreach (StaticElement staticElement in _staticElements)
            {
                HashSet<Transact> nextTransacts = new HashSet<Transact>();
                foreach (Transact transact in transacts)
                {
                    Transact producedTransact = staticElement.ProduceTransact(transact);
                    nextTransacts.Add(producedTransact);
                }
                transacts = nextTransacts;
            }

            return transacts;
        }

        private void End(HashSet<Transact> transacts)
        {
            Console.WriteLine("Produced transacts:"); // write statistics - another method or class
            foreach (Transact transact in transacts)
            {
                Console.WriteLine(transact);
            }
        } 
    }
}
