using System;

namespace Levolution.Resources
{
    public struct LoadingResult<T>
    {
        public static LoadingResult<T> Failure { get; } = new LoadingResult<T>(LoadingState.Failure);

        public static LoadingResult<T> NotFound { get; } = new LoadingResult<T>(LoadingState.NotFound);

        public LoadingState LoadingState { get; }

        public T Value
        {
            get
            {
                if (LoadingState != LoadingState.Success)
                {
                    throw new InvalidOperationException($"{nameof(LoadingState)} must be ${nameof(LoadingState.Success)}, but current state is {LoadingState}.");
                }
                return _value;
            }
        }
        private T _value;

        public LoadingResult(T value)
        {
            LoadingState = LoadingState.Success;
            _value = value;
        }

        private LoadingResult(LoadingState loadingState)
        {
            LoadingState = loadingState;
            _value = default;
        }
    }
}

