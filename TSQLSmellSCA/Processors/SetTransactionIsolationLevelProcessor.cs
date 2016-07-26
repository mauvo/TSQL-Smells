﻿using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TSQLSmellProcessor
{
    public class SetTransactionIsolationLevelProcessor
    {
        private Smells _smells;

        public SetTransactionIsolationLevelProcessor(Smells smells)
        {
            _smells = smells;
        }

        public void ProcessSetTransactionIolationLevelStatement(SetTransactionIsolationLevelStatement Statement)
        {
            switch (Statement.Level)
            {
                case IsolationLevel.ReadUncommitted:
                    _smells.SendFeedBack(10, Statement);
                    break;
            }
        }
    }
}