using Blazor;
using Blazor.Service;
using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjEwMzk1M0AzMjMxMmUzMjJlMzVMMWVHZkpZLzNvaFdqamxDdUFmWVNUaEJrTHc5OElpRDc2Sm4ydUxFVVNVPQ==");

//
builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredLocalStorage();
// ql state
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<ITaskApiClient, TaskApiClient>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7217/") });

await builder.Build().RunAsync();
