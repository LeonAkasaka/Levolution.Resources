using System.Threading.Tasks;

namespace Levolution.Resources
{
    public interface IResourceStore<TResourceIdentifier>
    {
        Task<ResourceResult<T>> Store<T>(TResourceIdentifier id, T resource);
    }
}
