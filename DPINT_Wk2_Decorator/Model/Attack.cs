using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    public class Attack
    {
        public IList<string> Messages { get; private set; }
        public int Value { get; set; }

        public Attack(string message, int value)
        {
            Messages = new List<string>();
            Messages.Add(message);

            Value = value;
        }
    }
}
