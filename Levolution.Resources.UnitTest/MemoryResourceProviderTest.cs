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

            rp.Write(1, value1);
            rp.Write(2, value2);

            var r1 = await rp.LoadAsync<string>(1);
            Assert.AreEqual(LoadingState.Success, r1.LoadingState);
            Assert.AreEqual(value1, r1.Value);

            var r2 = await rp.LoadAsync<Uri>(2);
            Assert.AreEqual(LoadingState.Success, r2.LoadingState);
            Assert.AreEqual(value2, r2.Value);

            var r3 = await rp.LoadAsync<object>(1); // Base type
            Assert.AreEqual(LoadingState.Success, r3.LoadingState);
            Assert.AreEqual(value1, r3.Value);

            var r4 = await rp.LoadAsync<object>(2); // base type
            Assert.AreEqual(LoadingState.Success, r4.LoadingState);
            Assert.AreEqual(value2, r4.Value);

            var r5 = await rp.LoadAsync<Uri>(1); // Type mismatch
            Assert.AreEqual(LoadingState.Failure, r5.LoadingState);

            var r6 = await rp.LoadAsync<string>(2); // Type mismatch
            Assert.AreEqual(LoadingState.Failure, r6.LoadingState);

            var r7 = await rp.LoadAsync<object>(0); // Id not found.
            Assert.AreEqual(LoadingState.NotFound, r7.LoadingState);
        }
    }
}
