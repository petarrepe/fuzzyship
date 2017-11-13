using System;
using System.Collections.Generic;
using System.Linq;
using NenrLib.OperationsModel.Functions;
using NENRZad1;
using NENRZad1.FuzzyModel;
using NENRZad1.OperationsModel;

namespace NENRSimulator
{
    public class Rule
    {
        private IOperator op;

        private List<IFuzzySet> antecedent= new List<IFuzzySet>();
        private IFuzzySet consequent;
        private List<int> index= new List<int>();

        public Rule(IOperator op)
        {
            this.op = op;
            this.antecedent = new List<IFuzzySet>();      
        }

        public void addAntecedent(IFuzzySet antecedent, int i)
        {
            this.antecedent.Add(antecedent);
            index.Add(i);

        }

        public void addConsequent(IFuzzySet cons)
        {
            this.consequent = cons;
        }

        public IFuzzySet solveRule(int[] value)
        {
            List<double> membership = new List<double>();
            MutableFuzzySet conclusion = new MutableFuzzySet(consequent.Domain);

            //for (int i = 0; i < antecedent.Count; i++)
            //{
            //    conclusion = (MutableFuzzySet)Operations.BinaryOperation(conclusion, antecedent[i], new ZadehOr());
            //}


            //return conclusion;

            for (int i = 0; i < antecedent.Count; i++)
            {
                int element = value[index.ElementAt(i)];

                membership.Add(antecedent.ElementAt(i).ValueAt(DomainElement.Of(element)));
            }


            double bestValue = op.Calculate(membership);

            MutableFuzzySet tmp = new MutableFuzzySet(consequent.Domain);
            for(int i=0; i< consequent.Domain.Cardinality; i++)
            {
                var de = consequent.Domain.ElementForIndex(i);
                tmp.Set(de, Math.Min(bestValue, consequent.ValueAt(de)));
            }
            return tmp;

            //foreach (DomainElement de in consequent.Domain)
            //{
            //    double num = consequent.ValueAt(de);

            //    if (bestValue < num)
            //    {
            //        conclusion.Set(de, bestValue);
            //    }
            //    else
            //    {
            //        conclusion.Set(de, num);
            //    }

            //}

            //return conclusion;



        }

    }
}
