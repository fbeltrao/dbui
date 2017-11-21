using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace dbui
{
    public class Operation
    {
        /// <summary>
        /// Operation name
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        /// Operation description
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }

        /// <summary>
        /// Operation parameters
        /// </summary>
        /// <returns></returns>
        public ICollection<OperationParameter> Parameters { get; set; }
        public OperationResultType ResultType { get; private set; }

        /// <summary>
        /// Executes the 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public OperationExecutionResult Execute(IDbConnection connection, OperationExecutionOptions options)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (var parameter in this.Parameters)
            {
                if (options.ParameterValues.TryGetValue(parameter.Name, out object parameterValue))
                {
                    var dbParameter = cmd.CreateParameter();
                    dbParameter.ParameterName = string.Concat("@", parameter.Name);
                    dbParameter.Value = parameterValue;
                    cmd.Parameters.Add(dbParameter);
                }
                else 
                {
                    if (parameter.Required)
                    {
                        throw new MissingParameterException($"Value for parameter {parameter.Name} is missing");
                    }
                }
            }

            var result = new OperationExecutionResult();
            IDbTransaction transaction = null;
            try
            {
                connection.Open();

                transaction = connection.BeginTransaction();

                var stopwatch = Stopwatch.StartNew();
                if (this.ResultType == OperationResultType.RowCount)
                {
                    var rows = cmd.ExecuteNonQuery();
                    stopwatch.Stop();
                    result.RowCount = rows;                    
                }
                else
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        stopwatch.Stop();                        
                        var tableId = 1;
                        var dataSet = new DataSet();
                        while (true) 
                        {
                            var dt = new DataTable();
                            dt.TableName = $"Table_{tableId}";
                            dt.Load(reader);
                            dataSet.Tables.Add(dt);                                
                            

                            if (!reader.NextResult())
                                break;
                        }

                        result.Data = dataSet;
                    }
                }

                result.ExecutionTime = stopwatch.Elapsed;

                if (options.Preview)
                    transaction.Rollback();
                else 
                    transaction.Commit();
                
            }
            finally
            {
                connection.Close();
            

            }
            
            
            
            return null;
        }
    }
}
