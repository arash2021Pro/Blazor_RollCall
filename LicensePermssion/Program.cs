using CoreStorage.StorageContext;
using ElmahCore.Mvc;
using LicensePermssion.StartupCoreModules.AppServices;
using LicensePermssion.StartupCoreModules.DataSeed;
using LicensePermssion.StartupCoreModules.Elmah;
using LicensePermssion.StartupCoreModules.SqlService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.RunSqlService(builder.Configuration);
builder.Services.RunAppServices();
builder.Services.RunElmahSqlService(builder.Configuration);
builder.Services.AddResponseCompression();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHealthChecks().AddDbContextCheck<ApplicationContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.RunInitialScope();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseElmah();
app.Run();