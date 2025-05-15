using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using WebConsulting.Models;
using Microsoft.EntityFrameworkCore;
using WebConsulting.Other;
using WebConsulting.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IEmailService, EmailService>();

builder.Services.AddScoped<IServiceBlockService, ServiceBlockService>();


builder.Services.AddDbContext<ConsultingDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<ServicesService>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseStaticFiles(); 

app.Run();
