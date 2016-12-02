using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TermLogic;

namespace OrionTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            for (int i = 0; i < 1000; i++)
            {
                const string chars = "0123456789";
                const string terms = "123";
                Random random = new Random();

                String year1 = new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());
                String term1 = new string(Enumerable.Repeat(terms, 4).Select(s => s[random.Next(s.Length)]).ToArray());

                String year2 = new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());
                String term2 = new string(Enumerable.Repeat(terms, 4).Select(s => s[random.Next(s.Length)]).ToArray());

                OrionTerm Orionterm1 = new OrionTerm(year1 + term1);
                OrionTerm Orionterm2 = new OrionTerm(year2 + term2);

                if (int.Parse(year1) > int.Parse(year2) && !(Orionterm1 > Orionterm2))
                {
                    throw new AssertFailedException();
                }
                if (int.Parse(year1) == int.Parse(year2) && int.Parse(term1) > int.Parse(term2) && !(Orionterm1 > Orionterm2))
                {
                    throw new AssertFailedException();
                }

                int randomInt = random.Next();

                if (Orionterm1 + randomInt < Orionterm1)
                {
                    throw new AssertFailedException();
                }
                if (randomInt + Orionterm2 < Orionterm2)
                {
                    throw new AssertFailedException();
                }
            }
        }
    }
}
