using Ecommerce.BL;
using Ecommerce.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Security.Claims;
using System.Text;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Default
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Configure CORS
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder
         .AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader();

}));

#endregion


#region Database configuration

var connetionstring = builder.Configuration.GetConnectionString("connction_string");

builder.Services.AddDbContext<EcommerceDB>(
    options => options.UseSqlServer(connetionstring));

#endregion

#region Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#endregion

#region Repos

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

#endregion


#region Managers BL

builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<IOrderManager, OrderManager>();
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
    
#endregion


#region Redis configuration

builder.Services.AddSingleton<IConnectionMultiplexer>(c =>
{
    var options = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"));
    return ConnectionMultiplexer.Connect(options);
}

);

// Redis:in-memory data structure store that is used as a database
// it act as a singleton

#endregion

#region Configure Rate Limit
/// this section to prevent DOS attack & limit number of requests
builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
            factory: partition => new FixedWindowRateLimiterOptions
            {
                AutoReplenishment = true,
                PermitLimit = 4,
                QueueLimit = 0,
                Window = TimeSpan.FromMinutes(1)
            }));

    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

});

#endregion


#region Response Caching
/// this region to reduce the number of trips the request go to the database
builder.Services.AddResponseCaching(a => a.MaximumBodySize = 1024);  // this overload makes the MaximumBodySize for caching is 1024 byte instead of 64 mb which is the default 

#endregion

#region configure usermanager
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

    options.User.RequireUniqueEmail = true;


}).
    AddEntityFrameworkStores<EcommerceDB>();

#endregion 


#region Configure Authentication scheme
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "myscheme";
    options.DefaultChallengeScheme = "myscheme";

})
    .AddJwtBearer("myscheme", options =>
{
    var secretKeyString = builder.Configuration.GetValue<string>("SecretKey");
    var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? "");
    SymmetricSecurityKey? secretKey = new SymmetricSecurityKey(secretKeyInBytes);

    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = secretKey,
        ValidateIssuer = false,                          /// who send token
        ValidateAudience = false                        // who  receeive token

    };
}
);


#endregion


#region Authorization Configuration (policy)

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminsOnly", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "Admin").
        RequireClaim(ClaimTypes.NameIdentifier);     // this field must be exist regardless of value
    });

    options.AddPolicy("Admins_users", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "Admin", "User").
        RequireClaim(ClaimTypes.NameIdentifier);     // this field must be exist regardless of value
    });
    
});

#endregion








var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.UseRateLimiter();

/// this middleware must be come after CORS miidleWare
app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl =
        new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
        {
            Public = true,
            MaxAge = TimeSpan.FromSeconds(10)   /// caching is going to be for 10 s
        };
    context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
        new string[] { "Accept-Encoding" };

    await next();
});

app.Run();
