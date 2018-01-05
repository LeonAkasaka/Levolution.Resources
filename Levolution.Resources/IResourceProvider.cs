using System.Threading.Tasks;

namespace Levolution.Resources
{
    public interface IResourceProvider<TResourceIdentifier>
    {
        Task<LoadingResult<T>> LoadAsync<T>(TResourceIdentifier id);
    }
}
