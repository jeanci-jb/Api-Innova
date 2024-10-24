using Api_Innovatech.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuraci�n de la cadena de conexi�n
var Configuracion = new Configuracion(builder.Configuration.GetConnectionString("innovatech_500"));
builder.Services.AddSingleton(Configuracion);

// Registro de servicios
builder.Services.AddScoped<IProducto, CrudProducto>();
builder.Services.AddScoped<IProveedor, CrudProveedor>(); // Agrega esta l�nea

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
