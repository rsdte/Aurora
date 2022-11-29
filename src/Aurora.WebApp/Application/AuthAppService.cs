using Aurora.WebApp.Application.Contracts;
using Aurora.WebApp.Provider.AuthenticationProviders;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Dynamic;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Aurora.WebApp.Application;

public class AuthAppService: IAuthAppService
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ILocalStorageService _localStorage;

    public AuthAppService(HttpClient httpClient,
        AuthenticationStateProvider authenticationStateProvider,
        ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _authenticationStateProvider = authenticationStateProvider;
        _localStorage = localStorage;
    }
    
    public async Task<bool> Login(string username, string password)
    {
        // var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
        // {
        //     new("UserName", username),
        //     new("Password", password),
        // });

        dynamic dn = new ExpandoObject();
        dn.UserName = username;
        dn.Password = password;

        StringContent content = new StringContent(JsonSerializer.Serialize(dn), Encoding.UTF8, "application/json");
        
        
        using var rsp = await _httpClient.PostAsync("api/Auth/SignIn", content);
        if (!rsp.IsSuccessStatusCode)
        {
            return false;
        }
        var authToken = await rsp.Content.ReadAsStringAsync();
        await ((AuroraAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(authToken);
        // await ((AuroraAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(username);
        return true;
    }
    //
    // public async Task Logout()
    // {
    //     await _localStorage.RemoveItemAsync("authToken");
    //     ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
    //     _httpClient.DefaultRequestHeaders.Authorization = null;
    // }
}