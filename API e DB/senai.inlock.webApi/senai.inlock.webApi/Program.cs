//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.Run();
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//adiciona o servico de controllers
builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //Valida quem esta solicitando
        ValidateIssuer = true,

        //valida quem esta recebendo
        ValidateAudience = true,

        //Define se o tempo de expiracao sera validado
        ValidateLifetime = true,

        //forma de criptografia e valida a chave de autenticacao
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("jogos-chaves-autenticacao-webapi-dev")),

        //valida o tempo de expiracao do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //nome do issuer (de onde esta vindo)
        ValidIssuer = "senai.inlock.webApi.",

        //nome do audience (para onde esta indo)
        ValidAudience = "senai.inlock.webApi."
    };
});

builder.Services.AddSwaggerGen(options =>
{
    //Adiciona as informacoes sobre API no Swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Jogos Manha",
        Description = "API para gerenciamento de jogos - introducao da sprint 2 - Backend API",
        Contact = new OpenApiContact
        {
            Name = "Senai Informatica - Turma Manha",
            Url = new Uri("https://github.com/senai-desenvolvimento/2023-1S-2D")
        },
    });

    // Configura o swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //Usando a autenticaçao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

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

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();

app.Run();
