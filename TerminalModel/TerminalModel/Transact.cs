using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Imitation
{
    public class Transact
    {
        public int Data;

        public Transact(Random random)
        {
            this.Data = random.Next(1, 100);
        }

        public override string ToString()
        {
            return this.Data.ToString();
        }
    }
}
