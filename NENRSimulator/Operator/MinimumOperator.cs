using System.Collections.Generic;
using System.Linq;

namespace NENRSimulator.Operator
{
    public class MinimumOperator : IOperator
    {
        public double Calculate(List<double> values)
        {
            return values.Min();
        }
    }
}
