using System.Threading.Tasks;

namespace Levolution.Resources
{
    public interface IResourceStore<TResourceIdentifier>
    {
        Task<ResourceResult<T>> StoreAsync<T>(TResourceIdentifier id, T resource);
    }
}
