using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imitation
{
    public class Transact
    {
        public int data;
        private int id;

        public Transact()
        {
            this.data = 0;
            Random random = new Random();
            this.id = random.Next();
        }
    }
}
