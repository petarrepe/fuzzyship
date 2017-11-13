using System.Collections.Generic;

namespace NENRSimulator
{
    public interface IOperator
    {
        double Calculate(List<double> values);
    }
}
