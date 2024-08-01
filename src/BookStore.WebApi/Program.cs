using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(opts =>
{
    opts.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "BookStore API",
        Version = "v1"
    });
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.RegisterInfrastureDependencies(builder.Configuration);

builder.Services.AddRequestTimeouts(options => {
    options.DefaultPolicy =
        new RequestTimeoutPolicy
        {
            Timeout = TimeSpan.FromMilliseconds(1500),
            TimeoutStatusCode = StatusCodes.Status503ServiceUnavailable
        };
    options.AddPolicy("CustomPolicy",
        new RequestTimeoutPolicy
        {
            Timeout = TimeSpan.FromMilliseconds(2000),
            TimeoutStatusCode = StatusCodes.Status503ServiceUnavailable
        });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.UseRequestTimeouts();
app.MapControllers();
app.Run();
