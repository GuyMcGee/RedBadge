using Microsoft.EntityFrameworkCore;
using Redbadge.Data.Context;
using RedBadge.Services.Configurations;
using RedBadge.Services.Game;
using RedBadge.Services.Player;
using RedBadge.Services.Occasion;
using RedBadge.Services.Rank;
using RedBadge.Services.IndividualResults;
using Microsoft.AspNetCore.Identity;
using Redbadge.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MapperConfigurations));
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IOccasionService, OccasionService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IRankService, RankService>();
builder.Services.AddScoped<IIRService, IRService>();
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
    pattern: "{controller=Home}/{action=Index}/{Id?}");

app.Run();
