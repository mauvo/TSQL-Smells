﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql;

using System.Diagnostics;

namespace TSQLSmellProcessor
{

    public class TSQLSmellWorker{

        
        private TSqlModel _model;
        private string _ruleID;

       public TSQLSmellWorker(SqlRuleExecutionContext context,string ruleID)
        {
            _model = context.SchemaModel;
            _ruleID = ruleID;
        }

        public IList<SqlRuleProblem> Analyze()
        {
            
            List<SqlRuleProblem> problems = new List<SqlRuleProblem>();
           
            ModelTypeClass[] ExFilter = new[]{
                ModelSchema.ExtendedProperty
            };

            List<TSqlObject>WhiteList = new List<TSqlObject>();
            
            //[SqlTableBase].[dbo].[test].[WhiteList]
            foreach (TSqlObject tSqlObject in _model.GetObjects(DacQueryScopes.UserDefined,ExFilter))
            {
                if(tSqlObject.Name.ToString().EndsWith("[WhiteList]",StringComparison.OrdinalIgnoreCase)){
                    foreach(ModelRelationshipInstance refer in tSqlObject.GetReferencedRelationshipInstances()){
                        WhiteList.Add(refer.Object);
                    }
                }
                
            }

            foreach (TSqlObject tSqlObject in _model.GetObjects(DacQueryScopes.UserDefined))
            {
                bool isWhite = false;
                foreach (TSqlObject WhiteCheck in WhiteList)
                {
                    if (WhiteCheck.Equals(tSqlObject))
                    {
                        isWhite = true;
                    }

                }
                if (isWhite) continue;

                problems.AddRange(DoSmells(tSqlObject));
               
            }
            return (problems);
        }

        private  IList<SqlRuleProblem> DoSmells(TSqlObject SqlObject)
        {

            List<SqlRuleProblem> problems = new List<SqlRuleProblem>();


            Smells smellprocess = new Smells();

            int iRule = int.Parse(_ruleID.Substring(_ruleID.Length - 3));
            return null;  //(smellprocess.ProcessObject(SqlObject, iRule));

        }


    }


    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA.RuleId,
        RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
        RuleConstants.TSQLSmell_RuleName01, // ID used to look up the display name inside the resources file
        null,
        // ID used to look up the description inside the resources file
        Category = RuleConstants.CategorySmells,
        RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML001";
        
        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA2.RuleId,
        RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
        RuleConstants.TSQLSmell_RuleName02, // ID used to look up the display name inside the resources file
        null,
        // ID used to look up the description inside the resources file
        Category = RuleConstants.CategorySmells,
        RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA2 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML002";
        
        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA3.RuleId,
        RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
        RuleConstants.TSQLSmell_RuleName03, // ID used to look up the display name inside the resources file
        null,
        // ID used to look up the description inside the resources file
        Category = RuleConstants.CategorySmells,
        RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA3 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML003";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA4.RuleId,
        RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
        RuleConstants.TSQLSmell_RuleName04, // ID used to look up the display name inside the resources file
        null,
        // ID used to look up the description inside the resources file
        Category = RuleConstants.CategorySmells,
        RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA4 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML004";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA5.RuleId,
        RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
        RuleConstants.TSQLSmell_RuleName05, // ID used to look up the display name inside the resources file
        null,
        // ID used to look up the description inside the resources file
        Category = RuleConstants.CategorySmells,
        RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA5 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML005";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA6.RuleId,
        RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
        RuleConstants.TSQLSmell_RuleName06, // ID used to look up the display name inside the resources file
        null,
        // ID used to look up the description inside the resources file
        Category = RuleConstants.CategorySmells,
        RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA6 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML006";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA07.RuleId,
        RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
        RuleConstants.TSQLSmell_RuleName07, // ID used to look up the display name inside the resources file
        null,
        // ID used to look up the description inside the resources file
        Category = RuleConstants.CategorySmells,
        RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA07 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML007";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA08.RuleId,
        RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
        RuleConstants.TSQLSmell_RuleName08, // ID used to look up the display name inside the resources file
        null,
        // ID used to look up the description inside the resources file
        Category = RuleConstants.CategorySmells,
        RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA08 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML008";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA09.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName09, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA09 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML009";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }


    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA10.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName10, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA10 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML010";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }


    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA11.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName11, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA11 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML011";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA12.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName12, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA12 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML012";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA13.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName13, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA13 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML013";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA14.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName14, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA14 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML014";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA15.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName15, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA15 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML015";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }


    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA16.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName16, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA16 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML016";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA17.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName17, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA17 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML017";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA18.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName18, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA18 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML018";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }


    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA19.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName19, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA19 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML019";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA20.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName20, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA20 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML020";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA21.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName21, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA21 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML021";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA22.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName22, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA22 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML022";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA23.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName23, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA23 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML023";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }


    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA24.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName24, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA24 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML024";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA25.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName25, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA25 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML025";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA26.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName26, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA26 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML026";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA27.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName27, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA27 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML027";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA28.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName28, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA28 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML028";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA29.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName29, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA29 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML029";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA30.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName30, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA30 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML030";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA31.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName31, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA31 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML031";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }


    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA32.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName32, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA32 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML032";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA33.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName33, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA33 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML033";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA34.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName34, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA34 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML034";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA35.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName35, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA35 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML035";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA36.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName36, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA36 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML036";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }


    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA37.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName37, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA37 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML037";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA38.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName38, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA38 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML038";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA39.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName39, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA39 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML039";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA40.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName40, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA40 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML040";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA41.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName41, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA41 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML041";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA42.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName42, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA42 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML042";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }


    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA43.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName43, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA43 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML043";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }
    
    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA44.RuleId,
    RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
    RuleConstants.TSQLSmell_RuleName44, // ID used to look up the display name inside the resources file
    null,
        // ID used to look up the description inside the resources file
    Category = RuleConstants.CategorySmells,
    RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA44 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML044";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA45.RuleId,
  RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
  RuleConstants.TSQLSmell_RuleName45, // ID used to look up the display name inside the resources file
  null,
        // ID used to look up the description inside the resources file
  Category = RuleConstants.CategorySmells,
  RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA45 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML045";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }


    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA46.RuleId,
RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
RuleConstants.TSQLSmell_RuleName46, // ID used to look up the display name inside the resources file
null,
        // ID used to look up the description inside the resources file
Category = RuleConstants.CategorySmells,
RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA46 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML046";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }


    [LocalizedExportCodeAnalysisRule(TSQLSmellSCA47.RuleId,
RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
RuleConstants.TSQLSmell_RuleName47, // ID used to look up the display name inside the resources file
null,
        // ID used to look up the description inside the resources file
Category = RuleConstants.CategorySmells,
RuleScope = SqlRuleScope.Model)] // This rule targets the whole model
    public sealed class TSQLSmellSCA47 : SqlCodeAnalysisRule
    {

        public const string RuleId = "Smells.SML047";

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext context)
        {
            TSQLSmellWorker Worker = new TSQLSmellWorker(context, RuleId);
            return (Worker.Analyze());
        }

    }

























}
