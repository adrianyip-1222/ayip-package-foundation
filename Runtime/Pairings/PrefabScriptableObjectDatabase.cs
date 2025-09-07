using System.Linq;
using UnityEngine;

namespace AYip.Foundation
{
    /// <summary>
    /// Responsible for storing prefabs by the TKey.
    /// </summary>
    public abstract class PrefabScriptableObjectDatabase<TKey> : ScriptableObject, IPrefabDatabase<TKey>
    {
        [SerializeField]
        private KeyPrefabPair[] registry;

        public bool TryGetValue(TKey key, out GameObject value)
        {
            return TryGetPrefab(key, out value);
        }

        public bool TryGetValue(object key, out object value)
        {
            var success = TryGetPrefab(key, out var prefab);
            value = prefab;
            return success;
        }
        
        public bool TryGetPrefab(TKey key, out GameObject prefab)
        {
            prefab = null;
            var result = registry.FirstOrDefault(pair => pair.Key.Equals(key));
            if (!result.Prefab)
            {
                return false;
            }

            prefab = result.Prefab;
            return true;
        }

        public bool TryGetPrefab(object key, out GameObject prefab)
        {
            prefab = null;
            return key is TKey typedKey && TryGetPrefab(typedKey, out prefab);
        }        
        
        [System.Serializable]
        private struct KeyPrefabPair
        {
            [SerializeField]
            private TKey key;

            [SerializeField]
            private GameObject prefab;
            
            public TKey Key => key;
            public GameObject Prefab => prefab;
        }
    }
}