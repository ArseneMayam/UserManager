namespace UserManager.Framework.Pipeline
{
    public interface IUserManagerServicePipeline
    {
        object TestRetrieveDataCache(string nomCache);
        void TestStoreDataCache(string nomCache, object data);
        bool TestTryGetCache(string nomCache);
    }
}