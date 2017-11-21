namespace dbui
{
    /// <summary>
    /// Defines the possible operation types
    /// </summary>
    public enum OperationResultType
    {
        /// <summary>Returns the amount of affected rows</summary>
        RowCount,

        /// <summary>Returns one or more table as result</summary>
        Table,
    }
}