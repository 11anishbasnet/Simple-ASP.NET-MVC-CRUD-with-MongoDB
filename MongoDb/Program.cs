using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDb.Models.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add MongoDB context registration (if not added already)
builder.Services.AddScoped<MongoDBContext>();

// Add the UserRepository registration
builder.Services.AddScoped<UserRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

//builder.Services.AddSingleton<UserRepository>();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// Add MongoDB client to dependency injection container
//builder.Services.Configure<ReadConfig>(builder.Configuration.GetSection("MongoDBConnection"));
/*builder.Services.AddSingleton<IMongoClient>(ServiceProvider =>
{
    string connectionString = "mongodb://localhost:27017/UserDB";
    return new MongoClient(connectionString);
});*/

// Add UserRepository to dependency injection container


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
