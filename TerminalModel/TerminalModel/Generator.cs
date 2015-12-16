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
        private const int Number = 10;
        private HashSet<Transact> transacts;

        public Generator()
        {
            this.transacts = new HashSet<Transact>();
            while (transacts.Count < Number)
            {
                transacts.Add(GenerateTransact());
            }
        }

        private Transact GenerateTransact()
        {
            return new Transact();
        }

        public HashSet<Transact> GetTransacts()
        {
            return this.transacts;
        }
    }
}
