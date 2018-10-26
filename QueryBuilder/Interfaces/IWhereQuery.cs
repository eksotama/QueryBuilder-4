using QueryBuilder.Entities;
using QueryBuilder.Resources;

namespace QueryBuilder.Interfaces
{
    public interface IWhereQuery
    {
        ColumnDefinition[] ColumnsDefinition { get; set; }
        ConditionOperatorEnum ConditionOperator { get; set; }
    }
}
