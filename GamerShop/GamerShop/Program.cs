
using BusinessLayer.BgServices;
using BusinessLayer.UserServices;
using BusinessLayerInterfaces.BgServices;
﻿using BusinessLayer.UserServices;
﻿using BusinessLayer.RecipeServices;
using BusinessLayer.UserServices;
using BusinessLayerInterfaces.RecipeServices;
using BusinessLayer.FootballServices;
using BusinessLayerInterfaces.FootballService;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Repositories;
using DALWrongDB.Repositories;
using GamerShop.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddAuthentication("WebAuthSmile")
    .AddCookie("WebAuthSmile", 
        option =>
        {
            option.LoginPath = "/Auth/Login";
		});

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IBookRepository, BookRepository>();
builder.Services.AddSingleton<IRecipeRepository, RecipeRepository>();
builder.Services.AddSingleton<IRockMemberRepository, RockMemberRepository>();
builder.Services.AddSingleton<IPersRepository, PersRepository>();
builder.Services.AddSingleton<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IHomeServices, HomeServices>();
builder.Services.AddSingleton<IPersRepository, PersRepository>();
builder.Services.AddSingleton<IPcComponentsRepository, PcComponentRepository>();
builder.Services.AddScoped<IPcComponentServices, PcComponentServices>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBgServices, BgServices>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IFootballClubRepository, FootballClubRepository>();
builder.Services.AddSingleton<IFootballServices, FootballSevices>();

builder.Services.AddScoped<IRecipeServices, RecipeServices>();




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

app.UseAuthentication(); // ��� ��?

app.UseAuthorization(); // ����� �� ����?

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
