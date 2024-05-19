using Newtonsoft.Json;

namespace NevronTask.Extensions;

public static class SessionExtensions
{
    /// <summary>
    /// Stores the specified value into session
    /// </summary>
    public static void Set<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }

    /// <summary>
    /// Retrieves the value stored in the session.
    /// </summary>
    /// <param name="key">The key used for data retrieval</param>
    /// <returns>The value stored in the session. If nothing is stored returns the <see cref="default"/> value of the specified type</returns>
    /// <exception cref="JsonSerializationException"> When the retrieved value is not deserializable into specified type</exception>
    public static T Get<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value is null ? default : JsonConvert.DeserializeObject<T>(value);
    }
}
