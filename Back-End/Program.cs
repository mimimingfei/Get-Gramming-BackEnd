using Microsoft.EntityFrameworkCore;
using Back_End.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Back_End.IService;
using Back_End.Service;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreDB")));
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
// Add CORS services and define the policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithOrigins("http://127.0.0.1:5173") // Replace with the client application's origin
                         .AllowAnyHeader()
                         .AllowAnyMethod();
    });
});
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
// Use the CORS policy
app.UseCors("MyCorsPolicy");
app.UseAuthorization();
app.MapControllers();
app.Run();