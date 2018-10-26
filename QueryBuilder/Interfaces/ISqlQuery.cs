namespace QueryBuilder.Interfaces
{
    public interface ISqlQuery 
    {
        ISelectQuery SelectQuery { get; set; }
        IJoinQuery[] JoinQueries { get; set; }
        IWhereQuery[] WhereQueries { get; set; }

    }
}
