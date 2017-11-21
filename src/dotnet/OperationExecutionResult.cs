using System;
using System.Data;

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
    }
}