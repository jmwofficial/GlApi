using ConceptDbLib;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ConceptDb>();

var app = builder.Build();

ConceptDb db = app.Services.GetService<ConceptDb>() ?? throw new InvalidOperationException("ConceptDbError: Could Not Initialize.");

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
