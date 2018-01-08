using System.Threading.Tasks;

namespace Levolution.Resources
{
    public static class ResourceProviderExtensions
    {
        public static async Task<T> LoadOrDefault<TResourceIdentifier, T>(this IResourceProvider<TResourceIdentifier> resourceProvider, TResourceIdentifier id)
        {
            var r = await resourceProvider.LoadAsync<T>(id);
            return r.LoadingState == LoadingState.Success ? r.Value : default(T);
        }
    }
}
