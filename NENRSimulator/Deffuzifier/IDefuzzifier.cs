using NENRZad1.FuzzyModel;

namespace NENRSimulator
{
    public interface IDefuzzifier
    {
        double Defuzz(IFuzzySet fuzzySet);
    }
}
