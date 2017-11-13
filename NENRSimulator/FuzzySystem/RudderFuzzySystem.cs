using NENRSimulator.KnowledgeBase;
using NENRSimulator.Operator;

namespace NENRSimulator
{
    public class KormiloFuzzySystemMin : FuzzySystem
    {
        public KormiloFuzzySystemMin(IDefuzzifier defuzzifier)
        {
            this.defuzzifier = defuzzifier;
            this.knowledge=new RudderBase(new MinimumOperator());
        }

        public override int Solve(int L, int K, int LK, int DK, int V, int S)
        {
            var tmp = (defuzzifier.Defuzz(knowledge.solveFor(L, K, LK, DK, V, S)))- 90;
            return (int)tmp ;//-90
        }
    }
}
