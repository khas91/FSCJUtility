using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermLogic
{    
    public abstract class Term
    {
        protected enum TermName
        {
            FALL,
            SPRING,
            SUMMER
        }

        protected String rep;
        protected int year;
        protected int term;
        protected TermName name;

        public Term(int year, int term)
        {
            int[] terms = new int[] { 1, 2, 3 };

            if (!terms.Contains(term))
            {
                throw new ArgumentException();
            }

            this.year = year;
            this.term = term;

            if (term == 1)
            {
                name = TermName.FALL;
            }
            else if (term == 2)
            {
                name = TermName.SPRING;
            }
            else
            {
                name = TermName.SUMMER;
            }

            makeRep();
        }
        public abstract void makeRep();
        public static bool operator <(Term term1, Term term2)
        {
            if (term1.year < term2.year)
            {
                return true;
            }
            else if (term1.year == term2.year && term1.term < term2.term)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >(Term term1, Term term2)
        {
            if (term1.year > term2.year)
            {
                return true;
            }
            else if (term1.year == term2.year && term1.term > term2.term)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator ==(Term term1, Term term2)
        {
            return (term1.year == term2.year) && (term1.term == term2.term);
        }
        public static bool operator !=(Term term1, Term term2)
        {
            return !(term1 == term2);
        }
        public static bool operator <=(Term term1, Term term2)
        {
            return (term1 < term2) || (term1 == term2);
        }
        public static bool operator >=(Term term1, Term term2)
        {
            return (term1 > term2) || (term1 == term2);
        }
        public override string ToString()
        {
            makeRep();
            return rep;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Term))
            {
                return false;
            }
            return this == (Term)obj;
        }
        public override int GetHashCode()
        {
            return this.year * 10 + this.term;
        }
    }

    public class OrionTerm : Term
    {
        internal OrionTerm(int year, int term)
            : base(year, term)
        {

        }

        public OrionTerm(String rep)
            : base((rep.Substring(4, 1) == "1" ? int.Parse(rep.Substring(0, 4)) - 1 : int.Parse(rep.Substring(0, 4))), 
            int.Parse(rep.Substring(4, 1)))
        {

        }

        public override void makeRep()
        {
            if (name == TermName.FALL)
            {
                this.rep = (this.year + 1).ToString() + this.term;
            }
            else
            {
                this.rep = this.year.ToString() + this.term.ToString();
            }
        }

        public static OrionTerm operator +(OrionTerm term, int numTerms)
        {
            return term.doAddition(numTerms);
        }
        public static OrionTerm operator +(int numTerms, OrionTerm term)
        {
            return term.doAddition(numTerms);
        }
        public static OrionTerm operator ++(OrionTerm term)
        {
            return term.doAddition(1);
        }
        protected OrionTerm doAddition(int numTerms)
        {
            if (numTerms < 0)
            {
                throw new ArgumentException();
            }

            int term = this.term;
            int year = this.year;

            while (numTerms > 0)
            {
                if (term == 3)
                {
                    term = 1;
                }
                else if (term == 1)
                {
                    term++;
                    year++;
                }
                else {
                    term++;
                }
                numTerms--;
            }

            return new OrionTerm(year, term);
        }
        public static int operator -(OrionTerm term1, OrionTerm term2)
        {
            OrionTerm largerTerm = term1 > term2 ? term1 : term2;
            OrionTerm smallerTerm = term1 > term2 ? term2 : term1;

            int largerYear = largerTerm.year;
            int largerTermTerm = largerTerm.term;
            int smallerYear = smallerTerm.year;
            int smallerTermTerm = smallerTerm.term;

            int difference = 0;

            while (largerYear != smallerYear || smallerTermTerm != largerTermTerm)
            {
                if (largerTermTerm == 1)
                {
                    largerTermTerm = 3;
                }
                else if (largerTermTerm == 2)
                {
                    largerTermTerm--;
                    largerYear--;
                }
                else
                {
                    largerTermTerm--;
                }

                difference++;
            }

            return difference;
        }
        public StateReportingTermShort ToStateReportingTermShort()
        {
            return new StateReportingTermShort(this.year, this.term);
        }        
    }
    public class StateReportingTermShort : Term
    {
        internal StateReportingTermShort(int year, int term)
            : base(year, term)
        {

        }

        public StateReportingTermShort(String rep)
            : base(int.Parse(rep.Substring(1, 2)) < 49 ? int.Parse("20" + rep.Substring(1, 2)) : int.Parse("19" + rep.Substring(1, 2)),
            rep[0] == '1' ? 3 : (rep[0] == '2' ? 1 : 2))
        {

        }

        public override void makeRep()
        {
            if (this.name == TermName.SUMMER)
            {
                this.rep = "1" + this.year.ToString().Substring(2, 2);
            }
            else if (this.name == TermName.FALL)
            {
                this.rep = "2" + this.year.ToString().Substring(2, 2);
            }
            else
            {
                this.rep = "3" + this.year.ToString().Substring(2, 2);
            }
        }

        protected StateReportingTermShort doAddition(int numTerms)
        {
            if (numTerms < 0)
            {
                throw new ArgumentException();
            }

            int term = this.term;
            int year = this.year;

            while (numTerms > 0)
            {
                if (term == 3)
                {
                    term = 1;
                }
                else if (term == 1)
                {
                    term++;
                }
                else
                {
                    term++;
                    year++;
                }
                numTerms--;
            }

            return new StateReportingTermShort(year, term);
        }
        public static int operator -(StateReportingTermShort term1, StateReportingTermShort term2)
        {
            StateReportingTermShort largerTerm = term1 > term2 ? term1 : term2;
            StateReportingTermShort smallerTerm = term1 > term2 ? term2 : term1;

            int largerYear = largerTerm.year;
            int largerTermTerm = largerTerm.term;
            int smallerYear = smallerTerm.year;
            int smallerTermTerm = smallerTerm.term;

            int difference = 0;

            while (largerYear != smallerYear && smallerTermTerm != largerTermTerm)
            {
                if (largerTermTerm == 1)
                {
                    largerTermTerm = 3;
                }
                else if (largerTermTerm == 2)
                {
                    largerTermTerm--;
                    largerYear--;
                }
                else
                {
                    largerTermTerm--;
                }

                difference++;
            }

            return difference;
        }
        public OrionTerm ToOrionTerm()
        {
            return new OrionTerm(this.year, this.term);
        }
    }

}

