using BlazorApp3.Client.Pages;
using BlazorApp3.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles("/path-prefix");
app.UseAntiforgery();

app.UseBlazorFrameworkFiles(new PathString("/path-prefix"));
app.UsePathBase("/path-prefix");
app.UseAntiforgery();
app.UseRouting();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode(options => options.PathPrefix = "/path-prefix")
    .AddAdditionalAssemblies(typeof(BlazorApp3.Client._Imports).Assembly);

app.Run();
