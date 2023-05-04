using DominoApi.Exceptions;
using DominoApi.Services;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();
builder.Services.AddSingleton<DominoService>();

var app = builder.Build();

app.UseCors(policy => policy
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();

public partial class Program
{

}