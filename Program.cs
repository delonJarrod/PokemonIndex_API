using RapidApid_gaming.Interface;
using RapidApid_gaming.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//services cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


builder.Services.AddScoped<IPokemon, Pokemon>();
builder.Services.AddScoped<IOpenAI, OpenAI>();
builder.Services.AddControllers().AddControllersAsServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app cors
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("corsapp");
app.UseAuthorization();

//app.UseCors(prodCorsPolicy);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
