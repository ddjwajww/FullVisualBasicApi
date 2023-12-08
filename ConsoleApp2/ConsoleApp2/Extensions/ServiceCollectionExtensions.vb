Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.IdentityModel.Tokens
Imports Microsoft.OpenApi.Models
Imports System.Text
Imports System.Text.Json.Serialization
Imports System.Text.Json.Serialization.JsonConverter
Imports System.Text.Json.Serialization.ReferenceHandler
Imports System
Imports System.Collections.Generic
Imports infrastructure

Public Module ServiceCollectionExtensions
    <Runtime.CompilerServices.Extension>
    Public Sub AddAPIServices(services As IServiceCollection, config As IConfiguration)
        services.AddControllers().AddJsonOptions(
            Sub(opt) opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)

        ' Add services to the container.

        Dim tokenOptions = config.GetSection("TokenOptions").Get(Of TokenOptions)()

        services.AddAuthentication(
            Sub(opt)
                opt.DefaultAuthenticateScheme = "Bearer"
                opt.DefaultChallengeScheme = "Bearer"
            End Sub
        ).AddJwtBearer(
            Sub(opt)
                opt.TokenValidationParameters = New TokenValidationParameters() With
                {
                    .ValidateIssuer = True,
                    .ValidIssuer = tokenOptions.Issuer,
                    .ValidateAudience = True,
                    .ValidAudience = tokenOptions.Audience,
                    .ValidateLifetime = True,
                    .ValidateIssuerSigningKey = True,
                    .IssuerSigningKey = New SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),
                    .ClockSkew = TimeSpan.Zero
                }
            End Sub
        )

        ' Swagger/OpenAPI configuration
        services.AddEndpointsApiExplorer()
        services.AddSwaggerGen(
            Sub(c)
                c.AddSecurityDefinition("Bearer", New OpenApiSecurityScheme() With
                {
                    .Description = "JWT Authorization",
                    .Name = "Authorization",
                    .In = ParameterLocation.Header,
                    .Type = SecuritySchemeType.Http,
                    .Scheme = "Bearer",
                    .BearerFormat = "JWT"
                })

                c.AddSecurityRequirement(New OpenApiSecurityRequirement() From
                {
                    {
                        New OpenApiSecurityScheme With
                        {
                            .Reference = New OpenApiReference With
                            {
                                .Type = ReferenceType.SecurityScheme,
                                .Id = "Bearer"
                            }
                        },
                        New List(Of String)()
                    }
                })
            End Sub
        )
    End Sub
End Module
