using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Aurora.WebApp;
using Aurora.WebApp.Application;
using Aurora.WebApp.Application.Contracts;
using Aurora.WebApp.Provider.AuthenticationProviders;
using Aurora.WebApp.Provider.LocalStoreProviders;
using Aurora.WebApp.Provider.OperatorProviders;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Diagnostics;
using System.Text.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
Debug.WriteLine(builder.HostEnvironment.BaseAddress);
builder.Services.AddScoped(sp => new HttpClient
{
    // BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    BaseAddress = new Uri("https://localhost:5001/"),
});
builder.Services.AddAntDesign();

builder.Services.AddBlazoredLocalStorage(config =>
{
    config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.IgnoreNullValues = true;
    config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
    config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
    config.JsonSerializerOptions.WriteIndented = false;
});

builder.Services
    .AddAuthorizationCore()
    .AddScoped<AuthenticationStateProvider, AuroraAuthenticationStateProvider>()
    .AddScoped<IAuthAppService, AuthAppService>();

await builder.Build().RunAsync();