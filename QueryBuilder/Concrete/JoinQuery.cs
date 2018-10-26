using QueryBuilder.Entities;
using QueryBuilder.Interfaces;
using QueryBuilder.Resources;


namespace QueryBuilder.Concrete
{
    public class JoinQuery: IJoinQuery
    {
        public TableDefinition TableFrom { get; set; }
        public TableDefinition TableTo { get; set; }
        public JoinOperatorEnum JoinOperator { get; set; }

        //public JoinQuery(JoinOperatorEnum joinOperator, TableDefinition tableFrom, TableDefinition tableTo)
        //{
        //    this.JoinOperator = joinOperator;
        //    this.TableFrom = tableFrom;
        //    this.TableTo = tableTo;
        //}
    }
}
