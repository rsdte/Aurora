using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace Aurora.WebApp.Provider.AuthenticationProviders;

public class AuroraAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private readonly JwtSecurityTokenHandler _tokenHandler;

    public AuroraAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage, JwtSecurityTokenHandler tokenHandler)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _tokenHandler = tokenHandler;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var savedToken = await _localStorage.GetItemAsync<string>("authToken");

            if (string.IsNullOrWhiteSpace(savedToken))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var tokenContent = _tokenHandler.ReadJwtToken(savedToken);
            var expiry = tokenContent.ValidTo;
            if (expiry < DateTime.Now)
            {
                await _localStorage.RemoveItemAsync("authToken");
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", savedToken);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(tokenContent), "jwt")));
        }catch
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }

    public async Task MarkUserAsAuthenticated(string authToken)
    {
        try
        {
            var tokenContent = _tokenHandler.ReadJwtToken(authToken);
            var claims = ParseClaimsFromJwt(tokenContent);
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            NotifyAuthenticationStateChanged(authState);
            await _localStorage.SetItemAsync("authToken", authToken);
        }
        catch { }
    }

    public void MarkUserAsLoggedOut()
    {
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.Run(()=> new AuthenticationState(anonymousUser)));
    }

    private static IEnumerable<Claim> ParseClaimsFromJwt(JwtSecurityToken tokenContent)
    {
        var claims = tokenContent.Claims.ToList();
        claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
        return claims;
    }
}