﻿using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TSQLSmellProcessor
{
    public class CreateTableProcessor
    {
        private Smells _smells;

        public CreateTableProcessor(Smells smells)
        {
            _smells = smells;
        }

        public void ProcessCreateTable(CreateTableStatement TblStmt)
        {
            bool isTemp = TblStmt.SchemaObjectName.BaseIdentifier.Value.StartsWith("#") ||
                TblStmt.SchemaObjectName.BaseIdentifier.Value.StartsWith("@");


            if (TblStmt.SchemaObjectName.SchemaIdentifier == null &&
                !isTemp
                )
            {
                _smells.SendFeedBack(27, TblStmt);
            }
            {
                foreach (ColumnDefinition colDef in TblStmt.Definition.ColumnDefinitions)
                {
                    _smells.ProcessTsqlFragment(colDef);
              
                }
            }

            if (isTemp)
            {
                foreach (ConstraintDefinition constDef in TblStmt.Definition.TableConstraints)
                {
                    if (constDef.ConstraintIdentifier != null) { }
                    switch (FragmentTypeParser.GetFragmentType(constDef))
                    {
                        case "UniqueConstraintDefinition":
                            UniqueConstraintDefinition unqConst = (UniqueConstraintDefinition)constDef;
                            if (unqConst.IsPrimaryKey)
                            {
                                _smells.SendFeedBack(38, constDef);
                            }
                            break;
                    }
                }
                foreach (ColumnDefinition colDef in TblStmt.Definition.ColumnDefinitions)
                {
                    if (colDef.DefaultConstraint != null && colDef.DefaultConstraint.ConstraintIdentifier != null)
                    {
                        _smells.SendFeedBack(39, colDef);

                    }
                    foreach (ConstraintDefinition constDef in colDef.Constraints)
                    {

                        if (constDef.ConstraintIdentifier != null) { }
                        switch (FragmentTypeParser.GetFragmentType(constDef))
                        {

                            case "CheckConstraintDefinition":
                                CheckConstraintDefinition chkConst = (CheckConstraintDefinition)constDef;
                                if (chkConst.ConstraintIdentifier != null)
                                {
                                    _smells.SendFeedBack(40, chkConst); ;

                                }
                                break;

                        }
                    }
                }
            }

        }
    }
}