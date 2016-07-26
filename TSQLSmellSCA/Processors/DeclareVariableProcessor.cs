﻿using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TSQLSmellProcessor
{
    public class DeclareVariableProcessor
    {
        private Smells _smells;

        public DeclareVariableProcessor(Smells smells)
        {
            _smells = smells;
        }

        public void ProcessDeclareVariableElement(DeclareVariableElement Element)
        {
            if (Element.VariableName.Value.Length <= 2)
            {
                _smells.SendFeedBack(33, Element);
            }
            _smells.ProcessTsqlFragment(Element.DataType);
            if (Element.Value != null) _smells.ProcessTsqlFragment(Element.Value);
        }

        public void ProcessDeclareVariableStatement(DeclareVariableStatement Statement)
        {
            foreach (DeclareVariableElement variable in Statement.Declarations)
            {
                _smells.ProcessTsqlFragment(variable);
            }
        }
    }
}