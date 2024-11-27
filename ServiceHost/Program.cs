using _0_Framework.Application.AuthHelper;
using _0_Framework.Application.Sms;
using _0_Framework.Application.ZarinPal;
using _0_Framework.Application;
using _0_Framework.Application.HashPassword;
using AccountManagement.Configuration;
using BlogManagement.Configuration;
using CommentManagement.Configuration;
using DiscountManegment.Configuration;
using InventoryManegment.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using ServiceHost;
using SlideManagement.Infrastucture.Configuration;
using TrucksManagement.Configuration;
using _0_Framework.Infrastructure;
using KamionLandQuery.Contracts.Menu;
using KamionLandQuery.Contracts.SlideTrucks;
using KamionLandQuery.Querys;
using KamionLandQuery.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
var contectionstring = builder.Configuration.GetConnectionString("kamionLandDb");

// Add services to the container.
CommentManagementBootstrapper.Configure(builder.Services, contectionstring);
BlogManagementBootstrapper.Configure(builder.Services, contectionstring);
SlideManagementBoostrapper.Configur(builder.Services, contectionstring);
AccountManagementBootstrapper.Configure(builder.Services, contectionstring);
DiscountManagementBoostrapper.ConfigurDiscount(builder.Services,contectionstring);
InventoryManagementBoostrapper.ConfigurInventory(builder.Services,contectionstring);
TrucksManagementBoostrapper.Configur(builder.Services,contectionstring);
KamionlandQueryManagementBoostrapper.Configur(builder.Services,contectionstring);



builder.Services.AddScoped<IFileUploader, FileUploader>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IAuthHelper, AuthHelper>();
builder.Services.AddTransient<IZarinPalFactory, ZarinPalFactory>();
builder.Services.AddTransient<ISmsService, SmsService>();



builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
    {
        o.LoginPath = new PathString("/Account");
        o.LogoutPath = new PathString("/Account");
        o.AccessDeniedPath = new PathString("/AccessDenied");
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SuperAdmin",
        builder => builder.RequireRole(new List<string> { Roles.Administrator }));
  
});

// Add services to the container.
builder.Services.AddRazorPages().AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizeAreaFolder("Admin", "/", "SuperAdmin");
       

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();

app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();

app.Run();
