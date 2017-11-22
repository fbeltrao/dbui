using System;
using System.Data.SqlClient;
using dbui;

namespace ConsoleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var operation = new Operation();
            operation.Name = "Get db server information";
            operation.Description = "Returns information about the database server";
            operation.StoredProcedureName = "dbui_serverinfo";
            operation.ResultType = OperationResultType.Table;

            var executionOptions = new OperationExecutionOptions()
            {                
            };

            
            using (var conn = new SqlConnection(""))
            {
                var operationResult = operation.Execute(conn, executionOptions);

                Console.WriteLine(operationResult.ToString());
            }
        }
    }
}
