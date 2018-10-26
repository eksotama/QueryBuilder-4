using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryBuilder.Concrete;
using QueryBuilder.Entities;
using QueryBuilder.Interfaces;
using QueryBuilder.Resources;

namespace QueryBuilder.Tests
{
	[TestClass]
	public class QueryBuilderTests
	{
		[TestMethod]
		public void TestQueryBuilder()
		{
			ISelectQuery selectQuery = new SelectQuery
			{
				SelectFrom = new TableDefinition("dbo.TableA", "tA", new[] { new ColumnDefinition("*") })
			};

			List<IWhereQuery> whereQueries = new List<IWhereQuery>
			{
					 new WhereQuery()
				  	 {
						  ColumnsDefinition = new[]
						  {
							  new ColumnDefinition(0, "tA.ColumnA", "Sahil", CompareOperatorEnum.Equals)
						  }
					 },
					 new WhereQuery()
					 {
						  ColumnsDefinition = new[]
						  {
							 new ColumnDefinition(0, "ColumnA", "Sahil", CompareOperatorEnum.Equals),
							 new ColumnDefinition(1, "ColumnB", "9901", CompareOperatorEnum.NotEquals)
						  },
					  ConditionOperator = ConditionOperatorEnum.And
					 }
			};

			List<IJoinQuery> joinQueries = new List<IJoinQuery>()
			{
					  new JoinQuery()
					  {
						 JoinOperator = JoinOperatorEnum.InnerJoin,
						 TableFrom = new TableDefinition("dbo.TableB", "tB", new[] { new ColumnDefinition("ColumnB") }),
						 TableTo = new TableDefinition("dbo.TableA", "tA", new[] { new ColumnDefinition("ColumnA") })
					  },
					  new JoinQuery()
					  {
						 JoinOperator = JoinOperatorEnum.InnerJoin,
						 TableFrom = new TableDefinition("dbo.TableB", "tB", new[] { new ColumnDefinition(0, "ColumnB2"), new ColumnDefinition(1, "ColumnB3") }),
						 TableTo = new TableDefinition("dbo.TableA", "tA", new[] { new ColumnDefinition(0, "ColumnA2"), new ColumnDefinition(1, "ColumnA3") })
					  },
					  //TODO: Test Case is Failing - columns already added in join condition, shouldn't get added again
                 new JoinQuery()
					  {
						 JoinOperator = JoinOperatorEnum.InnerJoin,
						 TableFrom = new TableDefinition("dbo.TableB", "tB", new[] { new ColumnDefinition(0, "ColumnB") }),
						 TableTo = new TableDefinition("dbo.TableA", "tA", new[] { new ColumnDefinition(0, "ColumnA") })
					  }
			};

			ISqlQuery sqlQuery = new SqlQuery(selectQuery, joinQueries.ToArray(), whereQueries.ToArray());
			var queryString = QueryComposer.GenerateQuerySql(sqlQuery);
		}
	}
}