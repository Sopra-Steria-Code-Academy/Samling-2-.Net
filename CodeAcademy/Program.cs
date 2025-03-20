using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using CodeAcademy.Filter;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"))
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddInMemoryTokenCaches();

// Add services to the container.
builder.Services.AddAuthorization();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.EnableAnnotations();
    option.SwaggerDoc("docs", new OpenApiInfo
    {
        Title = "API Documentation",
        Version = "docs",
        Description = "API Documentation without interactive features.",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Code Academy",
            Email = "per.hoff@soprasteria.com"
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Code Academy",
        Version = "v1",
        Description = "Code Academy API",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Code Academy",
            Email = "per.hoff@soprasteria.com"
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    option.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "OAuth2.0 Auth Code with PKCE", //PKCE/“pixy,” is an extension of the OAuth 2.0 protocol that helps prevent code interception attack
        Name = "oauth2",
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri(builder.Configuration["AuthorizationUrl"]),
                TokenUrl = new Uri(builder.Configuration["TokenUrl"]),
                Scopes = new Dictionary<string, string>
                {
                    { builder.Configuration["ApiScope"], "read the api" }
                }
            }
        }
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
            },
            new List<string> { }
        }
    });
    option.DocumentFilter<CustomDocumentFilter>();
});

var app = builder.Build();

app.UseSwagger(c =>
{
    c.RouteTemplate = "docs/api/{documentName}/swagger.json";
});
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/docs/api/docs/swagger.json", "API Documentation");
    c.SwaggerEndpoint("/docs/api/v1/swagger.json", "REIN Hub API v1");
    c.RoutePrefix = "docs/api";
    c.OAuthClientId(builder.Configuration["OpenIdClientId"]);
    c.OAuthUsePkce();
    c.OAuthScopeSeparator(" ");
});

app.UseHttpsRedirection();

app.UseAuthorization();

var options = new DefaultFilesOptions();
options.DefaultFileNames.Clear();
options.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(options);

app.UseStaticFiles();
app.MapControllers();

app.Run();
