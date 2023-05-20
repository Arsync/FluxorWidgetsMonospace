using Fluxor;
using FluxorWidgetsMonospace;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddFluxor(opts =>
{
    opts.ScanAssemblies(typeof(Program).Assembly);

    if (builder.HostEnvironment.IsDevelopment())
        opts.UseReduxDevTools(x => x.EnableStackTrace());
});

await builder.Build().RunAsync();
