using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSQLSmellProcessor;
using System.IO;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Resources;

namespace RunTSQLSmells
{
    class Program
    {
        static void Main(string[] args)
        {
            string FileName = args[0];

            IList<ParseError> parseErrors;
            StreamReader sr = new StreamReader(FileName);
            TSql110Parser p = new TSql110Parser(true);
            TSqlFragment frg = p.Parse(sr, out parseErrors);

            Smells sml = new Smells();
            sml.SetIRule(-1);
            sml.ProcessTsqlFragment(frg);


            ResourceManager rm = sml.GetResourceManager();
            //  TODO 
            //           string lookup = "TSQLSmell_RuleName" + errorNum.ToString("D2");
            //           string Out = rm.GetString(lookup);
            foreach (var fb in sml._FeedbackList)
            {
                string lookup = "TSQLSmell_RuleName" + fb._ProblemNo.ToString("D2");
                string Out = rm.GetString(lookup);
               
                Console.WriteLine("Problem {0} Found at ln {1} col {2}", fb._ProblemNo, fb.frg.StartLine, frg.StartColumn);
                Console.WriteLine(Out);
                Console.WriteLine("---");
            }



        }
    }
}
