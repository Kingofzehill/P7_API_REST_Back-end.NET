using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Repositories;
using P7CreateRestApi.Services;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Asp.Net Identity to existing project 
// https://learn.microsoft.com/fr-fr/aspnet/identity/overview/getting-started/adding-aspnet-identity-to-an-empty-or-existing-web-forms-project
builder.Services.AddDbContext<LocalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Service ASP.NET Core Identity with User table and role based on IdentityRole.
// https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-8.0&tabs=visual-studio.
builder.Services.AddIdentity<User, IdentityRole<int>>()
    .AddEntityFrameworkStores<LocalDbContext>()
    .AddDefaultTokenProviders();

/*builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
    {
        policy.RequireRole("Admin");
        policy.RequireAuthenticatedUser();        
    });

    options.AddPolicy("User", policy =>
    {
        policy.RequireRole("User", "Admin");
        policy.RequireAuthenticatedUser();        
    });
});*/

builder.Services.AddScoped<IBidListRepository, BidListRepository>();
builder.Services.AddScoped<IBidListService, BidListService>();
builder.Services.AddScoped<ICurvePointRepository, CurvePointRepository>();
builder.Services.AddScoped<ICurvePointService, CurvePointService>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<IRuleNameRepository, RuleNameRepository>();
builder.Services.AddScoped<IRuleNameService, RuleNameService>();
builder.Services.AddScoped<ITradeRepository, TradeRepository>();
builder.Services.AddScoped<ITradeService, TradeService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var dbcontext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
        dbcontext.Database.EnsureCreated();
    }
    app.UseSwagger();
    app.UseSwaggerUI();
}

// User roles User / Admin.
/* using (var scope = app.Services.CreateScope())
{
    using var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new IdentityRole<int> { Name = "User" });
        await roleManager.CreateAsync(new IdentityRole<int> { Name = "Admin" });

        using var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var admins = await userManager.GetUsersInRoleAsync("Admin");
        if (admins.Count == 0)
        {
            var user = new User
            {
                UserName = "admin",
                FullName = "Admin",
                Role = "Admin",
            };
            var result = await userManager.CreateAsync(user, "Sy4oSfGDBWZJ8hcwOG?h$V&");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, user.Role);
            }
        }
    }
}*/

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
