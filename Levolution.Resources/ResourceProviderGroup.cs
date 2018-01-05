using System.Collections.Generic;
using System.Threading.Tasks;

namespace Levolution.Resources
{
    public class ResourceProviderGroup<TResourceIdentifier> : IResourceProvider<TResourceIdentifier>
    {
        public ICollection<IResourceProvider<TResourceIdentifier>> ResourceProviders { get; } = new List<IResourceProvider<TResourceIdentifier>>();

        public async Task<LoadingResult<T>> LoadAsync<T>(TResourceIdentifier id)
        {
            foreach(var rp in ResourceProviders)
            {
                var r = await rp.LoadAsync<T>(id);
                if (r.LoadingState == LoadingState.Success)
                {
                    return r;
                }
            }

            return LoadingResult<T>.NotFound;
        }
    }
}
