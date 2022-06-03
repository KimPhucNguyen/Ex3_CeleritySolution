using CeleritySolution.Application.Catalog.Agreements;
using CeleritySolution.Application.Catalog.Distributors;
using CeleritySolution.Application.System.Users;
using CeleritySolution.Data.EF;
using CeleritySolution.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Configuration;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("PolicyCelerity",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                                     .AllowAnyHeader()
                                     .AllowAnyMethod();

                          policy.WithOrigins("https://kimphucnguyen.github.io")
                                   .AllowAnyHeader()
                                   .AllowAnyMethod();
                          policy.WithOrigins("http://103.92.24.117")
                                   .AllowAnyHeader()
                                   .AllowAnyMethod();
                      });
});

var connectionString = builder.Configuration.GetConnectionString("CeleritySolutionDb");
builder.Services.AddDbContext<CelerityDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<CelerityDbContext>()
    .AddDefaultTokenProviders();

//Declare DI
builder.Services.AddTransient<IDistributorService, DistributorService>();
builder.Services.AddTransient<IAgreementService, AgreementService>();
builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
builder.Services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
builder.Services.AddTransient<IUserService, UserService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Celerity Solution", Version = "v1" });
});

var app = builder.Build();

app.UseSwaggerUI();

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

app.UseCors();
//app.UseCors("PolicyCelerity");

app.UseAuthorization();

app.UseSwagger(x => x.SerializeAsV2 = true);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
