using QueryBuilder.Interfaces;
using QueryBuilder.Resources;

namespace QueryBuilder.Concrete
{
    public class SelectQuery: ISelectQuery
    {
        public TableDefinition SelectFrom { get; set; }
    }
}
