using Microsoft.Azure.Cosmos;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSingleton<CosmosClient>(serviceProvider =>
{
    IHttpClientFactory httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();

    CosmosClientOptions cosmosClientOptions = new CosmosClientOptions
    {
        HttpClientFactory = httpClientFactory.CreateClient,
        ConnectionMode = ConnectionMode.Gateway
    };

    return new CosmosClient("<cosmosdb_connectionstring>");
});
 

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
