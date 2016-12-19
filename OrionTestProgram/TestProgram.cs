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
            

            OrionTerm j = new OrionTerm("20172");
            OrionTerm ij = new OrionTerm("20001");

            for (OrionTerm i = new OrionTerm("20001"); i < j; i++)
            {
                Console.WriteLine(i.ToString() + ":" + i.ToStateReportingTermShort().ToString() + ":" 
                    + i.getAcademicYear().ToString() + ":" + i.getStateReportingYear().ToString());                
            }

            StateReportingYear year = 1 + ij.getStateReportingYear() + 1;
          */

            OrionTerm term = new OrionTerm("20101");
            OrionTerm term1 = new OrionTerm("20172");
            
            for (OrionTerm i = term; i < term1; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("dub");

            Console.WriteLine(term);
        }
    }
}
