using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermLogic
{
    public class StateReportingYear
    {
        internal int year;

        internal StateReportingYear(int year)
        {
            this.year = year;
        }
        public StateReportingYear nextReportingYear()
        {
            return new StateReportingYear(this.year + 1);
        }
        public StateReportingYear prevReportingYear()
        {
            return new StateReportingYear(this.year - 1);
        }
        public override string ToString()
        {
            return (year - 1).ToString() + "-" + year.ToString().Substring(2, 2);
        }
        public static StateReportingYear operator +(StateReportingYear sYear, int numYears)
        {
            return sYear.doAddition(numYears);
        }
        public static StateReportingYear operator +(int numYears, StateReportingYear sYear)
        {
            return sYear.doAddition(numYears);
        }
        public StateReportingYear doAddition(int numYears)
        {
            return new StateReportingYear(this.year + numYears);
        }
        public static bool operator ==(StateReportingYear year1, StateReportingYear year2)
        {
            return year1.year == year2.year;
        }
        public static bool operator !=(StateReportingYear year1, StateReportingYear year2)
        {
            return !(year1 == year2);
        }
        public override bool Equals(object obj)
        {
            if (!(obj is StateReportingTermShort))
            {
                return false;
            }
            return this == (StateReportingYear) obj;
        }
        public override int GetHashCode()
        {
            return this.year;
        }
        public bool contains(Term term)
        {
            if (term.term == 1 || term.term == 2)
            {
                return this.year == (term.year + 1);
            }
            else
            {
                return this.year == term.year;
            }
        }
    }
    public class AcademicYear
    {
        internal int year;

        internal AcademicYear(int year)
        {
            this.year = year;
        }
        public AcademicYear nextAcademicYear()
        {
            return new AcademicYear(this.year + 1);
        }
        public AcademicYear prevAcademicYear()
        {
            return new AcademicYear(this.year - 1);
        }
        public override string ToString()
        {
            return (year - 1).ToString() + "-" + year.ToString().Substring(2, 2);
        }
        public static AcademicYear operator +(AcademicYear sYear, int numYears)
        {
            return sYear.doAddition(numYears);
        }
        public static AcademicYear operator +(int numYears, AcademicYear sYear)
        {
            return sYear.doAddition(numYears);
        }
        public AcademicYear doAddition(int numYears)
        {
            return new AcademicYear(this.year + numYears);
        }
        public static bool operator ==(AcademicYear year1, AcademicYear year2)
        {
            return year1.year == year2.year;
        }
        public static bool operator !=(AcademicYear year1, AcademicYear year2)
        {
            return !(year1 == year2);
        }
        public override bool Equals(object obj)
        {
            if (!(obj is AcademicYear))
            {
                return false;
            }
            return this == (AcademicYear)obj;
        }
        public override int GetHashCode()
        {
            return this.year;
        }
        public bool contains(Term term)
        {
            if (term.term == 1)
            {
                return this.year == (term.year + 1);
            }
            else
            {
                return this.year == term.year;
            }
        }
    }

    public abstract class Term
    {
        internal enum TermName
        {
            FALL = 1,
            SPRING = 2,
            SUMMER = 3
        }

        internal String rep;
        internal int year;
        internal int term;
        internal TermName name;
        internal StateReportingYear stateReportingYear;
        internal AcademicYear academicYear;

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
                stateReportingYear = new StateReportingYear(year + 1);
                academicYear = new AcademicYear(year + 1);
            }
            else if (term == 2)
            {
                name = TermName.SPRING;
                stateReportingYear = new StateReportingYear(year);
                academicYear = new AcademicYear(year);
            }
            else
            {
                name = TermName.SUMMER;
                stateReportingYear = new StateReportingYear(year + 1);
                academicYear = new AcademicYear(year);
            }

            makeRep();
        }
        internal abstract void makeRep();

        public static bool operator <(Term term1, Term term2)
        {
            if (term1.academicYear.year < term2.academicYear.year )
            {
                return true;
            }
            else if (term1.academicYear.year == term2.academicYear.year && term1.term < term2.term)
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
            if (term1.academicYear.year > term2.academicYear.year)
            {
                return true;
            }
            else if (term1.academicYear.year == term2.academicYear.year && term1.term > term2.term)
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
            if (object.ReferenceEquals(term1, null))
            {
                return object.ReferenceEquals(term2, null);
            }

            return term1.Equals(term2);
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
        public AcademicYear getAcademicYear()
        {
            return this.academicYear;
        }
        public StateReportingYear getStateReportingYear()
        {
            return this.stateReportingYear;
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
            return this.term == ((Term)obj).term
                && this.year == ((Term)obj).year;
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

        // ********************************************************************************
        /// <summary>
        /// Initializes a term object based on a string representation as the term would be represented in Orion.\n
        /// Terms can be compared to each other using primitive operators.<para />
        /// Terms can be incremented using integers and the primitive addition operator.<para />
        /// Terms can be subtracted from each other using the primitive subtraction operator. The result represents the number of terms between them.
        /// </summary>
        /// <param name="rep">The string representation of the term (YYYYT)</param>
        /// <returns></returns>
        /// <created>Stuart Pierson,12/9/2016</created>
        // ********************************************************************************
        public OrionTerm(String rep)
            : base((rep.Substring(4, 1) == "1" ? int.Parse(rep.Substring(0, 4)) - 1 : int.Parse(rep.Substring(0, 4))), 
            int.Parse(rep.Substring(4, 1)))
        {

        }

        internal override void makeRep()
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

        // ********************************************************************************
        /// <summary>
        /// Creates a state reporting term object based on a 3 digit string representation.
        /// Terms can be compared to each other using primitive operators.<para />
        /// Terms can be incremented using integers and the primitive addition operator.<para />
        /// Terms can be subtracted from each other using the primitive subtraction operator. The result represents the number of terms between them.
        /// </summary>
        /// <param name="rep">A String representation of the state reporting term. (YYT)</param>
        /// <returns></returns>
        /// <created>Stuart Pierson,12/9/2016</created>
        /// <changed>Stuart Pierson,12/9/2016</changed>
        // ********************************************************************************
        public StateReportingTermShort(String rep)
            : base(int.Parse(rep.Substring(1, 2)) < 49 ? int.Parse("20" + rep.Substring(1, 2)) : int.Parse("19" + rep.Substring(1, 2)),
            rep[0] == '1' ? 3 : (rep[0] == '2' ? 1 : 2))
        {

        }

        internal override void makeRep()
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

namespace Academic
{
    public class AcademicProgram
    {
        public String progCode;
        public String progName;
        public String awardType;
        public List<CatalogChange> catalogChanges;
        public Dictionary<String, CatalogChange> catalogDictionary;
        public bool financialAidApproved;

        public class CatalogChange
        {
            public String effectiveTerm;
            public String endTerm;
            public bool financialAidApproved;
            public int effectiveTermYear;
            public int effectiveTermTerm;
            public int endTermYear;
            public int endTermTerm;
            public List<Area> areas;
            public List<String> flatCourseArray;
            public Dictionary<int, Area> areaDictionary;
            public int totalProgramHours;
            public int totalGeneralEducationHours;
            public int totalCoreAndProfessionalHours;

            public class Area
            {
                public int areaNum;
                public String areaType;
                public List<Group> groups;
                public Dictionary<int, Group> groupDictionary;

                public class Group
                {
                    public int groupNum;
                    public String optCode;
                    public String operatorCode;
                    public List<Course> courses;
                    public Dictionary<String, Course> courseDictionary;

                }
            }
        }
    }

    public class Course
    {
        public String courseID;
        public float hours;

        public static float findAndSumFirstNCourses(List<Course> courses, int n)
        {
            float[] courseHours = new float[courses.Count];

            for (int i = 0; i < courseHours.Length; i++)
            {
                courseHours[i] = courses[i].hours;
            }

            return courseHours.OrderByDescending(x => x).Take(n).Sum();
        }
        // ********************************************************************************
        /// <summary>
        /// This method finds all academic programs which are effective between minTerm and maxTerm, then finds all catalog versions effective during that time
        /// and fleshes out each to define the catalog requirements for each catalog version.
        /// </summary>
        /// <typeparam name="programCode">If specified, function returns only catalog versions of this program code, pass empty string to omit</typeparam>
        /// <param name="conn">Connection to vulcan. Should be initialized before invocation</param>
        /// <param name="minTerm">OrionTerm object representing beginning term, see documentation for The TermLogic namespace 
        /// in this library for documenation regarding this class</param>
        /// <param name="maxTerm">OrionTerm object representing ending term</param>
        /// <returns></returns>
        /// <created>sjp,12/19/2016</created>
        /// <changed>sjp,12/19/2016</changed>
        // ********************************************************************************
        public static List<AcademicProgram> identifyEffectivePrograms(SqlConnection conn, TermLogic.OrionTerm minTerm, TermLogic.OrionTerm maxTerm, String programCode)
        {
            List<AcademicProgram> programs = new List<AcademicProgram>();
            Dictionary<String, AcademicProgram> programDictionary = new Dictionary<string, AcademicProgram>();
            SqlCommand comm;
            SqlDataReader reader;

            comm = new SqlCommand("SELECT DISTINCT                                                                                                                         "
                                            + "    prog.PGM_CD                                                                                                                        "
                                            + "    ,prog.AWD_TY                                                                                                                       "
                                            + "    ,prog.EFF_TRM_D                                                                                                                    "
                                            + "    ,prog.END_TRM                                                                                                                      "
                                            + "    ,proggroup.PGM_AREA                                                                                                                "
                                            + "    ,progarea.PGM_AREA_TYPE                                                                                                            "
                                            + "    ,proggroup.PGM_AREA_GROUP                                                                                                          "
                                            + "    ,proggroup.PGM_AREA_OPTN_CD                                                                                                        "
                                            + "    ,proggroup.PGM_AREA_OPTN_OPER                                                                                                      "
                                            + "    ,groupcourse.PGM_AREA_GROUP_CRS                                                                                                    "
                                            + "    ,CASE WHEN prog.AWD_TY = 'VC' THEN prog.PGM_TTL_MIN_CNTCT_HRS_REQD ELSE prog.PGM_TTL_CRD_HRS END AS HRS                            "
                                            + "    ,prog.PGM_TTL_GE_HRS_REQD                                                                                                          "
                                            + "FROM                                                                                                                                   "
                                            + "    MIS.dbo.ST_PROGRAMS_A_136 prog                                                                                                     "
                                            + "    INNER JOIN MIS.dbo.ST_PROGRAMS_A_136 progarea ON progarea.PGM_CD = prog.PGM_CD                                                     "
                                            + "	                                              AND progarea.EFF_TRM_A = prog.EFF_TRM_D                                                 "
                                            + "    INNER JOIN MIS.dbo.ST_PROGRAMS_A_136 proggroup ON proggroup.PGM_CD = prog.PGM_CD                                                   "
                                            + "	                                              AND proggroup.EFF_TRM_G = prog.EFF_TRM_D                                                "
                                            + "	                                              AND proggroup.PGM_AREA = progarea.PGM_AREA                                              "
                                            + "    INNER JOIN MIS.dbo.ST_PROGRAMS_A_PGM_AREA_GROUP_CRS_136 groupcourse ON groupcourse.ISN_ST_PROGRAMS_A = proggroup.ISN_ST_PROGRAMS_A "
                                            + "WHERE                                                                                                                                  "
                                            + "    prog.EFF_TRM_D <> ''                                                                                                               "
                                            + "    AND prog.EFF_TRM_D <= '" + maxTerm + "'                                                                                            "
                                            + "    AND (prog.END_TRM = '' OR prog.END_TRM >= '" + minTerm + "')                                                                       "
                                            + "    AND prog.AWD_TY NOT IN ('ND','NC','HS')                                                                                            "
                                            + (programCode == "" ? " " : ("   AND prog.PGM_CD = '" + programCode + "' "))
                                            + "ORDER BY                                                                                                                               "
                                            + "    prog.PGM_CD                                                                                                                        "
                                            + "    ,prog.EFF_TRM_D                                                                                                                    "
                                            + "    ,proggroup.PGM_AREA                                                                                                                "
                                            + "    ,proggroup.PGM_AREA_GROUP", conn);
            reader = comm.ExecuteReader();

            while (reader.Read())
            {
                String curProgramCode = reader["PGM_CD"].ToString();
                String effectiveTerm = reader["EFF_TRM_D"].ToString();
                String endTerm = reader["END_TRM"].ToString();
                String courseID = reader["PGM_AREA_GROUP_CRS"].ToString().Trim();
                int areaNum = int.Parse(reader["PGM_AREA"].ToString());
                int groupNum = int.Parse(reader["PGM_AREA_GROUP"].ToString());

                AcademicProgram prog;

                if (!programDictionary.ContainsKey(curProgramCode))
                {
                    prog = new AcademicProgram();
                    prog.progCode = curProgramCode;
                    prog.awardType = reader["AWD_TY"].ToString();
                    prog.catalogChanges = new List<AcademicProgram.CatalogChange>();
                    prog.catalogDictionary = new Dictionary<string, AcademicProgram.CatalogChange>();
                    programs.Add(prog);
                    programDictionary.Add(curProgramCode, prog);
                }
                else
                {
                    prog = programDictionary[curProgramCode];
                }

                AcademicProgram.CatalogChange catalog;

                if (!prog.catalogDictionary.ContainsKey(effectiveTerm))
                {
                    catalog = new AcademicProgram.CatalogChange();
                    catalog.effectiveTerm = effectiveTerm;
                    catalog.endTerm = endTerm;
                    catalog.totalProgramHours = (int)float.Parse(reader["HRS"].ToString());
                    catalog.totalGeneralEducationHours = (int)float.Parse(reader["PGM_TTL_GE_HRS_REQD"].ToString());
                    catalog.totalCoreAndProfessionalHours = catalog.totalProgramHours - catalog.totalGeneralEducationHours;
                    catalog.effectiveTermYear = int.Parse(catalog.effectiveTerm.Substring(0, 4));
                    catalog.effectiveTermTerm = int.Parse("" + catalog.effectiveTerm[4]);
                    catalog.endTermYear = catalog.endTerm != "" ? int.Parse(catalog.endTerm.Substring(0, 4)) : 9999;
                    catalog.endTermTerm = catalog.endTerm != "" ? int.Parse("" + catalog.endTerm[4]) : 9;
                    catalog.areaDictionary = new Dictionary<int, AcademicProgram.CatalogChange.Area>();
                    catalog.flatCourseArray = new List<string>();
                    prog.catalogChanges.Add(catalog);
                    prog.catalogDictionary.Add(effectiveTerm, catalog);
                    catalog.areas = new List<AcademicProgram.CatalogChange.Area>();
                }
                else
                {
                    catalog = prog.catalogDictionary[effectiveTerm];
                }

                AcademicProgram.CatalogChange.Area area;

                if (!catalog.areaDictionary.ContainsKey(areaNum))
                {
                    area = new AcademicProgram.CatalogChange.Area();
                    area.areaNum = areaNum;
                    area.areaType = reader["PGM_AREA_TYPE"].ToString();
                    area.groupDictionary = new Dictionary<int, AcademicProgram.CatalogChange.Area.Group>();
                    area.groups = new List<AcademicProgram.CatalogChange.Area.Group>();
                    catalog.areas.Add(area);
                    catalog.areaDictionary.Add(area.areaNum, area);
                }
                else
                {
                    area = catalog.areaDictionary[areaNum];
                }

                AcademicProgram.CatalogChange.Area.Group group;

                if (!area.groupDictionary.ContainsKey(groupNum))
                {

                    group = new AcademicProgram.CatalogChange.Area.Group();
                    group.groupNum = groupNum;
                    group.optCode = reader["PGM_AREA_OPTN_CD"].ToString();
                    group.operatorCode = reader["PGM_AREA_OPTN_OPER"].ToString();
                    group.courseDictionary = new Dictionary<string, Course>();
                    group.courses = new List<Course>();
                    area.groups.Add(group);
                    area.groupDictionary.Add(groupNum, group);
                }
                else
                {
                    group = area.groupDictionary[groupNum];
                }

                Course course;
                
                course = new Course();
                course.courseID = courseID;
                group.courseDictionary.Add(courseID, course);
                group.courses.Add(course);
                catalog.flatCourseArray.Add(courseID);

            }

            reader.Close();

            return programs;
        }
    }
}
