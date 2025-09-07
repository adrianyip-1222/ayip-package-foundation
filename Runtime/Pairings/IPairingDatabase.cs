namespace AYip.Foundation.Pairings
{
	/// <summary>
	/// Responsible for storing key-value pairs.
	/// </summary>
	public interface IPairingDatabase
	{
		bool TryGetValue(object key, out object value);
	}

	/// <summary>
	/// Repsonsible for storing key-value pairs.
	/// </summary>
	public interface IPairingDatabase<in TKey, TValue> : IPairingDatabase
	{
		bool TryGetValue (TKey key, out TValue value);
	}
}