// SaggerUI =>http://localhost:5153/swagger
// postman => http://localhost:5153/api/Customers

using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// API controllers.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

// Add Swagger Explorer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(function =>
{
    function.SwaggerDoc("v1", new OpenApiInfo { Title = "MyWebApp API", Version = "v1" });
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(function => function.SwaggerEndpoint("/swagger/v1/swagger.json", "MyWebApp API v1"));
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();  // Map API controllers Route
app.MapRazorPages();

app.Run();
