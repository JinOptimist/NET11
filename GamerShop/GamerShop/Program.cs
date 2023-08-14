using BusinessLayer.UserServices;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Repositories;
using DALWrongDB.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IRecipeRepository, RecipeRepository>();
<<<<<<< HEAD
builder.Services.AddSingleton<ICarRepository, CarRepository>();
builder.Services.AddSingleton<IRockMemberRepository, RockMemberRepository>();
builder.Services.AddScoped<IHomeServices, HomeServices>();
builder.Services.AddScoped<ICarServices, CarServices>();


=======
builder.Services.AddSingleton<IRockMemberRepository, RockMemberRepository>();
builder.Services.AddScoped<IHomeServices, HomeServices>();
>>>>>>> main


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
