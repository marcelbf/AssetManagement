var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/location/{user}", (string user) =>
{
    if (!Validation.userValidation(user))
    {
        return new List<string> { "error" };
    }

    return new List<string>{
        "Belgium",
        "Denmark",
        "France",
        "Germany",
        "Norway"
    };
})
.WithName("GetLocations")
.WithOpenApi();

app.Run();

class Validation
{
    public static bool userValidation(string? user)
    {
        if (Guid.TryParse(user, out _))
            { return true; }
        return false;
    }
}