﻿using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TSQLSmellProcessor
{
    public class SelectFunctionReturnTypeProcessor
    {
        private Smells _smells;

        public SelectFunctionReturnTypeProcessor(Smells smells)
        {
            _smells = smells;
        }

        public void ProcessSelectFunctionReturnType(SelectFunctionReturnType ReturnType)
        {
            _smells.ProcessTsqlFragment(ReturnType.SelectStatement);
        }
    }
}