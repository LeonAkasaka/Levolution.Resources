using System.Collections.Generic;
using System.Threading.Tasks;

namespace Levolution.Resources
{
    public class MemoryResourceProvider<TResourceIdentifier> : IResourceProvider<TResourceIdentifier>, IResourceStore<TResourceIdentifier>
    {
        private Dictionary<TResourceIdentifier, object> _dictionary = new Dictionary<TResourceIdentifier, object>();

        public MemoryResourceProvider() { }

        public MemoryResourceProvider(IEnumerable<KeyValuePair<TResourceIdentifier, object>> keyValuePairs)
        {
            foreach(var kv in keyValuePairs)
            {
                _dictionary[kv.Key] = kv.Value;
            }
        }

        public Task<ResourceResult<T>> LoadAsync<T>(TResourceIdentifier id)
        {
            if (_dictionary.TryGetValue(id, out object value))
            {
                return Task.FromResult((value is T result) 
                    ? new ResourceResult<T>(result)
                    : ResourceResult<T>.Failure
                );
            }
            return Task.FromResult(ResourceResult<T>.NotFound);
        }

        public Task<ResourceResult<T>> StoreAsync<T>(TResourceIdentifier id, T value)
        {
            _dictionary[id] = value;
            return Task.FromResult(new ResourceResult<T>(value));
        }
    }
}
