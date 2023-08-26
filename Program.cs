using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using Task5;
using Task5.MiddleWare;
using Task5.Services.Comments;
using Task5.Services.Friendships;
using Task5.Services.Posts;
using Task5.Services.Users;

var builder = WebApplication.CreateBuilder(args);

var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(c =>
    c.UseSqlServer(connStr));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();//Memory Cache register
builder.Services.AddScoped<ICommentServices,CommentServices>();
builder.Services.AddScoped<IFriendshipServices,FriendshipServices>();
builder.Services.AddScoped<IPostServices,PostServices>();
builder.Services.AddScoped<IUserServices,UserServices>();
    
builder.Services.AddHttpContextAccessor();


builder.Services.AddHangfire(x => x.UseSqlServerStorage(connStr));
builder.Services.AddHangfireServer();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors();
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:Token").Value!))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHangfireDashboard("/dashboard");
app.UseMiddleware<MiddleWareExceptionHandle>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
