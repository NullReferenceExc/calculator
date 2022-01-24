using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Parser
{
    public interface IValuable<T>
    {
        List<T> Values { get; }
        public T Value { get;  }
    }
}
