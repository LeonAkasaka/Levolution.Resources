namespace Levolution.Resources
{
    public interface IResourceProvider<TResourceIdentifier>
    {
        T Load<T>(TResourceIdentifier id);
    }
}
