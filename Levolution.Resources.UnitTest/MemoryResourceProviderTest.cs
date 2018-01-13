using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Levolution.Resources.UnitTest
{
    [TestClass]
    public class MemoryResourceProviderTest
    {
        [TestMethod]
        public async Task TestLoadAsync()
        {
            var rp = new MemoryResourceProvider<int>();

            var value1 = "Stand by Ready!";
            var value2 = new Uri("https://github.com/LeonAkasaka/Levolution.Resources");

            await rp.Store(1, value1);
            await rp.Store(2, value2);

            var r1 = await rp.LoadAsync<string>(1);
            Assert.AreEqual(ResourceState.Success, r1.ResourceState);
            Assert.AreEqual(value1, r1.Value);

            var r2 = await rp.LoadAsync<Uri>(2);
            Assert.AreEqual(ResourceState.Success, r2.ResourceState);
            Assert.AreEqual(value2, r2.Value);

            var r3 = await rp.LoadAsync<object>(1); // Base type
            Assert.AreEqual(ResourceState.Success, r3.ResourceState);
            Assert.AreEqual(value1, r3.Value);

            var r4 = await rp.LoadAsync<object>(2); // base type
            Assert.AreEqual(ResourceState.Success, r4.ResourceState);
            Assert.AreEqual(value2, r4.Value);

            var r5 = await rp.LoadAsync<Uri>(1); // Type mismatch
            Assert.AreEqual(ResourceState.Failure, r5.ResourceState);

            var r6 = await rp.LoadAsync<string>(2); // Type mismatch
            Assert.AreEqual(ResourceState.Failure, r6.ResourceState);

            var r7 = await rp.LoadAsync<object>(0); // Id not found.
            Assert.AreEqual(ResourceState.NotFound, r7.ResourceState);
        }
    }
}
