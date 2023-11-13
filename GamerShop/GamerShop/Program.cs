using BusinessLayer.BgServices;
using BusinessLayer.RecipeServices;
using BusinessLayer.MovieServices;
using BusinessLayer.UserServices;
using BusinessLayer.FootballServices;
using BusinessLayer.PcBuildServices;
using BusinessLayerInterfaces.BgServices;
using BusinessLayerInterfaces.MovieServices;
using BusinessLayerInterfaces.RecipeServices;
using BusinessLayerInterfaces.FootballService;
using BusinessLayerInterfaces.UserServices;
using BusinessLayerInterfaces.PcBuilderServices;
using DALInterfaces.Repositories;
using BusinessLayerInterfaces.RockHallServices;
using BusinessLayer.RockHallServices;
using DALEfDB.Repositories.PCBuild;
using DALInterfaces.Repositories.PCBuild;
using DALEfDB;
using DALInterfaces.Repositories.Recipe;
using DALInterfaces.Repositories.Movies;
using DALEfDB.Repositories.Movies;
using GamerShop.Services;
using DALEfDB.Repositories.Football;
using DALInterfaces.Repositories.Football;
using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayer.FootballService;
using DALInterfaces.Repositories.RockHall;
using DALEfDB.Repositories.RockHall;
using BusinessLayer.BookServices;
using BusinessLayerInterfaces.BookServices;
using DALEfDB.Repositories;
using DALInterfaces.Repositories.BG;
using DALEfDB.Repositories.BG;
using GamerShop.Hubs;
using DALEfDB.Repositories.Books;
using DALInterfaces.Repositories.Books;

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

//AutoDiResolver.AutoRepositoryResolve(builder.Services);
builder.Services.AutoRepositoryResolve();

builder.Services.AddScoped<IHomeServices, HomeServices>();
builder.Services.AddScoped<IMovieServices, MovieServices>();
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<IBgServices, BgServices>();
builder.Services.AddScoped<IFootballClubService, FootballClubServices>();
builder.Services.AddScoped<IRecipeServices, RecipeServices>();
builder.Services.AddScoped<IReviewServices, ReviewServices>();
builder.Services.AddScoped<IRockMemberServices, RockMemberServices>();
builder.Services.AddScoped<IBookServices, BookServices>();
builder.Services.AddScoped<IAuthorServices, AuthorServices>();
builder.Services.AddScoped<GamerShop.Services.IAuthService, GamerShop.Services.AuthService>();
builder.Services.AddScoped<BusinessLayerInterfaces.UserServices.IAuthService, BusinessLayer.UserServices.AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBuildServices, PcBuildServices>();
builder.Services.AddScoped<IPaginatorService, PaginatorService>();
builder.Services.AddScoped<IFootballLeagueServices, FootballLeagueServices>();
builder.Services.AddScoped<IRockBandServices, RockBandServices>();
builder.Services.AddScoped<IPdfGeneratorService, PdfGeneratorService>();
builder.Services.AddScoped<IBGServiceGeneratorPDF, BGServiceGeneratorPDF>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSignalR();

var dbContextResolver = new Startup();
dbContextResolver.RegisterDbContext(builder.Services);

var app = builder.Build();
builder.Configuration.AddJsonFile("HostsConfig.json");
new Seed().Fill(app.Services);

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

app.UseAuthentication(); // Who am I?

app.UseAuthorization(); // Is it allow for me?

app.UseEndpoints(endpoint =>
{
    endpoint.MapHub<ChatHub>("/chat");
    endpoint.MapHub<NotificationHub>("/notification");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
