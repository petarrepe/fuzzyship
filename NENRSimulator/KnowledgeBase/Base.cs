using System.Collections.Generic;
using NenrLib.OperationsModel.Functions;
using NENRZad1;
using NENRZad1.FuzzyModel;
using NENRSimulator.Operator;
using NENRZad1.OperationsModel;

namespace NENRSimulator.KnowledgeBase
{
    public class Base
    {
        protected IOperator oper;
        public List<Rule> rules;

        protected IDomain workingDomain;
        protected IDomain rudderDomain;
        protected IDomain distanceDomain;
        protected IDomain velocityDomain;
        protected IDomain accelerationDomain;

        protected IFuzzySet close ;
        protected IFuzzySet tooClose ;
        protected IFuzzySet middle ;

        protected IFuzzySet slow  ;
        protected IFuzzySet fast  ;

        protected IFuzzySet negativeAcceleration ;
        protected IFuzzySet positiveAcceleration ;

        protected IFuzzySet hardRight ;
        protected IFuzzySet right ;
        protected IFuzzySet left ;
        protected IFuzzySet hardLeft ;
        protected IFuzzySet tooFast;
        protected IFuzzySet zeroDegrees;

        /// <summary>
        /// L - 1 do prvog, pada do drugog, onda 0
        /// Gamma - 0 do prvog, raste do drugog, onda 1
        /// Lambda - 0 do prvog, raste do drugog, pada do treceg, onda 0
        /// </summary>
        public Base()
        {
            accelerationDomain = Domain.IntRange(0, 200);
            velocityDomain = Domain.IntRange(0, 200);
            distanceDomain = Domain.IntRange(0, 1301); ;
            rudderDomain = Domain.IntRange(0, 180);

            slow = new CalculatedFuzzySet(velocityDomain, StandardFuzzySet.LFunction(10, 40)); 
            fast = new CalculatedFuzzySet(velocityDomain, StandardFuzzySet.GammaFunction(25, 50));
            tooFast = new CalculatedFuzzySet(velocityDomain, StandardFuzzySet.GammaFunction(35, 70));

            close = new CalculatedFuzzySet(distanceDomain, StandardFuzzySet.LambdaFunction(30, 70, 110));
            tooClose = new CalculatedFuzzySet(distanceDomain, StandardFuzzySet.LFunction(20, 45));
            middle = new CalculatedFuzzySet(distanceDomain, StandardFuzzySet.GammaFunction(40, 70));

            negativeAcceleration = new CalculatedFuzzySet(accelerationDomain, StandardFuzzySet.LFunction(0, 65));
            positiveAcceleration = new CalculatedFuzzySet(accelerationDomain, StandardFuzzySet.GammaFunction(55, 120));

            hardRight = new CalculatedFuzzySet(rudderDomain, StandardFuzzySet.LFunction(0, 30));
            right = new CalculatedFuzzySet(rudderDomain, StandardFuzzySet.LambdaFunction(10, 40, 70));
            left = new CalculatedFuzzySet(rudderDomain, StandardFuzzySet.LambdaFunction(100, 130, 170));
            hardLeft = new CalculatedFuzzySet(rudderDomain, StandardFuzzySet.GammaFunction(60, 90));
            zeroDegrees = new CalculatedFuzzySet(rudderDomain, StandardFuzzySet.GammaFunction(179, 180));
        }

        public IFuzzySet solveFor(int L, int D, int LK, int DK, int V, int S)
        {
            List<IFuzzySet> fuzzySets = new List<IFuzzySet>();
            int[] values = new int[6];

            values[0] = L;
            values[1] = D;
            values[2] = LK;
            values[3] = DK;
            values[4] = V;
            values[5] = S;

            foreach (Rule rule in rules)
            {
                fuzzySets.Add(rule.solveRule(values));
            }
            
            MutableFuzzySet fuzzyWorkingDomain = new MutableFuzzySet(workingDomain);
            IOperator op = new MaximumOperator();

            for (int i = 0; i < fuzzySets.Count; i++)
            {
                fuzzyWorkingDomain = (MutableFuzzySet)Operations.BinaryOperation(fuzzyWorkingDomain, fuzzySets[i], new ZadehOr());
            }

            //foreach (DomainElement de in fuzzyWorkingDomain.Domain)
            //{
            //    var doublesList = new List<double>();

            //    foreach (IFuzzySet set in fuzzySets)
            //    {
            //        doublesList.Add(set.ValueAt(de));
            //    }

            //    fuzzyWorkingDomain.Set(de, op.Calculate(doublesList));
            //}
            return fuzzyWorkingDomain;
        }

    }
}
