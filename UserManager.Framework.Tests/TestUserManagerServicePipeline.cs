using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using UserManager.Framework.Pipeline;
using Xunit;
namespace UserManager.Framework.Tests
{
    public class TestUserManagerServicePipeline
    {
   
        [Fact]
        public void TestCaching()
        {

        }

        MockUserManagerServicePipeline GetMockUserManagerServicePipeline()
        {
            var services = new ServiceCollection();
            services.AddMemoryCache();
            var serviceProvider = services.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();
            return new MockUserManagerServicePipeline(memoryCache);
        }
    }

    class MockUserManagerServicePipeline : UserManagerServicePipeline
    {
        public MockUserManagerServicePipeline(IMemoryCache cache) : base(cache)
        {
        }
    }

    public class MockData
    {
        public static MockData Current { get; } = new MockData();



    }
}
