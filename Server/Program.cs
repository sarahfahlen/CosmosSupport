using Microsoft.AspNetCore.ResponseCompression;
using SupportWebApp.Server.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;


// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.PropertyNamingPolicy = null;
        opts.JsonSerializerOptions.DictionaryKeyPolicy = null;
    });

// Registrér CosmosService som singleton (én instans under hele kørsel)
builder.Services.AddSingleton(provider =>
{
    var cosmosConnection = config["COSMOS_CONNECTION_STRING"];
    if (string.IsNullOrWhiteSpace(cosmosConnection))
        throw new Exception("COSMOS_CONNECTION_STRING mangler i Azure Environment Variables.");

    string databaseName = "IBasSupportDB";       
    string containerName = "ibassupport";        

    return new CosmosService(cosmosConnection, databaseName, containerName);
});
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();


