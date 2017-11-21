namespace dbui
{
    /// <summary>
    /// Defines an operation parameter
    /// </summary>
    public class OperationParameter 
    {
        /// <summary>
        /// Parameter name
        /// </summary>
        /// <remarks>Same as the parameter name used in stored procedured</remarks>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        /// Parameter description
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }

        /// <summary>
        /// Indicates if the parameter is required
        /// </summary>
        /// <returns></returns>
        public bool Required { get; set; }

        /// <summary>
        /// Indicates if the parameter value can be choosen from a list (dropdown list)
        /// </summary>
        /// <returns></returns>
        public bool IsList { get; set; }

        /// <summary>
        /// Name of the list this parameter should get values from
        /// </summary>
        /// <returns></returns>
        public string ListName { get; set; }    

    }
}