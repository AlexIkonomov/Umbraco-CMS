﻿using NPoco;
using Umbraco.Core.Persistence.DatabaseModelDefinitions;

namespace Umbraco.Core.Migrations.Expressions.Delete.Expressions
{
    public class DeleteIndexExpression : MigrationExpressionBase
    {
        public DeleteIndexExpression(IMigrationContext context, DatabaseType[] supportedDatabaseTypes)
            : base(context, supportedDatabaseTypes)
        {
            Index = new IndexDefinition();
        }

        public DeleteIndexExpression(IMigrationContext context, DatabaseType[] supportedDatabaseTypes, IndexDefinition index)
            : base(context, supportedDatabaseTypes)
        {
            Index = index;
        }

        public IndexDefinition Index { get; }

        public override string ToString() // fixme kill
            => GetSql();

        protected override string GetSql()
        {
            return string.Format(SqlSyntax.DropIndex,
                SqlSyntax.GetQuotedName(Index.Name),
                SqlSyntax.GetQuotedTableName(Index.TableName));
        }
    }
}