using MongoDB.Driver;
using TankBackend.Data;
using TankBackend.Services;

var builder = WebApplication.CreateBuilder(args);

var mongoSettings = builder.Configuration.GetSection("MongoDB");
string databaseName = mongoSettings["DatabaseName"] ?? 
    throw new InvalidOperationException("MongoDB database name is missing in configuration.");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(mongoSettings["ConnectionString"]));

builder.Services.AddScoped<ITankRepository>(s =>
    new TankRepository(s.GetRequiredService<IMongoClient>(), databaseName));
builder.Services.AddScoped<TankService>();
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
