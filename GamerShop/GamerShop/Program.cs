using BusinessLayer.BgServices;
using BusinessLayer.RecipeServices;
using BusinessLayer.MovieServices;
using BusinessLayer.UserServices;
using BusinessLayer.FootballServices;
using BusinessLayer.PcBuilderServices;
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
builder.Services.AddScoped<IRockMemberRepository, DALEfDB.Repositories.RockMemberRepository>();
builder.Services.AddScoped<IFootballClubRepository, DALEfDB.Repositories.FootballClubRepository>();
builder.Services.AddScoped<IHeroRepository, DALEfDB.Repositories.BgRepository>();
builder.Services.AddScoped<IMovieRepository, DALEfDB.Repositories.MovieRepository>();
builder.Services.AddScoped<IBuildRepository, BuildRepository>();
builder.Services.AddScoped<IGpuRepository, GpuRepository>();
builder.Services.AddScoped<IHddRepository, HddRepository>();
builder.Services.AddScoped<ISsdRepository, SsdRepository>();
builder.Services.AddScoped<ICaseRepository, CaseRepository>();
builder.Services.AddScoped<IMotherboardRepository, MotherboardRepository>();
builder.Services.AddScoped<ICoolerRepository, CoolerRepository>();
builder.Services.AddScoped<IRamRepository, RamRepository>();
builder.Services.AddScoped<IPsuRepository, PsuRepository>();
builder.Services.AddScoped<IProcessorRepository, ProcessorRepository>();

builder.Services.AddSingleton<IBookRepository>(x => null);
builder.Services.AddSingleton<IRecipeRepository>(x => null);
builder.Services.AddSingleton<IRockMemberRepository>(x => null);

builder.Services.AddScoped<IHomeServices, HomeServices>();
builder.Services.AddScoped<IMovieServices, MovieServices>();
builder.Services.AddScoped<IBgServices, BgServices>();
builder.Services.AddScoped<IFootballServices, FootballSevices>();
builder.Services.AddScoped<IRecipeServices, RecipeServices>();
builder.Services.AddScoped<IRockMemberServices, RockMemberServices>();
builder.Services.AddScoped<GamerShop.Services.IAuthService, GamerShop.Services.AuthService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBuildServices, PcBuildServices>();

builder.Services.AddHttpContextAccessor();

var dbContextResolver = new Startup();
dbContextResolver.RegisterDbContext(builder.Services);

var app = builder.Build();

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

app.UseAuthentication(); // ��� ��?

app.UseAuthorization(); // ����� �� ����?

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
