namespace QueryBuilder.Resources
{
    public class TableDefinition
    {
        public string TableName { get; set; }
        public string TableAlias { get; set; }
        public ColumnDefinition[] ColumnsDefinition { get; set; }

        public TableDefinition(string tableName, string tableAlias, ColumnDefinition[] columnsDefinition)
        {
            this.TableName = tableName;
            this.TableAlias = tableAlias;
            this.ColumnsDefinition = columnsDefinition;
        }
    }
}
