﻿using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TSQLSmellProcessor
{
    public class ViewStatementProcessor
    {
        private Smells _smells;

        public ViewStatementProcessor(Smells smells)
        {
            _smells = smells;
        }

        private void TestViewReference(SchemaObjectName ObjectName)
        {
            if (ObjectName.SchemaIdentifier == null)
            {
                _smells.SendFeedBack(24, ObjectName);
            }
        }

        public void ProcessViewStatementBody(ViewStatementBody StatementBody)
        {
            TestViewReference(StatementBody.SchemaObjectName);
            new SelectStatementProcessor(_smells).Process(StatementBody.SelectStatement, "VW", true);
        }
    }
}