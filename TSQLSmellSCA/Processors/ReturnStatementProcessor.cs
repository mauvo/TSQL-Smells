using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TSQLSmellProcessor
{
    public class ReturnStatementProcessor
    {
        private Smells _smells;

        public ReturnStatementProcessor(Smells smells)
        {
            _smells = smells;
        }

        public void ProcessReturnStatement(ReturnStatement ReturnStatement)
        {
            if (ReturnStatement.Expression != null) _smells.ProcessTsqlFragment(ReturnStatement.Expression);
        }
    }
}