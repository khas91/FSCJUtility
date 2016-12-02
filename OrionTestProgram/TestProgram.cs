using TermLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionTestProgram
{
    class TestProgram
    {
        static void Main(string[] args)
        {
            /*
            Dictionary<OrionTerm, String> dict = new Dictionary<OrionTerm, string>();
            OrionTerm term = new OrionTerm("20122");

            Console.WriteLine(term);

            OrionTerm term2 = new OrionTerm("20172");

            Console.WriteLine(term2);

            if (term2 > term)
            {
                Console.WriteLine(term2.ToString() + " is greater than " + term.ToString());
            }

            Console.WriteLine("20 terms after " + term + " is " + (term + 20).ToString());
        
            Console.WriteLine("After incrementing " + term + " is " + ++term);

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Iteraton " + i + ": " + term++);
            }

            term = new OrionTerm("19791");

            while (term <= term2)
            {
                term++;
                Console.WriteLine(term.ToString());
                dict.Add(term, term.ToString());
            }

            OrionTerm[] terms = new OrionTerm[dict.Keys.Count];
            dict.Keys.CopyTo(terms, 0);

            foreach (OrionTerm ter in terms)
            {
                Console.WriteLine(ter.ToString() + ": " + dict[ter]);
            }
            */
            Console.WriteLine("20001".Substring(4, 1));

            OrionTerm j = new OrionTerm("20172");
            OrionTerm ij = new OrionTerm("20001");

            while (ij < j)
            {
                Console.WriteLine(ij);
                ij++;
            }
            

/*

            OrionTerm term = new OrionTerm("19723");
            OrionTerm term1 = new OrionTerm("20172");

            while (term < term1)
            {
                Console.WriteLine(term.ToString() + ":" + term.ToStateReportingTermShort());
                term++;
            }
*/
        }
    }
}
