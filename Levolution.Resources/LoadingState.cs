namespace Levolution.Resources
{
    /// <summary>
    /// 
    /// </summary>
    public enum LoadingState
    {
        /// <summary>
        /// Default value.
        /// No implementation or unknown.
        /// </summary>
        None,

        /// <summary>
        /// Successful.
        /// </summary>
        Success,

        /// <summary>
        /// Load failed.
        /// </summary>
        Failure,

        /// <summary>
        /// Resource not found.
        /// </summary>
        NotFound,
    }
}
