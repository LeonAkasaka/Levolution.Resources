using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Levolution.Resources
{
    public static class ResourceProviderExtensions
    {
        private class AsyncResourceProvider<TResourceIdentifier> : IAsyncResourceProvider<TResourceIdentifier>
        {
            private IResourceProvider<TResourceIdentifier> _inner;

            public AsyncResourceProvider(IResourceProvider<TResourceIdentifier> inner) => _inner = inner;

            public Task<T> LoadAsync<T>(TResourceIdentifier id) => Task.FromResult(_inner.Load<T>(id));
        }

        public static IAsyncResourceProvider<TResourceIdentifier> AsAsync<TResourceIdentifier>(this IResourceProvider<TResourceIdentifier> resourceProvider)
            => new AsyncResourceProvider<TResourceIdentifier>(resourceProvider);
    }
}
