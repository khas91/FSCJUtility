# FSCJUtility

The purpose of this project is to provide utility classes for use in other projects. I'm staring with Terms. Right now terms are handled with strings. The format of those strings is very counterintuitive, not to mention inconsistent among different scenarios. When reporting data to the state, for instance, a State Reporting Term is used. For purposes of such a term, summer is called term "1", while academic terms begin with Fall. State Reporting Terms are named TYY (e.g. "316") where YY are based on the year when the term takes place.
Orion Terms (YYYYT), on the other hand, have years based on the last year in which the academic year containing the term takes place.
"20151" for instance, is Fall of the 2014-15 academic year, and hence takes place in Fall 2014.

The TermLogic namespace contains a class for both of these two types of terms, with more coming. They are derived from a common abstract class and hence can be compared with each other. The upshot of which is that new OrionTerm("20151") == new StateReportingTermShort("214") evaluates to true.

Several of the primitive operators have been overloaded and can be used in conjunction with Terms, including:
+,-,==,!=,ToString(),GetHashCode(),++,<=,>=
(Note: "+", "++" and "-" are not implemented in the base class, hence StateReportingTermShort - OrionTerm does not work but "==","!=","<=" and ">=" are so OrionTerm term1 == StateReportingTermShort term2 is valid and will evaluate true if term1 and term2 actually refer to the same time period)

In addition, although the types cannot be immediately cast into each other, the ToOrionTerm() and ToStateReportingTermShort() methods can be used to translate.
