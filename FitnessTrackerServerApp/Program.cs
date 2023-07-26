using Microsoft.EntityFrameworkCore;

using FitnessTrackerServerApp.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using FitnessTrackerServerApp.Service;
using System.Text;
using FitnessTrackerServerApp.Utility;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FitnessTrackerServerAppDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("FitnessTrackerServerAppDBContext") ?? throw new InvalidOperationException("Connection string 'FitnessTrackerServerAppDBContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IWeightEntryService, WeightEntryService>();
builder.Services.AddTransient<IWorkoutEntryService, WorkoutEntryService>();
builder.Services.AddTransient<ICheatMealEntryService, CheatMealEntryService>();
builder.Services.AddTransient<IReportService, ReportService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Fitness Tracker App API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{*/
    app.UseSwagger();
    app.UseSwaggerUI();
/*}*/
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<RequestResponseLoggingMiddleware>();

app.MapControllers();
app.UseStaticFiles();
app.Run();
