using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.SqlServer.Dac;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;

using Microsoft.SqlServer.TransactSql;
using Microsoft.SqlServer.TransactSql.ScriptDom;

using System.IO;

using TSQLSmellProcessor;

namespace RunSCAAnalysis
{

    class SCADacpac
    {

        private static void RunAnalysis(TSqlModel model,string OutFile)
        {
            CodeAnalysisService service = new CodeAnalysisServiceFactory().CreateAnalysisService(model.Version);
            service.ResultsFile = OutFile;
            CodeAnalysisResult result = service.Analyze(model);
        }
        ﻿
        public void RunDacpacAnalysis(string packagePath,string OutFile)
        {
            using (TSqlModel model = TSqlModel.LoadFromDacpac(packagePath,
                new ModelLoadOptions(DacSchemaModelStorageType.Memory, loadAsScriptBackedModel: true)))
            {
                RunAnalysis(model,OutFile);
            }
        }

        public void RunAnalysisAgainstDatabase(string Server,string Database,string OutFile)
        {
            string extractedPackagePath = System.IO.Path.GetTempPath()+System.IO.Path.GetRandomFileName() + ".dacpac";

            DacServices services = new DacServices("Server="+Server+";Integrated Security=true;");
            services.Extract(extractedPackagePath, Database, "AppName", new Version(1, 0));

            
            RunDacpacAnalysis(extractedPackagePath,OutFile);
        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            string Server="";
            string Database="";
            string OutFile="";
            string DacPac = "";


            //TSql130Parser p1 = new Microsoft.SqlServer.TransactSql.ScriptDom.TSql130Parser(true);

            //MemoryStream stream = new MemoryStream();
            //StreamWriter writer = new StreamWriter(stream);
            //writer.Write("Select * from BLAH");
            //writer.Flush();
            //stream.Position = 0;
            //StreamReader r = new StreamReader(stream);

            //IList<ParseError> parseErrors;

            //TSql110Parser p = new TSql110Parser(true);
            //TSqlFragment frg = p.Parse(r, out parseErrors);

            doSmellsOnFile(@"C:\Users\vcirt\Source\Repos\TSQL-Smells\TSQLSmellsTest\CreateViewOrderBy.sql");

            for (int i =0;i<args.Length;i+=2)
            {
                switch (args[i]){
                    case "-S":
                        Server =args[i+1];
                        break;
                    case "-d":
                        Database = args[i + 1];
                        break;
                    case "-o":
                        OutFile = args[i + 1];
                        break;
                    case "-f":
                        DacPac = args[i + 1];
                        break;

                    case "-script":
                        {
                            StreamReader sr = new StreamReader(args[i + 1]);
                                
                        }
                        break;

                }


            }
            SCADacpac s = new SCADacpac();
            if (DacPac.Equals(""))
                s.RunAnalysisAgainstDatabase(Server, Database, OutFile);
            else
                s.RunDacpacAnalysis(DacPac, OutFile);
        }

        static void doSmellsOnFile(string FileName)
        {
            IList<ParseError> parseErrors;
            StreamReader sr = new StreamReader(FileName);
            TSql110Parser p = new TSql110Parser(true);
            TSqlFragment frg = p.Parse(sr, out parseErrors);

            Smells sml = new Smells();
            sml.SetIRule(-1);
            sml.ProcessTsqlFragment(frg);

            

        }
    }
}
