using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Chinook_Backend.Utilities.Security.Encryption;
using Chinook_Backend.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Chinook_Backend.Extensions;
using Chinook_Backend.DependencyResolvers;
using Chinook_Backend.Utilities.IoC;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "Demo API",
		Version = "v1"
	});
	options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		In = ParameterLocation.Header,
		Description = "Please enter a valid token",
		Name = "Authorization",
		Type = SecuritySchemeType.Http,
		BearerFormat = "JWT",
		Scheme = "Bearer"
	});
	options.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type =ReferenceType.SecurityScheme,
					Id ="Bearer"
				}
			},
			new string[]{}
		}
	});
});


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
	.ConfigureContainer<ContainerBuilder>(builder =>
	{
		builder.RegisterModule(new AutofacBusinessModule());
	});

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
	new CoreModule()
});

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidIssuer = tokenOptions.Issuer,
			ValidAudience = tokenOptions.Audience,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
		};
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
