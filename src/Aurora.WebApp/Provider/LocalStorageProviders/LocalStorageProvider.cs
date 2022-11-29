using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

namespace Aurora.WebApp.Provider.LocalStoreProviders;

public class LocalStorageProvider: ILocalStorageProvider
{
    [Inject]
    public IJSRuntime JsRuntime { get; set; }

    public LocalStorageProvider()
    {
        // _jsRuntime = jsRuntime;
    }

    public async Task<T?> GetItem<T>(string key)
        where T: class
    {
        var json = await JsRuntime.InvokeAsync<string>("localStorage.getItem", key);

        return JsonSerializer.Deserialize<T>(json);
    }

    public async Task SetItem<T>(string key, T value)
        where T: class
    {
        await JsRuntime.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
    }

    public async Task RemoveItem(string key)
    {
        await JsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
    }
}