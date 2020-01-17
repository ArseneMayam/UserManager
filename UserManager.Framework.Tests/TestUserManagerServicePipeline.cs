using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using UserManager.Api.Entities;
using UserManager.Framework.Pipeline;
using UserManager.Services.Interfaces;
using Xunit;
namespace UserManager.Framework.Tests
{
    public class TestUserManagerServicePipeline
    {
   
        [Fact]
        public void TestCaching()
        {
            var pipeline = GetMockUserManagerServicePipeline();
            var users = MockData.Current.List;
            // mock data 
            string data = "My string to be stored";
            //  store data to cache
            pipeline.TestStoreDataCache("storedString", users);
            // check if data exists in cache
            var result = pipeline.TestTryGetCache("storedString");
            // retrieve data stored in cache
            var retrieved = pipeline.TestRetrieveDataCache("storedString");
            // assert if data stored in cache exists
             Assert.True(result);
            // assert if retrieved data is equal to expected data
            Assert.Equal(users, retrieved);

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
        public List<Utilisateur> List { get; set; }

        public MockData()
        {
            List = new List<Utilisateur>
            {
                new Utilisateur("Dan ","Lok"),
                new Utilisateur("Sara","Lean")
            };
        }


    }
}
