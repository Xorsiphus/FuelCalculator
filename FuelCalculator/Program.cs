using FuelCalculator.Application;
using FuelCalculator.Application.Enums.Configuration;
using FuelCalculator.Application.ServiceImpl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.Configure<DistanceMatrixAuth>(builder.Configuration.GetSection("DistanceMatrixAuth"));
builder.Services.AddTransient<IFuelWeightCalculatorService, FuelWeightCalculatorService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();