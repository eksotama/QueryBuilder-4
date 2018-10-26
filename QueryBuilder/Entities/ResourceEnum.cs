
namespace QueryBuilder.Entities
{
    public enum ConditionOperatorEnum
    {
        And = 0,
        Or = 1,
        None = 2
    }

    public enum CompareOperatorEnum
    {
        Equals = 0,
        GreaterThan = 1,
        LesserThan = 2,
        GreatherThanEquals = 3,
        LesserThanEquals = 4,
        NotEquals = 5,
        Nullable = 6,
        NotNullable = 7,
        None = 8
    }

    public enum SqlConditionEnum
    {
        Select = 1,
        Join = 2,
        Where = 3,
        Having = 4,
        OrderBy = 5,
        None = 6
    }

    public enum JoinOperatorEnum
    {
        InnerJoin = 0,
        LeftJoin = 1,
        RightJoin = 2,
        OuterJoin = 3,
        CrossJoin = 4,
        None = 5
    }
}
