using Business;
using LM.WebAPI.Extensions;



var builder = WebApplication.CreateBuilder(args);



builder.Services.AddAPIServices(builder.Configuration);
builder.Services.AddBusinessServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//app.UseCustomException();

app.Run();
