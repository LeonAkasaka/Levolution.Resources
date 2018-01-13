using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Levolution.Resources
{
    public class FileResourceProvider : IResourceProvider<string>
    {
        public string RootPath { get; }
        
        public FileResourceProvider(string rootPath) => RootPath = rootPath;

        public async Task<ResourceResult<T>> LoadAsync<T>(string id)
        {
            try
            {
                var path = Path.Combine(RootPath, id);
                if (typeof(IEnumerable<byte>).IsAssignableFrom(typeof(T)))
                {
                    var data = await Task.Run(() => File.ReadAllBytes(path));
                    return new ResourceResult<T>((T)(object)data);
                }
                return ResourceResult<T>.Failure;
            }
            catch(FileNotFoundException e)
            {
                return ResourceResult<T>.NotFound;
            }
            catch
            {
                return ResourceResult<T>.Failure;
            }
        }
    }
}
