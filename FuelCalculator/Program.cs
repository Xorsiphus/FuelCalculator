using FuelCalculator.Application;
using FuelCalculator.Application.ServiceImpl;
using FuelCalculator.Enums.Configuration;

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