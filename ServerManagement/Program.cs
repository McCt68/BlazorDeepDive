using ServerManagement.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container. Its a Collection of services
builder.Services.AddRazorComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// These functions are called midleware. When a http request comes in they will be used -
// Each if these will eather add something to the request or handle the reuest to give it certain -
// functionalities. ?? ( need learn more)
app.UseHttpsRedirection();

// Repsosible for mapping static resources like amigaes, css sheets and so on
app.UseStaticFiles();

app.UseAntiforgery();

// This midleware will map the http request to the App class. So all request will be mapped to the App class -
// which is the root component.
// When we say that blazor is a single page application framework. The single page is this root component
app.MapRazorComponents<App>();

app.Run(); // Runs in a loop listening for incoming http requests
