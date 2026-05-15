using SimuladorFinanciamentoApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a Controllers
builder.Services.AddControllers();

// Dependency Injection
builder.Services.AddScoped<SimuladorService>();
builder.Services.AddScoped<SacService>();
builder.Services.AddScoped<PriceService>();

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