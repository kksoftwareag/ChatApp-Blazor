using ChatApp.Models;
using ChatApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Toolkit.Mvvm.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<ChatMessageService>();

builder.Services.AddSingleton<IMessenger, WeakReferenceMessenger>();

builder.Services.AddDbContext<DatabaseContext>(
    optionsAction: options => options.UseSqlite("Data Source=chat.sqlite"),
    contextLifetime: ServiceLifetime.Transient,
    optionsLifetime: ServiceLifetime.Singleton
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Services.GetService<DatabaseContext>().Database.Migrate();
app.Services.GetService<ChatMessageService>().LoadMessages();

app.Run();
