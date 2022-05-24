using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeleritySolution.Utilities.Exceptions
{
    public class CelerityExceptions : Exception
    {
        public CelerityExceptions()
        {
        }

        public CelerityExceptions(string message)
            : base(message)
        {
        }

        public CelerityExceptions(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
