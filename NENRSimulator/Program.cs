using System;

namespace NENRSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int L, D, LK, DK, V, S, akcel, kormilo;
            //debug
            string[] lines = new string[500];
            int i = 0;

            IDefuzzifier coad = new COADefuzzifier();
            var akcelSy = new AkcelFuzzySystemMin(coad);
            var kormiloSy = new KormiloFuzzySystemMin(coad);

            while (true)
            {

                var str = Console.ReadLine();

                if (str[0] == 'K') break;

                String[] p = str.Split(' ');

                L = int.Parse(p[0]);
                D = int.Parse(p[1]);
                LK = int.Parse(p[2]);
                DK = int.Parse(p[3]);
                V = int.Parse(p[4]);
                S = int.Parse(p[5]);

                //L = 10;
                //D = 200;
                //LK = 300;
                //DK = 300;
                //V = 5;
                //S = 1;

                akcel = akcelSy.Solve(L, D, LK, DK, V, S);
                kormilo = kormiloSy.Solve(L, D, LK, DK, V, S);

                lines[i] = akcel + " " + kormilo + "\r\n"+L + " " + D + " " + LK + " " + DK + " ";
                i++;

                Console.Write(akcel + " " + kormilo + "\r\n ");
                Console.Out.Flush();
            }
            //debug
            System.IO.File.WriteAllLines(@"F:\ASmeceBugovito\WriteLines.txt", lines);
        }
    }
}
