using System;
using System.IO;
using System.Threading.Tasks;

namespace Levolution.Resources.Unity
{
    public class AssetsResourceProvider : IResourceProvider<string>
    {
        public string RootPath { get; set; }

        public AssetsResourceProvider() : this("") { }
        public AssetsResourceProvider(string rootPath) { RootPath = rootPath; }

        public Task<ResourceResult<T>> LoadAsync<T>(string id)
        {
            if (!typeof(UnityEngine.Object).IsAssignableFrom(typeof(T)))
            {
                return Task.FromResult(ResourceResult<T>.NotFound);
            }

            var tcs = new TaskCompletionSource<ResourceResult<T>>();
            var path = Path.Combine(RootPath, id);
            var r = UnityEngine.Resources.LoadAsync(path, typeof(T));

            Action<UnityEngine.AsyncOperation> OnComplited = null;
            OnComplited = _ =>
            {
                tcs.SetResult(r.asset == null ? ResourceResult<T>.NotFound : new ResourceResult<T>((T)(object)r.asset));
                r.completed -= OnComplited;
            };

            r.completed += OnComplited;
            return tcs.Task;
        }
    }
}