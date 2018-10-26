
using QueryBuilder.Entities;

namespace QueryBuilder.Resources
{
    public class ColumnDefinition
    {
        public int ColumnOrdinal { get; set; }
        public string ColumnName { get; set; }
        public object ColumnValue { get; set; }
        public CompareOperatorEnum ColumnComparer { get; set; } = CompareOperatorEnum.None;

        public ColumnDefinition(int columnOrdinal, string columnName, object columnValue,
            CompareOperatorEnum columnComparer) : this(columnOrdinal, columnName, columnValue)
        {
            this.ColumnComparer = columnComparer;
        }

        public ColumnDefinition(int columnOrdinal, string columnName, object columnValue) : this(columnName, columnValue)
        {
            this.ColumnOrdinal = columnOrdinal;
        }

		public ColumnDefinition(string columnName, object columnValue) : this(columnName)
        {
            this.ColumnValue = columnValue;
        }

        public ColumnDefinition(int columnOrdinal, string columnName) : this(columnName)
        {
            this.ColumnOrdinal = columnOrdinal;
        }

        public ColumnDefinition(string columnName)
        {
            this.ColumnName = columnName;
        }
    }
}
