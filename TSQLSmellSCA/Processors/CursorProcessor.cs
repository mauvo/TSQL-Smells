﻿using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TSQLSmellProcessor
{
    public class CursorProcessor
    {
        private Smells _smells;

        public CursorProcessor(Smells smells)
        {
            _smells = smells;
        }

        public void ProcessCursorStatement(DeclareCursorStatement CursorStatement)
        {
            if (CursorStatement.CursorDefinition == null || CursorStatement.CursorDefinition.Options.Count == 0)
            {
                _smells.SendFeedBack(29, CursorStatement);
            }
        }
    }
}