using System;

namespace Levolution.Resources
{
    public struct ResourceResult<T>
    {
        public static ResourceResult<T> Failure { get; } = new ResourceResult<T>(ResourceState.Failure);

        public static ResourceResult<T> NotFound { get; } = new ResourceResult<T>(ResourceState.NotFound);

        public ResourceState ResourceState { get; }

        public T Value
        {
            get
            {
                if (ResourceState != ResourceState.Success)
                {
                    throw new InvalidOperationException($"{nameof(ResourceState)} must be ${nameof(ResourceState.Success)}, but current state is {ResourceState}.");
                }
                return _value;
            }
        }
        private T _value;

        public ResourceResult(T value)
        {
            ResourceState = ResourceState.Success;
            _value = value;
        }

        private ResourceResult(ResourceState loadingState)
        {
            ResourceState = loadingState;
            _value = default;
        }
    }
}

