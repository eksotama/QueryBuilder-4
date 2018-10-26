using QueryBuilder.Entities;
using QueryBuilder.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryBuilder
{
    public class QueryComposer
    {
        public static string GenerateQuerySql(ISqlQuery query)
        {
            StringBuilder queryBuilder = new StringBuilder();

            var selectQuery = query.SelectQuery;
            var joinQueries = query.JoinQueries;
            var whereQueries = query.WhereQueries;
        
            queryBuilder.AppendLine($"SELECT ");
            queryBuilder.AppendLine(string.Join(",", selectQuery.SelectFrom.ColumnsDefinition.Select(x => x.ColumnName)));
            queryBuilder.AppendLine($"FROM {selectQuery.SelectFrom.TableName} {selectQuery.SelectFrom.TableAlias}");

            foreach (var joinQuery in joinQueries)
            {
                if (joinQuery.JoinOperator == Entities.JoinOperatorEnum.InnerJoin)
                    queryBuilder.AppendLine($" INNER JOIN ");
                queryBuilder.Append($" {joinQuery.TableFrom.TableName} {joinQuery.TableFrom.TableAlias}");
                queryBuilder.Append(" ON ");

                //TODO: Fix issue with duplicate join clauses.
                Dictionary<string, string> joinConditions = new Dictionary<string, string>();
                foreach (var ordinal in joinQuery.TableFrom.ColumnsDefinition.Select(x => x.ColumnOrdinal))
                {
                    //Generate unique key per condition
                    string tableFromAlias = $"{joinQuery.TableFrom.TableAlias}";
                    string tableFromColumn = $"{joinQuery.TableFrom.ColumnsDefinition.Where(x => x.ColumnOrdinal == ordinal).Select(y => y.ColumnName).FirstOrDefault()}";
                    string tableToAlias = $"{joinQuery.TableTo.TableAlias}";
                    string tableToColumn = $"{joinQuery.TableTo.ColumnsDefinition.Where(x => x.ColumnOrdinal == ordinal).Select(y => y.ColumnName).FirstOrDefault()}";
                    string joinClause = $"{tableFromAlias}.{tableFromColumn} = {tableToAlias}.{tableToColumn}";

                    if (!joinConditions.ContainsKey(joinClause))
                        joinConditions.Add(joinClause, $"{joinClause}");
                }
                queryBuilder.AppendLine(string.Join(" AND ", joinConditions.Values));
            }

			var firstClause = true;

			foreach (var whereQuery in whereQueries)
			{
				List<string> whereConditions = new List<string>();
				queryBuilder.Append(firstClause ? $"WHERE (" : $"AND (");
				foreach (var columnDef in whereQuery.ColumnsDefinition)
				{
					switch (columnDef.ColumnComparer)
					{
						case CompareOperatorEnum.Equals:
							whereConditions.Add($" {columnDef.ColumnName} == {columnDef.ColumnValue}");
							break;
						case CompareOperatorEnum.GreaterThan:
							whereConditions.Add($" {columnDef.ColumnName} > {columnDef.ColumnValue}");
							break;
						case CompareOperatorEnum.LesserThan:
							whereConditions.Add($" {columnDef.ColumnName} < {columnDef.ColumnValue}");
							break;
						case CompareOperatorEnum.GreatherThanEquals:
							whereConditions.Add($" {columnDef.ColumnName} >= {columnDef.ColumnValue}");
							break;
						case CompareOperatorEnum.LesserThanEquals:
							whereConditions.Add($" {columnDef.ColumnName} <= {columnDef.ColumnValue}");
							break;
						case CompareOperatorEnum.NotEquals:
							whereConditions.Add($" {columnDef.ColumnName} != {columnDef.ColumnValue}");
							break;
						case CompareOperatorEnum.Nullable:
							whereConditions.Add($" {columnDef.ColumnName} IS NULL");
							break;
						case CompareOperatorEnum.NotNullable:
							whereConditions.Add($" {columnDef.ColumnName} IS NOT NULL");
							break;
					}
				}

				if (whereQuery.ConditionOperator == ConditionOperatorEnum.And)
					queryBuilder.Append(string.Join(" AND", whereConditions));
				else if (whereQuery.ConditionOperator == ConditionOperatorEnum.Or)
					queryBuilder.Append(string.Join(" OR", whereConditions));
				else
					queryBuilder.Append(string.Join("", whereConditions));

				queryBuilder.AppendLine(") ");
				firstClause = false;
			}
			//TODO: Add query generation for OrderBy and Having Clauses
			return queryBuilder.ToString();
        }
    }
}
