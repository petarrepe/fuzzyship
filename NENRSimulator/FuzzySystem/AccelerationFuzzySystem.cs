using NENRSimulator.KnowledgeBase;
using NENRSimulator.Operator;

namespace NENRSimulator
{
    public class AkcelFuzzySystemMin :FuzzySystem
    {
        public AkcelFuzzySystemMin(IDefuzzifier defuzzifier)
        {
            this.defuzzifier = defuzzifier;
            this.knowledge = new AccelerationBase(new MinimumOperator());
        }

        public override int Solve(int L, int K, int LK, int DK, int V, int S)
        {
            return (int)defuzzifier.Defuzz((knowledge.solveFor(L, K, LK, DK, V, S)));
        }
    }
}
