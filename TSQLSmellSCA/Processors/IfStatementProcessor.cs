﻿using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TSQLSmellProcessor
{
    public class IfStatementProcessor
    {
        private Smells _smells;

        public IfStatementProcessor(Smells smells)
        {
            _smells = smells;
        }

        public void ProcessIfStatement(IfStatement IfStatement)
        {
            _smells.ProcessTsqlFragment(IfStatement.Predicate);
            _smells.ProcessTsqlFragment(IfStatement.ThenStatement);
            if (IfStatement.ElseStatement != null) _smells.ProcessTsqlFragment(IfStatement.ElseStatement);
        }
    }
}