using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imitation
{
    public class Generator
    {
        private int number = 10;
        private HashSet<Transact> transacts;

        public Generator()
        {
            while (transacts.Count < number)
            {
                transacts.Add(generateTransact());
            }
        }

        private Transact generateTransact()
        {
            return new Transact();
        }

        public HashSet<Transact> getTransacts()
        {
            return this.transacts;
        }
    }
}
