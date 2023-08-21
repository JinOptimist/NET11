using BusinessLayer.BgServices;
using BusinessLayer.RecipeServices;
using BusinessLayer.MovieServices;
using BusinessLayer.UserServices;
using BusinessLayer.FootballServices;
using BusinessLayerInterfaces.BgServices;
using BusinessLayerInterfaces.MovieServices;
using BusinessLayerInterfaces.RecipeServices;
using BusinessLayerInterfaces.FootballService;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Repositories;
using DALWrongDB.Repositories;
using BusinessLayerInterfaces.RockHallServices;
using BusinessLayer.RockHallServices;
using GamerShop.Services;
using DALEfDB;

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

builder.Services.AddScoped<IUserRepository, DALEfDB.Repositories.UserRepository>();

builder.Services.AddSingleton<IBookRepository, BookRepository>();
builder.Services.AddSingleton<IRecipeRepository, RecipeRepository>();
builder.Services.AddSingleton<IRockMemberRepository, RockMemberRepository>();
builder.Services.AddSingleton<IPersRepository, PersRepository>();
builder.Services.AddSingleton<IMovieRepository, MovieRepository>();
builder.Services.AddSingleton<IFootballClubRepository, FootballClubRepository>();
builder.Services.AddSingleton<IPersRepository, PersRepository>();
builder.Services.AddSingleton<IPcComponentsRepository, PcComponentRepository>();

builder.Services.AddScoped<IHomeServices, HomeServices>();
builder.Services.AddScoped<IMovieServices, MovieServices>();
builder.Services.AddScoped<IPcComponentServices, PcComponentServices>();
builder.Services.AddScoped<IBgServices, BgServices>();
builder.Services.AddScoped<IFootballServices, FootballSevices>();
builder.Services.AddScoped<IRecipeServices, RecipeServices>();
builder.Services.AddScoped<IRockMemberServices, RockMemberServices>();
builder.Services.AddScoped<GamerShop.Services.IAuthService, GamerShop.Services.AuthService>();
builder.Services.AddScoped<BusinessLayerInterfaces.UserServices.IAuthService, BusinessLayer.UserServices.AuthService>();

builder.Services.AddHttpContextAccessor();

var dbContextResolver = new Startup();
dbContextResolver.RegisterDbContext(builder.Services);


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
