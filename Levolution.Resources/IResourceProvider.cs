using System.Threading.Tasks;

namespace Levolution.Resources
{
    public interface IResourceProvider<TResourceIdentifier>
    {
        Task<ResourceResult<T>> LoadAsync<T>(TResourceIdentifier id);
    }
}
