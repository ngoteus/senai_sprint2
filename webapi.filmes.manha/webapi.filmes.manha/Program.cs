var builder = WebApplication.CreateBuilder(args);

//adiciona o servico de controllers
builder.Services.AddControllers();

var app = builder.Build();

//adiciona o mapeamento dos controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
