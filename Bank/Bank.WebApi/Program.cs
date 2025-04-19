/// <summary>
/// Punto de entrada principal de la aplicación Web API.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Agrega servicios necesarios al contenedor de dependencias.
/// Incluye generadores de Swagger/OpenAPI para documentación automática.
/// </summary>
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/// <summary>
/// Configura el middleware HTTP.
/// Si está en entorno de desarrollo, habilita Swagger y su UI.
/// </summary>
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/// <summary>
/// Redirige automáticamente HTTP a HTTPS.
/// </summary>
app.UseHttpsRedirection();

/// <summary>
/// Arreglo de descripciones climáticas posibles.
/// </summary>
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild",
    "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

/// <summary>
/// Endpoint GET que devuelve un pronóstico del clima para los próximos 5 días.
/// </summary>
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();

    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

/// <summary>
/// Ejecuta la aplicación.
/// </summary>
app.Run();

/// <summary>
/// Representa el pronóstico del clima para una fecha determinada.
/// </summary>
/// <param name="Date">Fecha del pronóstico.</param>
/// <param name="TemperatureC">Temperatura en grados Celsius.</param>
/// <param name="Summary">Descripción textual del clima.</param>
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    /// <summary>
    /// Temperatura en grados Fahrenheit, calculada a partir de Celsius.
    /// </summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
