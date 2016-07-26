﻿using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TSQLSmellProcessor
{
    public class OrderByProcessor
    {
        private Smells _smells;

        public OrderByProcessor(Smells smells)
        {
            _smells = smells;
        }

        private void ProcessOrderExpression(ExpressionWithSortOrder Expression)
        {
            string SubExpressionType = FragmentTypeParser.GetFragmentType(Expression.Expression);
            switch (SubExpressionType)
            {
                case "IntegerLiteral":
                    _smells.SendFeedBack(7, Expression);
                    break;
                case "CastCall":
                    var CastCall = (CastCall) Expression.Expression;
                    if (FragmentTypeParser.GetFragmentType(CastCall.Parameter) == "ColumnReferenceExpression")
                    {
                        _smells.SendFeedBack(6, Expression);
                    }
                    break;
            }
        }

        public void Process(OrderByClause OrderClause)
        {
            if (OrderClause == null) return;
            foreach (ExpressionWithSortOrder Expression in OrderClause.OrderByElements)
            {
                ProcessOrderExpression(Expression);
            }
        }
    }
}