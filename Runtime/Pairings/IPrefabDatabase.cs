using AYip.Foundation.Pairings;
using UnityEngine;

namespace AYip.Foundation
{
    /// <summary>
    /// Responsible for storing prefabs by an object key.
    /// </summary>
    public interface IPrefabDatabase : IPairingDatabase
    {
        bool TryGetPrefab(object key, out GameObject prefab);
    }
    
    /// <summary>
    /// Responsible for storing prefabs by the TKey.
    /// </summary>
    public interface IPrefabDatabase<in TKey> : IPrefabDatabase, IPairingDatabase<TKey, GameObject>
    {
        bool TryGetPrefab(TKey key, out GameObject prefab);
    }
}