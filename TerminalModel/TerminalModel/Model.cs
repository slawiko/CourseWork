using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imitation
{
    public class Model
    {
        private readonly List<StaticElement> staticElements;
        private readonly List<Generator> generators;

        public Model(List<StaticElement> staticElements, List<Generator> generators)
        {
            this.staticElements = staticElements;
            this.generators = generators;

            HashSet<Transact> transacts = this.begin();
            this.start(transacts);
        }
        private HashSet<Transact> begin()
        {
            HashSet<Transact> transacts = new HashSet<Transact>();
            foreach (Generator generator in generators)
            {
                transacts.UnionWith(generator.getTransacts());
            }

            return transacts;
        }
        private void start(HashSet<Transact> transacts)
        {
            // прогнать каждый транзакт через элементы
        }
    }
}
