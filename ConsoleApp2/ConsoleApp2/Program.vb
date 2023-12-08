'Imports Business
'Imports Microsoft.AspNetCore.Builder
'Imports Microsoft.AspNetCore.Hosting
'Imports Microsoft.Extensions.Configuration
'Imports Microsoft.Extensions.DependencyInjection
'Imports Microsoft.Extensions.Hosting
'Imports System.Text.Json.Serialization

'Public Class Startup
'    Public Sub New(configuration As IConfiguration)
'        configuration = configuration
'    End Sub

'    Public ReadOnly Property Configuration As IConfiguration

'    ' Bu yöntem, hizmetleri uygulamanýn hizmet konteynerine ekler.
'    Public Sub ConfigureServices(services As IServiceCollection)
'        services.AddAPIServices(Configuration)
'        services.AddBusinessServices()
'    End Sub

'    ' Bu yöntem, uygulama çalýþtýrýldýðýnda çaðrýlýr. Bu yöntemde kullanýlan hizmetler
'    ' HTTP isteði iþleme alýnýr.
'    Public Sub Configure(app As IApplicationBuilder, env As IWebHostEnvironment)
'        If env.IsDevelopment() Then
'            app.UseSwagger()
'            app.UseSwaggerUI()
'        End If

'        app.UseAuthentication()
'        app.UseAuthorization()

'        app.UseEndpoints(Sub(endpoints) endpoints.MapControllers())

'        'app.UseCustomException()
'    End Sub
'End Class

'Module Program
'    Sub Main(args As String())
'        Dim builder = WebApplication.CreateBuilder(args)
'        builder.Services.AddControllers().AddJsonOptions(Sub(opt) opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
'        builder.Services.AddSwaggerGen()

'        Dim app = builder.Build()

'        app.UseHttpsRedirection()
'        app.UseAuthorization()

'        app.Run()
'    End Sub
'End Module
Imports Business
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports Microsoft.OpenApi.Models

Module Program
    Sub Main(args As String())
        Dim builder = WebApplication.CreateBuilder(args)

        builder.Services.AddAPIServices(builder.Configuration)
        builder.Services.AddBusinessServices()

        ' Add services to the container.
        'builder.Services.AddControllers()
        ' Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        'builder.Services.AddEndpointsApiExplorer()
        'builder.Services.AddSwaggerGen()

        Dim app = builder.Build()

        ' Configure the HTTP request pipeline.
        If app.Environment.IsDevelopment() Then
            app.UseSwagger()
            app.UseSwaggerUI()
        End If

        'app.UseHttpsRedirection()
        app.UseAuthentication()
        app.UseAuthorization()
        app.MapControllers()

        app.Run()
    End Sub
End Module