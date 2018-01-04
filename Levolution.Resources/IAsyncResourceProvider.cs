using System.Threading.Tasks;

namespace Levolution.Resources
{
    public interface IAsyncResourceProvider<TResourceIdentifier>
    {
        Task<T> LoadAsync<T>(TResourceIdentifier id);
    }
}
