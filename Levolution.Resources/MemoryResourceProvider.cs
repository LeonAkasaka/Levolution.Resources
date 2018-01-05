using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public Task<LoadingResult<T>> LoadAsync<T>(TResourceIdentifier id)
        {
            if (_dictionary.TryGetValue(id, out object value))
            {
                return Task.FromResult((value is T result) 
                    ? new LoadingResult<T>(result)
                    : LoadingResult<T>.Failure
                );
            }
            return Task.FromResult(LoadingResult<T>.NotFound);
        }

        public void Write<T>(TResourceIdentifier id, T value) => _dictionary[id] = value;
    }
}
