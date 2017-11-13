using NENRSimulator.KnowledgeBase;

namespace NENRSimulator
{
    public abstract class FuzzySystem
    {
        protected IDefuzzifier defuzzifier;
        public Base knowledge;
        public abstract int Solve(int L, int K, int LK, int DK, int V, int S);
    }
}
