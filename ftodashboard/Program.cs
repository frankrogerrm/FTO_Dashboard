using Azure.Identity;
using ftodashboard.Classes;
using ftodashboard.Data;
using ftodashboard.Services;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Configuration.GetSection("ASPNETCORE_ENVIRONMENT").Value;
var initialScopes = builder.Configuration.GetValue<string>("DownstreamApi:Scopes")?.Split(' ');
// Add services to the container.

builder.Services
    .AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
     .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
     .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
     .AddMicrosoftGraph(builder.Configuration.GetSection("DownstreamApi"))
     .AddInMemoryTokenCaches();
builder.Services.AddControllersWithViews()
.AddMicrosoftIdentityUI();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
.AddMicrosoftIdentityConsentHandler();

builder.Configuration.AddAzureKeyVault(
    new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
    new DefaultAzureCredential());

builder.Services.AddApplicationInsightsTelemetry(options =>
{
    options.ConnectionString = builder.Configuration["APPINSIGHTS_CONNECTIONSTRING"];
});

builder.WebHost.UseStaticWebAssets();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
if (env == "Local")
{
    builder.Services.AddDbContext<CommonDataSourceContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CommonDataSourceConnection")).EnableSensitiveDataLogging());
    builder.Services.AddDbContext<LoggingContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LoggingDataSourceLocalConnection")).EnableSensitiveDataLogging());
    builder.Services.AddDbContext<TimeSheetAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TestConnection")).EnableSensitiveDataLogging());
}
else if (env == "Development")
{
    builder.Services.AddDbContext<CommonDataSourceContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CommonDataSourceDevConnection")).EnableSensitiveDataLogging());
    builder.Services.AddDbContext<LoggingContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LoggingDataSourceConnection")).EnableSensitiveDataLogging());
    builder.Services.AddDbContext<TimeSheetAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TimeSheetAppDevConnection")).EnableSensitiveDataLogging());
}
else if (env == "Test")
{
    builder.Services.AddDbContext<CommonDataSourceContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CommonDataSourceConnection")).EnableSensitiveDataLogging());
    builder.Services.AddDbContext<LoggingContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LoggingDataSourceConnection")).EnableSensitiveDataLogging());
    builder.Services.AddDbContext<TimeSheetAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TimeSheetAppDevConnection")).EnableSensitiveDataLogging());
}
else if (env == "Staging" || env == "Production")
{
    builder.Services.AddDbContext<CommonDataSourceContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CommonDataSourceConnection")).EnableSensitiveDataLogging());
    builder.Services.AddDbContext<TimeSheetAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TimeSheetAppConnection")).EnableSensitiveDataLogging());
}

builder.Services.AddTelerikBlazor();
builder.Services.AddScoped<EmailService>();
builder.Services.AddTransient<WriteBlob>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<AppUser>();
builder.Services.AddScoped<EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment() && env != "Local")
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//To enable static files from a package, make sure this is present.
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

await app.RunAsync();
