using QueryBuilder.Interfaces;


namespace QueryBuilder.Concrete
{
    public class SqlQuery: ISqlQuery
    {
        public ISelectQuery SelectQuery { get; set; }
        public IJoinQuery[] JoinQueries { get; set; }
        public IWhereQuery[] WhereQueries { get; set; }

        public SqlQuery(ISelectQuery selectQuery, IJoinQuery[] joinQueries, IWhereQuery[] whereQueries)
        {
            this.SelectQuery = selectQuery;
            this.JoinQueries = joinQueries;
            this.WhereQueries = whereQueries;
        }
    }
}