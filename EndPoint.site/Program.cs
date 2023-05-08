using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Sina_Store.Application.Interfaces.Contexts;
using Sina_Store.Application.Interfaces.FacadPatterns;
using Sina_Store.Application.Services.Common.Queries.GetCategory;
using Sina_Store.Application.Services.Common.Queries.GetMenuItem;
using Sina_Store.Application.Services.Products.FacadPattern;
using Sina_Store.Application.Services.Users.Commands.EditUser;
using Sina_Store.Application.Services.Users.Commands.RegisterUser;
using Sina_Store.Application.Services.Users.Commands.RemoveUser;
using Sina_Store.Application.Services.Users.Commands.UserLogin;
using Sina_Store.Application.Services.Users.Commands.UserSatusChange;
using Sina_Store.Application.Services.Users.Queries.GetRoles;
using Sina_Store.Application.Services.Users.Queries.GetUsers;
using Sina_Store.Persistence.Contexts;


#region Main Method
var builder = WebApplication.CreateBuilder(args);

#endregion

#region ConfigureService
// Add services to the container.

builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
});

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IUserSatusChangeService, UserSatusChangeService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();
builder.Services.AddScoped<IProductFacad, ProductFacad>();
builder.Services.AddScoped<IGetMenuItemService, GetMenuItemService>();
builder.Services.AddScoped<IGetCategoryService, GetCategoryService>();



string connectionString = new SqlConnectionStringBuilder()
{
    DataSource = @"DESKTOP-OR79DS3",
    InitialCatalog = "fish313Db",
    IntegratedSecurity = true
}.ConnectionString;

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddRazorPages();  // خودم کامنت کردم
builder.Services.AddControllersWithViews();


#endregion

#region Configure


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

app.UseAuthorization();
app.UseAuthentication();
app.MapRazorPages(); //خودم کامنت کردم

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
     name: "default",
     pattern: "{controller=Home}/{action=Index}/{id?}"
   );

    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
}
);


app.Run();
#endregion



