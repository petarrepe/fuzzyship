using System.Collections.Generic;

namespace NENRSimulator.KnowledgeBase
{
    public class RudderBase : Base
    {
        public RudderBase(IOperator op)
        {   //int L, int D, int LK, int DK, int V, int S
            //  0 ,    1,        2,     3,    4,     5
            this.oper = op;
            workingDomain = rudderDomain;

            Rule firstRule = new Rule(op);
            firstRule.addAntecedent(tooClose, 2);
            firstRule.addConsequent(hardRight);


            Rule secondRule = new Rule(op);
            secondRule.addAntecedent(tooClose, 0);
            secondRule.addConsequent(hardRight);

            Rule thirdRule = new Rule(op);
            thirdRule.addAntecedent(tooClose, 1);
            thirdRule.addConsequent(hardLeft);

            Rule fourthRule = new Rule(op);
            fourthRule.addAntecedent(tooClose, 3);
            fourthRule.addConsequent(hardLeft);

            rules = new List<Rule>() {firstRule,  secondRule, thirdRule, fourthRule};
        }
    }
}
