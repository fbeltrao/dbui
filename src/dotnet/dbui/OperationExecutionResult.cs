using System;
using System.Data;
using System.Text;

namespace dbui
{
    /// <summary>
    /// Result of an operation execution
    /// </summary>
    public class OperationExecutionResult
    {
        public int? RowCount { get; set; }

        public TimeSpan? ExecutionTime {  get; set; }

        public DataSet Data { get; set; }


        public override string ToString()
        {
            var res = new StringBuilder();

            if (ExecutionTime.HasValue)
            {
                res.AppendFormat("Executed in {0}ms\n", ExecutionTime.Value.TotalMilliseconds);                
            }

            if (RowCount.HasValue)
                res.AppendFormat("Rows affected: {0}", RowCount.Value);

            if (Data?.Tables.Count > 0)
            {
                foreach (DataTable table in Data.Tables)
                {
                    Console.WriteLine(table.TableName);
                    Console.WriteLine(table.ToStringTable());
                }
            }

            return res.ToString();

        }
    }
}