using System;
using System.Collections.Generic;

namespace Levolution.Resources
{
    public class MemoryResourceProvider<TResourceIdentifier> : IResourceProvider<TResourceIdentifier>
    {
        private Dictionary<TResourceIdentifier, object> _dictionary = new Dictionary<TResourceIdentifier, object>();

        public MemoryResourceProvider() { }

        public MemoryResourceProvider(IEnumerable<KeyValuePair<TResourceIdentifier, object>> keyValuePairs)
        {
            foreach(var kv in keyValuePairs) { Write(kv.Key, kv.Value); }
        }

        public T Load<T>(TResourceIdentifier id) => _dictionary.TryGetValue(id, out object value) && value is T result ? result : default;

        public void Write<T>(TResourceIdentifier id, T value) => _dictionary[id] = value;
    }
}
