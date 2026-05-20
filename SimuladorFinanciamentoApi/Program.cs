using SimuladorFinanciamentoApi.Services;
using Microsoft.EntityFrameworkCore;
using SimuladorFinanciamentoApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a Controllers
builder.Services.AddControllers();

// Dependency Injection
builder.Services.AddScoped<SimuladorService>();
builder.Services.AddScoped<SacService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<PriceService>();

//DbContext
builder.Services.AddDbContext<AppDbContext> (options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilita Swagger
app.UseSwagger();
app.UseSwaggerUI();

// HTTPS
app.UseHttpsRedirection();

// Autorização
app.UseAuthorization();

// Mapeia os controllers
app.MapControllers();

app.Run();