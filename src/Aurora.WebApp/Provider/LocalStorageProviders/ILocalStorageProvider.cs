namespace Aurora.WebApp.Provider.LocalStoreProviders;

public interface ILocalStorageProvider
{
    Task<T?> GetItem<T>(string key) where T : class;
    Task SetItem<T>(string key, T value) where T : class;
    Task RemoveItem(string key);
}