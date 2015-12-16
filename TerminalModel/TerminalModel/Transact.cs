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

        public Transact()
        {
            Random randomData = new Random();
            this.Data = randomData.Next(1, 20);
        }

        public override string ToString()
        {
            return "Data: " + this.Data.ToString();
        }
    }
}
