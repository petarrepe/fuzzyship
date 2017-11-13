using NENRZad1;
using NENRZad1.FuzzyModel;

namespace NENRSimulator
{
    public class COADefuzzifier : IDefuzzifier
    {
        public double Defuzz(IFuzzySet fuzzySet)
        {
            double num = 0;
            double dem = 0;
            foreach (DomainElement  de in fuzzySet.Domain)
            {
                num += fuzzySet.ValueAt(de) * de.ComponentValue(0);
                dem += fuzzySet.ValueAt(de);
            }

            return num / dem;
        }

    }
}
