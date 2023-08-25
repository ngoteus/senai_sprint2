using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//adiciona o servico de controllers
builder.Services.AddControllers();


builder.Services.AddSwaggerGen(options =>
{
    //Adiciona as informacoes sobre API no Swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes Manha",
        Description = "API para gerenciamento de filmes - introducao da sprint 2 - Backend API",
        Contact = new OpenApiContact
        {
            Name = "Senai Informatica - Turma Manha",
            Url = new Uri("https://github.com/senai-desenvolvimento/2023-1S-2D")
        },
    });

    // Configura o swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});

var app = builder.Build();

//Comeca a configuracao do swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
//Finaliza a configuracao do swagger


//adiciona o mapeamento dos controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
