using QueryBuilder.Entities;
using QueryBuilder.Resources;


namespace QueryBuilder.Interfaces
{
    public interface IJoinQuery
    {
        TableDefinition TableFrom { get; set; }
        TableDefinition TableTo { get; set; }
        JoinOperatorEnum JoinOperator { get; set; }
      
    }
}
