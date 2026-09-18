namespace EventCountdownBackend.Common.Results
{
    public enum MutationStatus
    {
        Success,
        NotFound,
        Forbidden
    }

    /// <summary>
    /// Represents the outcome of an entity mutation operation,
    /// distinguishing between success, not found, and authorization failure.
    /// </summary>
    /// <typeparam name="T">The type of data returned on a successful operation.</typeparam>
    /// <param name="Status">The Status of the request</param>
    /// <param name="Data">The data returned upon successful request</param>
    public record MutationResult<T>(MutationStatus Status, T? Data = default);
  
}
