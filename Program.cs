using BlazingPizza.Components;
using BlazingPizza.Data;
using BlazingPizza.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ISQLite3Ctrl, SQLite3Ctrl>();
builder.Services.AddControllers();
builder.Services.AddSingleton<PizzaService>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<OrderState>();
// services must agree, DI, dependency injection; permanent service vs per request(scoped), it is problem

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllers();

app.Run();
