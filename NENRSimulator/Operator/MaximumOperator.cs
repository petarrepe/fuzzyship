using System.Collections.Generic;
using System.Linq;

namespace NENRSimulator.Operator
{
    public class MaximumOperator : IOperator
    {
        public double Calculate(List<double> values)
        {
            return values.Max();
        }
    }
}
