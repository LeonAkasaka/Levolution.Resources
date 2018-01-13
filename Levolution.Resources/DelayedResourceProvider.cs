using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Levolution.Resources
{
    public class DelayedResourceProvider<TResourceIdentifier> : WrappedResourceProvider<TResourceIdentifier>
    {
        public TimeSpan Delay { get; }

        public DelayedResourceProvider(IResourceProvider<TResourceIdentifier> provider, int milliseconds) : this(provider, TimeSpan.FromMilliseconds(milliseconds)) { }

        public DelayedResourceProvider(IResourceProvider<TResourceIdentifier> provider, TimeSpan delay) : base(provider)
        {
            Delay = delay;
        }

        protected override async Task<ResourceResult<T>> LoadFromInnerResourceProvider<T>(TResourceIdentifier id)
        {
            await Task.Delay(Delay);
            return await base.LoadFromInnerResourceProvider<T>(id); ;
        }
    }
}
