using System.Collections.Generic;

namespace NENRSimulator.KnowledgeBase
{
    public class AccelerationBase : Base
    {//int L, int D, int LK, int DK, int V, int S
        // 0 ,    1,    2,      3,        4,  5
        public AccelerationBase(IOperator op)
        {
            this.oper = op;
            workingDomain = accelerationDomain;

            //Rule firstRule = new Rule(op);
            //firstRule.addAntecedent(fast, 4);
            //firstRule.addAntecedent(tooFast, 4);
            //firstRule.addConsequent(negativeAcceleration);

            Rule secondRule = new Rule(op);
            secondRule.addAntecedent(close, 0);
            secondRule.addAntecedent(close, 1);
            secondRule.addConsequent(positiveAcceleration);

            //Rule secondRule = new Rule(op);
            //secondRule.addAntecedent(close, 0);
            //secondRule.addAntecedent(close, 1);
            //secondRule.addAntecedent(close, 2);
            //secondRule.addAntecedent(close, 3);
            //secondRule.addAntecedent(fast, 4);
            //secondRule.addConsequent(negAcc);

            //Rule fourthRule = new Rule(op);
            //fourthRule.addAntecedent(close, 3);
            //fourthRule.addAntecedent(fast, 4);
            //fourthRule.addConsequent(negAcc);

            //Rule fifthRule = new Rule(op);
            //fifthRule.addAntecedent(middle, 0);
            //fifthRule.addAntecedent(middle, 1);
            //fifthRule.addAntecedent(middle, 2);
            //fifthRule.addAntecedent(middle, 3);
            //// fifthRule.addAntecedent(slow, 4);
            //fifthRule.addConsequent(positiveAcceleration);

            this.rules = new List<Rule>() { secondRule};
        }
    }
}
