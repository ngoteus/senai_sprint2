var builder = WebApplication.CreateBuilder(args);

//adiciona o servico de controllers
builder.Services.AddControllers();


builder.Services.AddSwaggerGen();

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
