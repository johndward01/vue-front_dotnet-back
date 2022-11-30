var builder = WebApplication.CreateBuilder(args);


string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSpaStaticFiles(configuration: options => { options.RootPath = "wwwroot"; });
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("VueCorsPolicy", builder =>
    {
        builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .WithOrigins("https://localhost:5001");
    });
});

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
