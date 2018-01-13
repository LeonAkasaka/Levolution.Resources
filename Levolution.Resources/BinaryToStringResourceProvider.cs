using System.Text;
using System.Threading.Tasks;

namespace Levolution.Resources
{
    public class BinaryToStringResourceProvider<TResourceIdentifier> : WrappedResourceProvider<TResourceIdentifier>
    {
        public Encoding Encoding { get; }

        public BinaryToStringResourceProvider(IResourceProvider<TResourceIdentifier> provider) : this(provider, Encoding.UTF8) { }

        public BinaryToStringResourceProvider(IResourceProvider<TResourceIdentifier> provider, Encoding encoding) : base(provider)
        {
            Encoding = encoding;
        }

        protected async override Task<ResourceResult<T>> LoadFromInnerResourceProvider<T>(TResourceIdentifier id)
        {
            if (typeof(T).IsAssignableFrom(typeof(string))) { return ResourceResult<T>.NotFound; }

            var result = await base.LoadFromInnerResourceProvider<byte[]>(id);
            if (result.ResourceState == ResourceState.NotFound) { return ResourceResult<T>.NotFound; }
            else if (result.ResourceState == ResourceState.Failure) { return ResourceResult<T>.Failure; }
            else if (result.ResourceState == ResourceState.None) { return default; }
            else { return new ResourceResult<T>((T)(object)Encoding.GetString(result.Value)); }
        }
    }
}
