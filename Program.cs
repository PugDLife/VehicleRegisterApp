using Microsoft.EntityFrameworkCore;
using VehicleRegisterApp.Components;
using VehicleRegisterApp.Data;
using VehicleRegisterApp.Services.ContractorServices;
using VehicleRegisterApp.Services.VehicleServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IContractorService, ContractorService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddServerSideBlazor(options =>
{
    options.DetailedErrors = true;
});
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

app.Run();
