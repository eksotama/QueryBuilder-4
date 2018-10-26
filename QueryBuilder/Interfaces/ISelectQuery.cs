using QueryBuilder.Resources;

namespace QueryBuilder.Interfaces
{
    public interface ISelectQuery
    {
        TableDefinition SelectFrom { get; set; }
    }
}
