namespace eyas_Task4.Service.Cache
{
    public interface ICache
    {
        void Add(string key, object value);
        void Remove(string key);
        object Get(string key);


    }
}
