using System.Collections.Generic;

namespace dbui
{
    public class OperationExecutionOptions
    {
        /// <summary>
        /// Indicates if the operation should be executed in preview mode only
        /// The database transaction will be rollback after the operation
        /// </summary>
        /// <returns></returns>
        public bool Preview { get; set; }


        /// <summary>
        /// Sets the parameter values
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> ParameterValues { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public OperationExecutionOptions()
        {
            this.ParameterValues = new Dictionary<string, object>();
        }

    }
}