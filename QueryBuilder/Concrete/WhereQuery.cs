using QueryBuilder.Entities;
using QueryBuilder.Interfaces;
using QueryBuilder.Resources;

namespace QueryBuilder.Concrete
{
    public class WhereQuery: IWhereQuery
    {
        public ColumnDefinition[] ColumnsDefinition { get; set; }
        public ConditionOperatorEnum ConditionOperator { get; set; } = ConditionOperatorEnum.None;
    }
}
