using System.Threading.Tasks;

namespace Levolution.Resources
{
    public abstract class WrappedResourceProvider<TResourceIdentifier> : IResourceProvider<TResourceIdentifier>
    {
        public IResourceProvider<TResourceIdentifier> InnerResourceProvider { get; }

        public WrappedResourceProvider(IResourceProvider<TResourceIdentifier> provider) => InnerResourceProvider = provider;

        public async Task<ResourceResult<T>> LoadAsync<T>(TResourceIdentifier id)
        {
            OnLoading();
            var r = await LoadFromInnerResourceProvider<T>(id);
            OnLoaded();

            return r;
        }

        protected virtual void OnLoading() { }

        protected virtual Task<ResourceResult<T>> LoadFromInnerResourceProvider<T>(TResourceIdentifier id) => InnerResourceProvider.LoadAsync<T>(id);

        protected virtual void OnLoaded() { }

    }
}
