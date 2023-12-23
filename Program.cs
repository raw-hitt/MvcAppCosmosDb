using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using MvcAppCosmosDb.Models;
using MvcAppCosmosDb.Services;
using MvcAppCosmosDb.Services.Interfaces;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


#region Cosmos Db

try
{
    builder.Services.AddSingleton<CosmosClient>(sp =>
    {
        var cosmosDbSettings = sp.GetRequiredService<IOptions<CosmosDbSettings>>().Value;
        return new CosmosClient("https://rohitpawar.table.cosmos.azure.com:443/", "WLjhe30V2efFBdYns9jTpUGaQXJ8ZTaGE8VCrPhMkdqstPAFGVnMHzYpQedephsAWMynm7D1F6rMACDboGKIAA==");
    });

}
catch (Exception ex)
{

    throw ex;
}
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
